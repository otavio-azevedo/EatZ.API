using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EatZ.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddStoreOffersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "STORE_OFFERS",
                columns: table => new
                {
                    ID = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    STORE_ID = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    DESCRIPTION = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    NET_UNIT_PRICE = table.Column<decimal>(type: "numeric", nullable: false),
                    GROSS_UNIT_PRICE = table.Column<decimal>(type: "numeric", nullable: false),
                    QUANTITY = table.Column<int>(type: "integer", nullable: false),
                    TASTE = table.Column<int>(type: "integer", nullable: false),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EXPIRATION_DATE = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PICK_UP_DATE = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STORE_OFFERS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_STORE_OFFERS",
                        column: x => x.STORE_ID,
                        principalTable: "STORES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_STORE_OFFERS_STORE_ID",
                table: "STORE_OFFERS",
                column: "STORE_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "STORE_OFFERS");
        }
    }
}
