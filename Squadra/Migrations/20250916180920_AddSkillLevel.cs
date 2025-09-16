using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Squadra.Migrations
{
    /// <inheritdoc />
    public partial class AddSkillLevel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SkillLevel",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RequiredLevel",
                table: "Matches",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SkillLevel",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RequiredLevel",
                table: "Matches");
        }
    }
}
