using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MIS421FinalProjectGit.Data.Migrations
{
    public partial class AttemptingToRemoveUserAccountFromTransactionModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_UserAccount_ID",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "UserAccountID",
                table: "Transactions",
                newName: "ApplicationUserID");

            migrationBuilder.AlterColumn<string>(
                name: "ID",
                table: "Transactions",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_AspNetUsers_ID",
                table: "Transactions",
                column: "ID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_AspNetUsers_ID",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserID",
                table: "Transactions",
                newName: "UserAccountID");

            migrationBuilder.AlterColumn<Guid>(
                name: "ID",
                table: "Transactions",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_UserAccount_ID",
                table: "Transactions",
                column: "ID",
                principalTable: "UserAccount",
                principalColumn: "ID");
        }
    }
}
