using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week14_QuizB.Contract.RepositoryInterface;
using Week14_QuizB.Contract.ServiceInterface;
using Week14_QuizB.Entities;

namespace Week14_QuizB.Services;

public class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly ICardRepository _cardRepository;

    public TransactionService(ITransactionRepository transactionRepository, ICardRepository cardRepository)
    {
        _transactionRepository = transactionRepository;
        _cardRepository = cardRepository;
    }

    public string Transfer(string sourceCardNumber, string destinationCardNumber, float amount, string password)
    {
        var sourceCard = _cardRepository.GetCardByNumber(sourceCardNumber);
        var destinationCard = _cardRepository.GetCardByNumber(destinationCardNumber);

        if (sourceCard == null || destinationCard == null)
            return "Invalid card number.";

        if (!sourceCard.IsActive)
            return "Source card is blocked. No transactions allowed.";

        if (amount > 250)
            return "The transfer amount must be less than or equal to $250.";

        if (sourceCard.Password != password)
        {
            sourceCard.WrongAttempts++;
            if (sourceCard.WrongAttempts >= 3)
            {
                sourceCard.IsActive = false;
                _cardRepository.UpdateCard(sourceCard);
                return "Source card is blocked due to 3 incorrect password attempts.";
            }
            _cardRepository.UpdateCard(sourceCard);
            return $"Incorrect password. You have {3 - sourceCard.WrongAttempts} attempts left.";
        }

        sourceCard.WrongAttempts = 0;

        if (sourceCard.LastTransferDate.Date != DateTime.Today)
        {
            sourceCard.DailyTransferred = 0;
            sourceCard.LastTransferDate = DateTime.Today;
        }

        if (sourceCard.DailyTransferred + amount > 250)
            return $"Daily transfer limit exceeded. You have already transferred ${sourceCard.DailyTransferred} today.";

        if (sourceCard.Balance < amount)
            return "Insufficient balance.";

        sourceCard.Balance -= amount;
        destinationCard.Balance += amount;

        sourceCard.DailyTransferred += amount;

        var transaction = new Transaction
        {
            SourceCardNumber = sourceCardNumber,
            DestinationCardNumber = destinationCardNumber,
            Amount = amount,
            TransactionDate = DateTime.Now,
            IsSuccessful = true
        };

        _transactionRepository.AddTransaction(transaction);
        _cardRepository.UpdateCard(sourceCard);
        _cardRepository.UpdateCard(destinationCard);

        return "Transfer successful.";
    }

    public IEnumerable<Transaction> GetTransactions(string cardNumber)
    {
        return _transactionRepository.GetTransactionsByCard(cardNumber)
            .OrderByDescending(t => t.TransactionDate);
    }

}
