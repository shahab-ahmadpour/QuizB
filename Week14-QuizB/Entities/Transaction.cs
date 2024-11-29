using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week14_QuizB.Entities;

public class Transaction
{
    public int TransactionId { get; set; }
    public string SourceCardNumber { get; set; }
    public string DestinationCardNumber { get; set; }
    public float Amount { get; set; }
    public DateTime TransactionDate { get; set; }
    public bool IsSuccessful { get; set; }
}
