using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Todo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    IsComplete = table.Column<bool>(type: "INTEGER", nullable: false),
                    Secret = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todo", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Todo",
                columns: new[] { "Id", "IsComplete", "Name", "Secret" },
                values: new object[] { 1L, true, "Feed the cat", null });

            migrationBuilder.InsertData(
                table: "Todo",
                columns: new[] { "Id", "IsComplete", "Name", "Secret" },
                values: new object[] { 2L, false, "Buy dinner", null });

            migrationBuilder.InsertData(
                table: "Todo",
                columns: new[] { "Id", "IsComplete", "Name", "Secret" },
                values: new object[] { 3L, false, "Do the dishes", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Todo");
        }
    }
}
