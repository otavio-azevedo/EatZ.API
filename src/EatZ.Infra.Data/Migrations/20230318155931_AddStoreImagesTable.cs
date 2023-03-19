using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EatZ.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddStoreImagesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DESCRIPTION",
                table: "STORES",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "STORE_IMAGES",
                columns: table => new
                {
                    ID = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    STORE_ID = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    TITLE = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CONTENT = table.Column<byte[]>(type: "bytea", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STORE_IMAGES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_STORE_IMAGES",
                        column: x => x.STORE_ID,
                        principalTable: "STORES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_STORE_IMAGES_STORE_ID",
                table: "STORE_IMAGES",
                column: "STORE_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "STORE_IMAGES");

            migrationBuilder.DropColumn(
                name: "DESCRIPTION",
                table: "STORES");
        }
    }
}
