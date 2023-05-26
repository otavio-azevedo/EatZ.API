using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EatZ.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AlterOffersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QUANTITY",
                table: "STORE_OFFERS",
                newName: "INIT_QUANTITY");

            migrationBuilder.AddColumn<int>(
                name: "QUANTITY_AVAIBLE",
                table: "STORE_OFFERS",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "INIT_QUANTITY",
                table: "STORE_OFFERS");

            migrationBuilder.RenameColumn(
                name: "INIT_QUANTITY",
                table: "STORE_OFFERS",
                newName: "QUANTITY");
        }
    }
}
