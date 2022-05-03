using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MIS421FinalProjectGit.Data.Migrations
{
    public partial class AttemptingToRemoveUserAccountFromInvestmentModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Investments_UserAccount_ID",
                table: "Investments");

            migrationBuilder.RenameColumn(
                name: "UserAccountID",
                table: "Investments",
                newName: "ApplicationUserID");

            migrationBuilder.AlterColumn<string>(
                name: "ID",
                table: "Investments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Investments_AspNetUsers_ID",
                table: "Investments",
                column: "ID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Investments_AspNetUsers_ID",
                table: "Investments");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserID",
                table: "Investments",
                newName: "UserAccountID");

            migrationBuilder.AlterColumn<Guid>(
                name: "ID",
                table: "Investments",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Investments_UserAccount_ID",
                table: "Investments",
                column: "ID",
                principalTable: "UserAccount",
                principalColumn: "ID");
        }
    }
}
