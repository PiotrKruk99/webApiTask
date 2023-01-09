using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webApi.Migrations
{
    public partial class includetest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TestEntityTwo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Value1 = table.Column<string>(type: "TEXT", nullable: false),
                    Value2 = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestEntityTwo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestEntityOnes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Value1 = table.Column<string>(type: "TEXT", nullable: false),
                    Value2 = table.Column<string>(type: "TEXT", nullable: false),
                    EntityTwoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestEntityOnes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestEntityOnes_TestEntityTwo_EntityTwoId",
                        column: x => x.EntityTwoId,
                        principalTable: "TestEntityTwo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestEntityOnes_EntityTwoId",
                table: "TestEntityOnes",
                column: "EntityTwoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestEntityOnes");

            migrationBuilder.DropTable(
                name: "TestEntityTwo");
        }
    }
}
