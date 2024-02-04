using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mo.Portfolio.Website.Migrations
{
    /// <inheritdoc />
    public partial class Add_Group_Name : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Groups",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Groups");
        }
    }
}
