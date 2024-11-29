using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Week14_QuizB.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    CardNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    HolderName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Balance = table.Column<float>(type: "real", nullable: false, defaultValue: 0f),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    WrongAttempts = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    DailyTransferred = table.Column<float>(type: "real", nullable: false),
                    LastTransferDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.CardNumber);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SourceCardNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    DestinationCardNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsSuccessful = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "CardNumber", "Balance", "DailyTransferred", "HolderName", "IsActive", "LastTransferDate", "Password" },
                values: new object[,]
                {
                    { "0000000000000000", 2000f, 0f, "sara", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0000" },
                    { "1231231231231231", 4500f, 0f, "shahab", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1234" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Transactions");
        }
    }
}
