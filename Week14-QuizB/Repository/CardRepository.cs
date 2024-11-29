using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week14_QuizB.Contract.RepositoryInterface;
using Week14_QuizB.Data;
using Week14_QuizB.Entities;

namespace Week14_QuizB.Repository;

public class CardRepository : ICardRepository
{
    private readonly AppDbContext _context;

    public CardRepository(AppDbContext context)
    {
        _context = context;
    }

    public Card GetCardByNumber(string cardNumber)
    {
        return _context.Cards.SingleOrDefault(c => c.CardNumber == cardNumber);
    }

    public void UpdateCard(Card card)
    {
        _context.Cards.Update(card);
        _context.SaveChanges();
    }
}