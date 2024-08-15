using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI_First.Migrations
{
    /// <inheritdoc />
    public partial class AddHinh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Hinh",
                table: "HangHoa",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hinh",
                table: "HangHoa");
        }
    }
}
