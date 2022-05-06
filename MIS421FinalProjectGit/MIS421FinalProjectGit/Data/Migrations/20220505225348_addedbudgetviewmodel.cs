using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MIS421FinalProjectGit.Data.Migrations
{
    public partial class addedbudgetviewmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
 

            migrationBuilder.CreateTable(
                name: "BudgetViewModel",
                columns: table => new
                {
                    BudgetID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Balance = table.Column<double>(type: "float", nullable: false),
                    LeftoverEarnings = table.Column<double>(type: "float", nullable: false),
                    initialBalance = table.Column<double>(type: "float", nullable: false),
                    ApplicationUserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetViewModel", x => x.BudgetID);
                    table.ForeignKey(
                        name: "FK_BudgetViewModel_AspNetUsers_ID",
                        column: x => x.ID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BudgetViewModel_ID",
                table: "BudgetViewModel",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BudgetViewModel");

        }
    }
}
