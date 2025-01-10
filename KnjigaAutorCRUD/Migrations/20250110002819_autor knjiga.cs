using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KnjigaAutorCRUD.Migrations
{
    /// <inheritdoc />
    public partial class autorknjiga : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AutoriKnjige",
                columns: table => new
                {
                    KnjigaId = table.Column<int>(type: "integer", nullable: false),
                    AutorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoriKnjige", x => new { x.KnjigaId, x.AutorId });
                    table.ForeignKey(
                        name: "FK_AutoriKnjige_Autori_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Autori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AutoriKnjige_Knjige_KnjigaId",
                        column: x => x.KnjigaId,
                        principalTable: "Knjige",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutoriKnjige_AutorId",
                table: "AutoriKnjige",
                column: "AutorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutoriKnjige");
        }
    }
}
