using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week14_QuizB.Entities;

namespace Week14_QuizB.Contract.RepositoryInterface;

public interface ICardRepository
{
    Card GetCardByNumber(string cardNumber);
    void UpdateCard(Card card);
}

