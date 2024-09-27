using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestTecnico.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefectlength : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DefectLength",
                table: "Defects",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefectLength",
                table: "Defects");
        }
    }
}
