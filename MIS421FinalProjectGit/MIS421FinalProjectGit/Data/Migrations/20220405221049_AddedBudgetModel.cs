using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MIS421FinalProjectGit.Data.Migrations
{
    public partial class AddedBudgetModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Budget",
                columns: table => new
                {
                    BudgetID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BugetItem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserAccountID = table.Column<int>(type: "int", nullable: false),
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Budget");
        }
    }
}
