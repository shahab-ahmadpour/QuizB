using Week14_QuizB.Contract.RepositoryInterface;
using Week14_QuizB.Contract.ServiceInterface;
using Week14_QuizB.Data;
using Week14_QuizB.Entities;
using Week14_QuizB.Repository;
using Week14_QuizB.Services;


AppDbContext context = new AppDbContext();

ICardRepository cardRepository = new CardRepository(context);
ITransactionRepository transactionRepository = new TransactionRepository(context);
ITransactionService transactionService = new TransactionService(transactionRepository, cardRepository);

while (true)
{
    Console.WriteLine("\n--- Transaction Menu ---");
    Console.WriteLine("1. Transfer funds");
    Console.WriteLine("2. View transaction history");
    Console.WriteLine("0. Exit");
    Console.Write("Enter your choice: ");
    var choice = Console.ReadLine();

    if (choice == "0") break;

    switch (choice)
    {
        case "1":
            string sourceCard;
            do
            {
                Console.Write("Source Card Number (16 digits): ");
                sourceCard = Console.ReadLine();

                if (!IsValidCardNumber(sourceCard))
                {
                    Console.WriteLine("Invalid card number. Please enter a valid 16-digit card number.");
                }
                else
                {
                    break;
                }
            } while (true);

            string destinationCard;
            do
            {
                Console.Write("Destination Card Number (16 digits): ");
                destinationCard = Console.ReadLine();

                if (!IsValidCardNumber(destinationCard))
                {
                    Console.WriteLine("Invalid card number. Please enter a valid 16-digit card number.");
                }
                else
                {
                    break;
                }
            } while (true);

            Console.Write("Amount: ");
            float amount;
            while (!float.TryParse(Console.ReadLine(), out amount) || amount <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive amount:");
            }

            string transferResult;
            do
            {
                Console.Write("Password (Enter 0 to return to menu): ");
                var sourcePassword = Console.ReadLine();

                if (sourcePassword == "0")
                {
                    Console.WriteLine("Returning to the main menu...");
                    break;
                }

                transferResult = transactionService.Transfer(sourceCard, destinationCard, amount, sourcePassword);
                Console.WriteLine(transferResult);

                if (transferResult.Contains("blocked")) break;

            } while (transferResult.Contains("Incorrect password"));

            break;

        case "2":
            Console.Write("Enter Card Number to view transactions: ");
            var transactionCardNumber = Console.ReadLine();

            var transactions = transactionService.GetTransactions(transactionCardNumber);

            if (!transactions.Any())
            {
                Console.WriteLine("No transactions found for this card.");
            }
            else
            {
                Console.WriteLine("\n--- Transaction History ---");
                foreach (var transaction in transactions)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"Source: {transaction.SourceCardNumber}, ");

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"Destination: {transaction.DestinationCardNumber}, ");

                    Console.ResetColor();
                    Console.WriteLine($"Amount: {transaction.Amount}, Date: {transaction.TransactionDate}");
                }
            }
            break;

        default:
            Console.WriteLine("Invalid choice.");
            break;
    }
}
bool IsValidCardNumber(string cardNumber)
{
    return cardNumber.Length == 16 && cardNumber.All(char.IsDigit);
}