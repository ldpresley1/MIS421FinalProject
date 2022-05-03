using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MIS421FinalProjectGit.Data.Migrations
{
    public partial class AttemptingToRemoveUserAccountFromBudgetModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Budget_UserAccount_ID",
                table: "Budget");

            migrationBuilder.RenameColumn(
                name: "UserAccountID",
                table: "Budget",
                newName: "ApplicationUserID");

            migrationBuilder.AlterColumn<string>(
                name: "ID",
                table: "Budget",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Budget_AspNetUsers_ID",
                table: "Budget",
                column: "ID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Budget_AspNetUsers_ID",
                table: "Budget");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserID",
                table: "Budget",
                newName: "UserAccountID");

            migrationBuilder.AlterColumn<Guid>(
                name: "ID",
                table: "Budget",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Budget_UserAccount_ID",
                table: "Budget",
                column: "ID",
                principalTable: "UserAccount",
                principalColumn: "ID");
        }
    }
}
