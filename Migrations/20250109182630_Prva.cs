using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KnjigaAutorCRUD.Migrations
{
    /// <inheritdoc />
    public partial class Prva : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Opis",
                table: "Knjige");

            migrationBuilder.AddColumn<int>(
                name: "GodinaIzdanja",
                table: "Knjige",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GodinaIzdanja",
                table: "Knjige");

            migrationBuilder.AddColumn<string>(
                name: "Opis",
                table: "Knjige",
                type: "text",
                nullable: true);
        }
    }
}
