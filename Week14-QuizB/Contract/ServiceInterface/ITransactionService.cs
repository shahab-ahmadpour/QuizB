using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week14_QuizB.Entities;

namespace Week14_QuizB.Contract.ServiceInterface;

public interface ITransactionService
{
    string Transfer(string sourceCardNumber, string destinationCardNumber, float amount, string password);
    IEnumerable<Transaction> GetTransactions(string cardNumber);
}
