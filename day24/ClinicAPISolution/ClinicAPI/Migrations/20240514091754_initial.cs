using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    speciality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    experience = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "id", "experience", "name", "speciality" },
                values: new object[] { 101, 5, "Ramu", "brain" });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "id", "experience", "name", "speciality" },
                values: new object[] { 102, 2, "Somu", "hand" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctors");
        }
    }
}
