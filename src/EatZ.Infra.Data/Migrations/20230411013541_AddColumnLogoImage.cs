using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EatZ.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnLogoImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "LOGO_IMAGE",
                table: "STORES",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LOGO_IMAGE",
                table: "STORES");
        }
    }
}
