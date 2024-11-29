using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week14_QuizB.Contract.RepositoryInterface;
using Week14_QuizB.Data;
using Week14_QuizB.Entities;

namespace Week14_QuizB.Repository;

public class TransactionRepository : ITransactionRepository
{
    private readonly AppDbContext _context;


    public TransactionRepository(AppDbContext context)
    {
        _context = context;
    }

    public void AddTransaction(Transaction transaction)
    {
        _context.Transactions.Add(transaction);
        _context.SaveChanges();
    }

    public IEnumerable<Transaction> GetTransactionsByCard(string cardNumber)
    {
        return _context.Transactions
            .Where(t => t.SourceCardNumber == cardNumber || t.DestinationCardNumber == cardNumber)
            .ToList();
    }

}
