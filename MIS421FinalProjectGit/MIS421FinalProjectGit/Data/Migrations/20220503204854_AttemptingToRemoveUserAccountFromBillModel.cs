using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MIS421FinalProjectGit.Data.Migrations
{
    public partial class AttemptingToRemoveUserAccountFromBillModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bill_UserAccount_ID",
                table: "Bill");

            migrationBuilder.RenameColumn(
                name: "UserAccountID",
                table: "Bill",
                newName: "ApplicationUserID");

            migrationBuilder.AlterColumn<string>(
                name: "ID",
                table: "Bill",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bill_AspNetUsers_ID",
                table: "Bill",
                column: "ID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bill_AspNetUsers_ID",
                table: "Bill");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserID",
                table: "Bill",
                newName: "UserAccountID");

            migrationBuilder.AlterColumn<Guid>(
                name: "ID",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bill_UserAccount_ID",
                table: "Bill",
                column: "ID",
                principalTable: "UserAccount",
                principalColumn: "ID");
        }
    }
}
