using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace URLShortener.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShortURLs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ShortUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Clicks = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShortURLs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShortURLs_Url",
                table: "ShortURLs",
                column: "Url",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShortURLs");
        }
    }
}
