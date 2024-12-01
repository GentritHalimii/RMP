using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RMP.Host.Migrations
{
    /// <inheritdoc />
    public partial class UniversityEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Universities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    EstablishedYear = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    StaffNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentsNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    CoursesNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    ProfilePhotoPath = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universities", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Universities");
        }
    }
}
