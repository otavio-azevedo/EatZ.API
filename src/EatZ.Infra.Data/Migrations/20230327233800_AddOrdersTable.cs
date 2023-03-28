using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EatZ.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddOrdersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ORDERS",
                columns: table => new
                {
                    ID = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    STORE_ID = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    CLIENT_USER_ID = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    OFFER_ID = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CONFIRMATION_DATE = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    PICK_UP_DATE = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    STATUS = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDERS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ORDERS_CLIENT",
                        column: x => x.CLIENT_USER_ID,
                        principalTable: "USERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ORDERS_OFFER",
                        column: x => x.OFFER_ID,
                        principalTable: "STORE_OFFERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ORDERS_STORE",
                        column: x => x.STORE_ID,
                        principalTable: "STORES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ORDERS_CLIENT_USER_ID",
                table: "ORDERS",
                column: "CLIENT_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERS_OFFER_ID",
                table: "ORDERS",
                column: "OFFER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERS_STORE_ID",
                table: "ORDERS",
                column: "STORE_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ORDERS");
        }
    }
}
