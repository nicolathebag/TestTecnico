using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestTecnico.Migrations
{
    /// <inheritdoc />
    public partial class AddedThresholds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Threshold4",
                table: "Thresholds",
                newName: "Threshold4Medium");

            migrationBuilder.RenameColumn(
                name: "Threshold3",
                table: "Thresholds",
                newName: "Threshold4Low");

            migrationBuilder.RenameColumn(
                name: "Threshold2",
                table: "Thresholds",
                newName: "Threshold4High");

            migrationBuilder.RenameColumn(
                name: "Threshold1",
                table: "Thresholds",
                newName: "Threshold3Medium");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "Threshold4Medium",
                table: "Thresholds",
                newName: "Threshold4");

            migrationBuilder.RenameColumn(
                name: "Threshold4Low",
                table: "Thresholds",
                newName: "Threshold3");

            migrationBuilder.RenameColumn(
                name: "Threshold4High",
                table: "Thresholds",
                newName: "Threshold2");

            migrationBuilder.RenameColumn(
                name: "Threshold3Medium",
                table: "Thresholds",
                newName: "Threshold1");
        }
    }
}
