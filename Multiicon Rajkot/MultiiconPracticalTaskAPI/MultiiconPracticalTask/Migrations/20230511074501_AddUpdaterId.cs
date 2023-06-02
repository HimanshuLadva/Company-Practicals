using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiiconPracticalTask.Migrations
{
    public partial class AddUpdaterId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UpdaterId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdaterId",
                table: "Books");
        }
    }
}
