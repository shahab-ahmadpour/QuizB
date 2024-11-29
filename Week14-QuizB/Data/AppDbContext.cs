using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week14_QuizB.Configuration;
using Week14_QuizB.Entities;

namespace Week14_QuizB.Data;

public class AppDbContext : DbContext
{
    public DbSet<Card> Cards { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=DESKTOP-PU6OMQ0\\SQLEXPRESS;Database=QuizB;Integrated Security=true;User ID=sa;Password=P@ssw0rd;TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Card>().HasData(
    new Card { CardNumber = "1231231231231231", HolderName = "shahab", Balance = 4500, IsActive = true, Password = "1234", WrongAttempts = 0 },
    new Card { CardNumber = "0000000000000000", HolderName = "sara", Balance = 2000, IsActive = true, Password = "0000", WrongAttempts = 0 });

        modelBuilder.ApplyConfiguration(new CardConfiguration());
        modelBuilder.ApplyConfiguration(new TransactionConfiguration());
    }
}
