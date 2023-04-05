using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EatZ.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddReviewsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "REVIEWS",
                columns: table => new
                {
                    ID = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    ORDER_ID = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    COMMENT = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    RATING = table.Column<short>(type: "smallint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REVIEWS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_REVIEW_ORDER",
                        column: x => x.ORDER_ID,
                        principalTable: "ORDERS",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_REVIEWS_ORDER_ID",
                table: "REVIEWS",
                column: "ORDER_ID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "REVIEWS");
        }
    }
}
