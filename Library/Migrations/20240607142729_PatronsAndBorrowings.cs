using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class PatronsAndBorrowings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BorrowingId",
                table: "Books",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Patrons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patrons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Borrowings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PatronId = table.Column<Guid>(type: "TEXT", nullable: false),
                    BorrowedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DueDateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borrowings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Borrowings_Patrons_PatronId",
                        column: x => x.PatronId,
                        principalTable: "Patrons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_BorrowingId",
                table: "Books",
                column: "BorrowingId");

            migrationBuilder.CreateIndex(
                name: "IX_Borrowings_PatronId",
                table: "Borrowings",
                column: "PatronId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Borrowings_BorrowingId",
                table: "Books",
                column: "BorrowingId",
                principalTable: "Borrowings",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Borrowings_BorrowingId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "Borrowings");

            migrationBuilder.DropTable(
                name: "Patrons");

            migrationBuilder.DropIndex(
                name: "IX_Books_BorrowingId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BorrowingId",
                table: "Books");
        }
    }
}
