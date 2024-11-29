using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week14_QuizB.Entities;

namespace Week14_QuizB.Configuration;

public class CardConfiguration : IEntityTypeConfiguration<Card>
{
    public void Configure(EntityTypeBuilder<Card> builder)
    {
        builder.HasKey(c => c.CardNumber);
        builder.Property(c => c.CardNumber).IsRequired().HasMaxLength(16);
        builder.Property(c => c.HolderName).IsRequired().HasMaxLength(100);
        builder.Property(c => c.Balance).IsRequired().HasDefaultValue(0);
        builder.Property(c => c.IsActive).IsRequired().HasDefaultValue(true);
        builder.Property(c => c.Password).IsRequired().HasMaxLength(50);
        builder.Property(c => c.WrongAttempts).HasDefaultValue(0);
    }
}
