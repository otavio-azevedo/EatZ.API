using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EatZ.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddGeoTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "COUNTRIES",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NAME = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ACRONYM = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COUNTRIES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "STATES",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    COUNTRY_ID = table.Column<long>(type: "bigint", nullable: false),
                    NAME = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ACRONYM = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STATES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_STATE_COUNTRY",
                        column: x => x.COUNTRY_ID,
                        principalTable: "COUNTRIES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CITIES",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    STATE_ID = table.Column<long>(type: "bigint", nullable: false),
                    NAME = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LATITUDE = table.Column<double>(type: "double precision", nullable: false),
                    LONGITUDE = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CITIES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CITY_STATE",
                        column: x => x.STATE_ID,
                        principalTable: "STATES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CITIES_STATE_ID",
                table: "CITIES",
                column: "STATE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_STATES_COUNTRY_ID",
                table: "STATES",
                column: "COUNTRY_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CITIES");

            migrationBuilder.DropTable(
                name: "STATES");

            migrationBuilder.DropTable(
                name: "COUNTRIES");
        }
    }
}
