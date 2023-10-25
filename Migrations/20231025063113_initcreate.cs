using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleAppEFwoensdagCRUD.Migrations
{
    /// <inheritdoc />
    public partial class initcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Auteurs",
                columns: table => new
                {
                    AuteurID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auteurs", x => x.AuteurID);
                });

            migrationBuilder.CreateTable(
                name: "Reeksen",
                columns: table => new
                {
                    ReeksID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reeksen", x => x.ReeksID);
                });

            migrationBuilder.CreateTable(
                name: "Uitgeverijen",
                columns: table => new
                {
                    UitgeverijID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uitgeverijen", x => x.UitgeverijID);
                });

            migrationBuilder.CreateTable(
                name: "Strips",
                columns: table => new
                {
                    StripID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nr = table.Column<int>(type: "int", nullable: false),
                    Titel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UitgeverijID = table.Column<int>(type: "int", nullable: false),
                    ReeksID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Strips", x => x.StripID);
                    table.ForeignKey(
                        name: "FK_Strips_Reeksen_ReeksID",
                        column: x => x.ReeksID,
                        principalTable: "Reeksen",
                        principalColumn: "ReeksID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Strips_Uitgeverijen_UitgeverijID",
                        column: x => x.UitgeverijID,
                        principalTable: "Uitgeverijen",
                        principalColumn: "UitgeverijID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuteurStrip",
                columns: table => new
                {
                    AuteursAuteurID = table.Column<int>(type: "int", nullable: false),
                    StripsStripID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuteurStrip", x => new { x.AuteursAuteurID, x.StripsStripID });
                    table.ForeignKey(
                        name: "FK_AuteurStrip_Auteurs_AuteursAuteurID",
                        column: x => x.AuteursAuteurID,
                        principalTable: "Auteurs",
                        principalColumn: "AuteurID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuteurStrip_Strips_StripsStripID",
                        column: x => x.StripsStripID,
                        principalTable: "Strips",
                        principalColumn: "StripID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuteurStrip_StripsStripID",
                table: "AuteurStrip",
                column: "StripsStripID");

            migrationBuilder.CreateIndex(
                name: "IX_Strips_ReeksID",
                table: "Strips",
                column: "ReeksID");

            migrationBuilder.CreateIndex(
                name: "IX_Strips_UitgeverijID",
                table: "Strips",
                column: "UitgeverijID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuteurStrip");

            migrationBuilder.DropTable(
                name: "Auteurs");

            migrationBuilder.DropTable(
                name: "Strips");

            migrationBuilder.DropTable(
                name: "Reeksen");

            migrationBuilder.DropTable(
                name: "Uitgeverijen");
        }
    }
}
