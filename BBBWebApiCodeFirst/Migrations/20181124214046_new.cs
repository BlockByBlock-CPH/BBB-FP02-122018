using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BBBWebApiCodeFirst.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:postgis", "'postgis', '', ''");

            migrationBuilder.CreateTable(
                name: "Dayss",
                columns: table => new
                {
                    IdDay = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    NameDay = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dayss", x => x.IdDay);
                });

            migrationBuilder.CreateTable(
                name: "Mtcs",
                columns: table => new
                {
                    Gid = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Id = table.Column<decimal>(nullable: true),
                    Groesse = table.Column<decimal>(nullable: true),
                    Geom = table.Column<Geometry>(nullable: true),
                    Area = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mtcs", x => x.Gid);
                });

            migrationBuilder.CreateTable(
                name: "MtcActivitys",
                columns: table => new
                {
                    IdAct = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ZoneAct = table.Column<int>(nullable: false),
                    CountAct = table.Column<long>(nullable: false),
                    HoursAct = table.Column<int>(nullable: false),
                    DaysAct = table.Column<int>(nullable: false),
                    Density = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MtcActivitys", x => x.IdAct);
                    table.ForeignKey(
                        name: "FK_MtcActivitys_Dayss_DaysAct",
                        column: x => x.DaysAct,
                        principalTable: "Dayss",
                        principalColumn: "IdDay",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MtcActivitys_Mtcs_ZoneAct",
                        column: x => x.ZoneAct,
                        principalTable: "Mtcs",
                        principalColumn: "Gid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MtcHomezones",
                columns: table => new
                {
                    IdHz = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ZoneHz = table.Column<int>(nullable: false),
                    HomeHz = table.Column<int>(nullable: false),
                    DaysHz = table.Column<int>(nullable: false),
                    SharedHz = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MtcHomezones", x => x.IdHz);
                    table.ForeignKey(
                        name: "FK_MtcHomezones_Mtcs_HomeHz",
                        column: x => x.HomeHz,
                        principalTable: "Mtcs",
                        principalColumn: "Gid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MtcActivitys_DaysAct",
                table: "MtcActivitys",
                column: "DaysAct");

            migrationBuilder.CreateIndex(
                name: "IX_MtcActivitys_ZoneAct",
                table: "MtcActivitys",
                column: "ZoneAct");

            migrationBuilder.CreateIndex(
                name: "IX_MtcHomezones_HomeHz",
                table: "MtcHomezones",
                column: "HomeHz");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MtcActivitys");

            migrationBuilder.DropTable(
                name: "MtcHomezones");

            migrationBuilder.DropTable(
                name: "Dayss");

            migrationBuilder.DropTable(
                name: "Mtcs");
        }
    }
}
