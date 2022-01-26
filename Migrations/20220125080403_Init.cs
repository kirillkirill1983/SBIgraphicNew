using Microsoft.EntityFrameworkCore.Migrations;

namespace SBIgraphic.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plavka",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomerPlavki = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomerShtuki = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plavka", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZamerHirinas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Shirina = table.Column<double>(type: "float", nullable: false),
                    PlavkaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZamerHirinas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ZamerHirinas_Plavka_PlavkaId",
                        column: x => x.PlavkaId,
                        principalTable: "Plavka",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ZamerTolchinas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tolshina = table.Column<double>(type: "float", nullable: false),
                    PlavkaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZamerTolchinas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ZamerTolchinas_Plavka_PlavkaId",
                        column: x => x.PlavkaId,
                        principalTable: "Plavka",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ZamerHirinas_PlavkaId",
                table: "ZamerHirinas",
                column: "PlavkaId");

            migrationBuilder.CreateIndex(
                name: "IX_ZamerTolchinas_PlavkaId",
                table: "ZamerTolchinas",
                column: "PlavkaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZamerHirinas");

            migrationBuilder.DropTable(
                name: "ZamerTolchinas");

            migrationBuilder.DropTable(
                name: "Plavka");
        }
    }
}
