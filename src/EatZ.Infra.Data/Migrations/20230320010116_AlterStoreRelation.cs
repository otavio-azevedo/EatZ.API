using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EatZ.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AlterStoreRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CITY",
                table: "STORES");

            migrationBuilder.DropColumn(
                name: "COUNTRY",
                table: "STORES");

            migrationBuilder.DropColumn(
                name: "STATE",
                table: "STORES");

            migrationBuilder.AddColumn<long>(
                name: "CITY_ID",
                table: "STORES",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_STORES_CITY_ID",
                table: "STORES",
                column: "CITY_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CITIES_STORE_ID",
                table: "STORES",
                column: "CITY_ID",
                principalTable: "CITIES",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CITIES_STORE_ID",
                table: "STORES");

            migrationBuilder.DropIndex(
                name: "IX_STORES_CITY_ID",
                table: "STORES");

            migrationBuilder.DropColumn(
                name: "CITY_ID",
                table: "STORES");

            migrationBuilder.AddColumn<string>(
                name: "CITY",
                table: "STORES",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "COUNTRY",
                table: "STORES",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "STATE",
                table: "STORES",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
