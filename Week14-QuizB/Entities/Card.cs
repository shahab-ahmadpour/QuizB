using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week14_QuizB.Entities;

public class Card
{
    public string CardNumber { get; set; }
    public string HolderName { get; set; }
    public float Balance { get; set; }
    public bool IsActive { get; set; }
    public string Password { get; set; }
    public int WrongAttempts { get; set; }

    public float DailyTransferred { get; set; } = 0;
    public DateTime LastTransferDate { get; set; } = DateTime.MinValue;
}
