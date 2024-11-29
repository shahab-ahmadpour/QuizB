using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week14_QuizB.Entities;

namespace Week14_QuizB.Contract.RepositoryInterface;

public interface ITransactionRepository
{
    void AddTransaction(Transaction transaction);
    IEnumerable<Transaction> GetTransactionsByCard(string cardNumber);
}
