using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BBBWebApiCodeFirst.Migrations
{
    public partial class firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:postgis", "'postgis', '', ''");

            migrationBuilder.CreateTable(
                name: "Ages",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ages", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Days",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Days", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Mtcs",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    groesse = table.Column<int>(nullable: false),
                    geom = table.Column<Geometry>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mtcs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "MtcActivitys",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    zone = table.Column<long>(nullable: false),
                    day = table.Column<int>(nullable: false),
                    hour = table.Column<int>(nullable: false),
                    people = table.Column<int>(nullable: false),
                    density = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MtcActivitys", x => x.id);
                    table.ForeignKey(
                        name: "FK_MtcActivitys_Days_day",
                        column: x => x.day,
                        principalTable: "Days",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MtcActivitys_Mtcs_zone",
                        column: x => x.zone,
                        principalTable: "Mtcs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MtcAges",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    zone = table.Column<long>(nullable: false),
                    day = table.Column<int>(nullable: false),
                    hour = table.Column<int>(nullable: false),
                    age = table.Column<int>(nullable: false),
                    fraction = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MtcAges", x => x.id);
                    table.ForeignKey(
                        name: "FK_MtcAges_Ages_age",
                        column: x => x.age,
                        principalTable: "Ages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MtcAges_Days_day",
                        column: x => x.day,
                        principalTable: "Days",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MtcAges_Mtcs_zone",
                        column: x => x.zone,
                        principalTable: "Mtcs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MtcGenders",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    zone = table.Column<long>(nullable: false),
                    day = table.Column<int>(nullable: false),
                    hour = table.Column<int>(nullable: false),
                    gender = table.Column<int>(nullable: false),
                    fraction = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MtcGenders", x => x.id);
                    table.ForeignKey(
                        name: "FK_MtcGenders_Days_day",
                        column: x => x.day,
                        principalTable: "Days",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MtcGenders_Genders_gender",
                        column: x => x.gender,
                        principalTable: "Genders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MtcGenders_Mtcs_zone",
                        column: x => x.zone,
                        principalTable: "Mtcs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MtcHomezones",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    zone = table.Column<long>(nullable: false),
                    homezone = table.Column<long>(nullable: false),
                    day = table.Column<int>(nullable: false),
                    fraction = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MtcHomezones", x => x.id);
                    table.ForeignKey(
                        name: "FK_MtcHomezones_Days_day",
                        column: x => x.day,
                        principalTable: "Days",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MtcHomezones_Mtcs_zone",
                        column: x => x.zone,
                        principalTable: "Mtcs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MtcActivitys_day",
                table: "MtcActivitys",
                column: "day");

            migrationBuilder.CreateIndex(
                name: "IX_MtcActivitys_zone",
                table: "MtcActivitys",
                column: "zone");

            migrationBuilder.CreateIndex(
                name: "IX_MtcAges_age",
                table: "MtcAges",
                column: "age");

            migrationBuilder.CreateIndex(
                name: "IX_MtcAges_day",
                table: "MtcAges",
                column: "day");

            migrationBuilder.CreateIndex(
                name: "IX_MtcAges_zone",
                table: "MtcAges",
                column: "zone");

            migrationBuilder.CreateIndex(
                name: "IX_MtcGenders_day",
                table: "MtcGenders",
                column: "day");

            migrationBuilder.CreateIndex(
                name: "IX_MtcGenders_gender",
                table: "MtcGenders",
                column: "gender");

            migrationBuilder.CreateIndex(
                name: "IX_MtcGenders_zone",
                table: "MtcGenders",
                column: "zone");

            migrationBuilder.CreateIndex(
                name: "IX_MtcHomezones_day",
                table: "MtcHomezones",
                column: "day");

            migrationBuilder.CreateIndex(
                name: "IX_MtcHomezones_zone",
                table: "MtcHomezones",
                column: "zone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MtcActivitys");

            migrationBuilder.DropTable(
                name: "MtcAges");

            migrationBuilder.DropTable(
                name: "MtcGenders");

            migrationBuilder.DropTable(
                name: "MtcHomezones");

            migrationBuilder.DropTable(
                name: "Ages");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "Days");

            migrationBuilder.DropTable(
                name: "Mtcs");
        }
    }
}
