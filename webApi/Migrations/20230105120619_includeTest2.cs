using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webApi.Migrations
{
    public partial class includeTest2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestEntityOnes_TestEntityTwo_EntityTwoId",
                table: "TestEntityOnes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestEntityOnes",
                table: "TestEntityOnes");

            migrationBuilder.RenameTable(
                name: "TestEntityOnes",
                newName: "EntityOnes");

            migrationBuilder.RenameIndex(
                name: "IX_TestEntityOnes_EntityTwoId",
                table: "EntityOnes",
                newName: "IX_EntityOnes_EntityTwoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EntityOnes",
                table: "EntityOnes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EntityOnes_TestEntityTwo_EntityTwoId",
                table: "EntityOnes",
                column: "EntityTwoId",
                principalTable: "TestEntityTwo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntityOnes_TestEntityTwo_EntityTwoId",
                table: "EntityOnes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EntityOnes",
                table: "EntityOnes");

            migrationBuilder.RenameTable(
                name: "EntityOnes",
                newName: "TestEntityOnes");

            migrationBuilder.RenameIndex(
                name: "IX_EntityOnes_EntityTwoId",
                table: "TestEntityOnes",
                newName: "IX_TestEntityOnes_EntityTwoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestEntityOnes",
                table: "TestEntityOnes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TestEntityOnes_TestEntityTwo_EntityTwoId",
                table: "TestEntityOnes",
                column: "EntityTwoId",
                principalTable: "TestEntityTwo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
