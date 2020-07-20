using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Hash = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Hash);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Hash = table.Column<string>(nullable: false),
                    Level = table.Column<int>(type: "INT(1)", nullable: false),
                    Event = table.Column<int>(type: "INT(3)", nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    Origin = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    Details = table.Column<string>(type: "TEXT", nullable: false),
                    UserHash = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Hash);
                    table.ForeignKey(
                        name: "FK_Logs_Users_UserHash",
                        column: x => x.UserHash,
                        principalTable: "Users",
                        principalColumn: "Hash",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Logs_UserHash",
                table: "Logs",
                column: "UserHash");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
