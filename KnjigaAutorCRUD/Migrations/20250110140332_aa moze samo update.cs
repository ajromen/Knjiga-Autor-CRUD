using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace KnjigaAutorCRUD.Migrations
{
    /// <inheritdoc />
    public partial class aamozesamoupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IzdavacId",
                table: "Knjige",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Izdavaci",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ime = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Izdavaci", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Knjige_IzdavacId",
                table: "Knjige",
                column: "IzdavacId");

            migrationBuilder.AddForeignKey(
                name: "FK_Knjige_Izdavaci_IzdavacId",
                table: "Knjige",
                column: "IzdavacId",
                principalTable: "Izdavaci",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Knjige_Izdavaci_IzdavacId",
                table: "Knjige");

            migrationBuilder.DropTable(
                name: "Izdavaci");

            migrationBuilder.DropIndex(
                name: "IX_Knjige_IzdavacId",
                table: "Knjige");

            migrationBuilder.DropColumn(
                name: "IzdavacId",
                table: "Knjige");
        }
    }
}
