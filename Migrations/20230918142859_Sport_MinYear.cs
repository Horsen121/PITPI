using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace task4.Migrations
{
    /// <inheritdoc />
    public partial class Sport_MinYear : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "min_year",
                table: "sport",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "min_year",
                table: "sport");
        }
    }
}
