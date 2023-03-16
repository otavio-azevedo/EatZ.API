using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EatZ.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddStoreTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "USERS",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.CreateTable(
                name: "STORES",
                columns: table => new
                {
                    ID = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    NAME = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DOCUMENT_NUMBER = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    PHONE = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    ZIP_CODE = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    COUNTRY = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    STATE = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CITY = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    NEIGHBORHOOD = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    STREET = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    STREET_NUMBER = table.Column<int>(type: "integer", nullable: false),
                    COMPLEMENT = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    ADMIN_ID = table.Column<string>(type: "text", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STORES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_USERS_STORE_ID",
                        column: x => x.ADMIN_ID,
                        principalTable: "USERS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_STORES_ADMIN_ID",
                table: "STORES",
                column: "ADMIN_ID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "STORES");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "USERS",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");
        }
    }
}
