using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MIS421FinalProjectGit.Data.Migrations
{
    public partial class AddeddMyTransactionModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.CreateTable(
                name: "MyTransaction",
                columns: table => new
                {
                    TransactionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationUserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyTransaction", x => x.TransactionID);
                    table.ForeignKey(
                        name: "FK_MyTransaction_AspNetUsers_ID",
                        column: x => x.ID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MyTransaction_ID",
                table: "MyTransaction",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyTransaction");

           
        }
    }
}
