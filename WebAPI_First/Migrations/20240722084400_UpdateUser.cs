using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI_First.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Passworkd",
                table: "NguoiDung",
                newName: "Password");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "NguoiDung",
                newName: "Passworkd");
        }
    }
}
