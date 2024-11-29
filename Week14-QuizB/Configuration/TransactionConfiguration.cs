using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week14_QuizB.Entities;

namespace Week14_QuizB.Configuration;

public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.HasKey(t => t.TransactionId);
        builder.Property(t => t.SourceCardNumber).IsRequired().HasMaxLength(16);
        builder.Property(t => t.DestinationCardNumber).IsRequired().HasMaxLength(16);
        builder.Property(t => t.Amount).IsRequired();
        builder.Property(t => t.TransactionDate).IsRequired();
        builder.Property(t => t.IsSuccessful).IsRequired();
    }
}
