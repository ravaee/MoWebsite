using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mo.Portfolio.Website.Migrations
{
    /// <inheritdoc />
    public partial class Add_Summery_Group : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Summery",
                table: "Groups",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Summery",
                table: "Groups");
        }
    }
}
