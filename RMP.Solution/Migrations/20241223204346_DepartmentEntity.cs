using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RMP.Host.Migrations
{
    /// <inheritdoc />
    public partial class DepartmentEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePhotoPath",
                table: "Departments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfilePhotoPath",
                table: "Departments",
                type: "TEXT",
                nullable: true);
        }
    }
}
