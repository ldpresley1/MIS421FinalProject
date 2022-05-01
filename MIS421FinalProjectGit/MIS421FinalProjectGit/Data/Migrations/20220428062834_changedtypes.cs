using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MIS421FinalProjectGit.Data.Migrations
{
    public partial class changedtypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                 name: "Bill",
                 columns: table => new
                 {
                     BillID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                     BillType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                     DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                     Amount = table.Column<double>(type: "float", nullable: false),
                     DayPaid = table.Column<DateTime>(type: "datetime2", nullable: false),
                     Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                     UserAccountID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                     ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                 },
                 constraints: table =>
                 {
                     table.PrimaryKey("PK_Bill", x => x.BillID);
                     table.ForeignKey(
                         name: "FK_Bill_UserAccount_ID",
                         column: x => x.ID,
                         principalTable: "UserAccount",
                         principalColumn: "ID");
                 });

            migrationBuilder.CreateIndex(
                name: "IX_Bill_ID",
                table: "Bill",
                column: "ID");

            migrationBuilder.CreateTable(
                 name: "Budget",
                 columns: table => new
                 {
                     BudgetID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                     BugetItem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                     Amount = table.Column<double>(type: "float", nullable: false),
                     Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                     UserAccountID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                     ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                 },
                 constraints: table =>
                 {
                     table.PrimaryKey("PK_Budget", x => x.BudgetID);
                     table.ForeignKey(
                         name: "FK_Budget_UserAccount_ID",
                         column: x => x.ID,
                         principalTable: "UserAccount",
                         principalColumn: "ID");
                 });

            migrationBuilder.CreateIndex(
                name: "IX_Budget_ID",
                table: "Budget",
                column: "ID");

            migrationBuilder.CreateTable(
               name: "Transactions",
               columns: table => new
               {
                   TransactionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                   TransType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   TransCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                   comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                   UserAccountID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                   ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Transactions", x => x.TransactionID);
                   table.ForeignKey(
                       name: "FK_Transactions_UserAccount_ID",
                       column: x => x.ID,
                       principalTable: "UserAccount",
                       principalColumn: "ID");
               });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ID",
                table: "Transactions",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Investments",
                columns: table => new
                {
                    BillID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvestmentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RiskLevel = table.Column<int>(type: "int", nullable: false),
                    UserAccountID = table.Column<int>(type: "int", nullable: false),
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InvestmentImage = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investments", x => x.BillID);
                    table.ForeignKey(
                        name: "FK_Investments_UserAccount_ID",
                        column: x => x.ID,
                        principalTable: "UserAccount",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Investments_ID",
                table: "Investments",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bill");
            migrationBuilder.DropTable(
                name: "Investments");
            migrationBuilder.DropTable(
                name: "Budget");
            migrationBuilder.DropTable(
                name: "Transactions");
        }
       
        }
    }

