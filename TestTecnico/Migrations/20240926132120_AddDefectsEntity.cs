using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestTecnico.Migrations
{
    /// <inheritdoc />
    public partial class AddDefectsEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Threshold1High",
                table: "Thresholds");

            migrationBuilder.DropColumn(
                name: "Threshold1Low",
                table: "Thresholds");

            migrationBuilder.DropColumn(
                name: "Threshold1Medium",
                table: "Thresholds");

            migrationBuilder.DropColumn(
                name: "Threshold2High",
                table: "Thresholds");

            migrationBuilder.DropColumn(
                name: "Threshold2Low",
                table: "Thresholds");

            migrationBuilder.DropColumn(
                name: "Threshold2Medium",
                table: "Thresholds");

            migrationBuilder.DropColumn(
                name: "Threshold3High",
                table: "Thresholds");

            migrationBuilder.DropColumn(
                name: "Threshold3Low",
                table: "Thresholds");

            migrationBuilder.DropColumn(
                name: "Threshold3Medium",
                table: "Thresholds");

            migrationBuilder.DropColumn(
                name: "Threshold4High",
                table: "Thresholds");

            migrationBuilder.DropColumn(
                name: "Threshold4Low",
                table: "Thresholds");

            migrationBuilder.DropColumn(
                name: "Threshold4Medium",
                table: "Thresholds");

            migrationBuilder.AddColumn<string>(
                name: "Level",
                table: "Thresholds",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Value",
                table: "Thresholds",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "Defects",
                columns: table => new
                {
                    DefectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Delta = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Defects", x => x.DefectId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Defects");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Thresholds");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Thresholds");

            migrationBuilder.AddColumn<int>(
                name: "Threshold1High",
                table: "Thresholds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Threshold1Low",
                table: "Thresholds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Threshold1Medium",
                table: "Thresholds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Threshold2High",
                table: "Thresholds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Threshold2Low",
                table: "Thresholds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Threshold2Medium",
                table: "Thresholds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Threshold3High",
                table: "Thresholds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Threshold3Low",
                table: "Thresholds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Threshold3Medium",
                table: "Thresholds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Threshold4High",
                table: "Thresholds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Threshold4Low",
                table: "Thresholds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Threshold4Medium",
                table: "Thresholds",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
