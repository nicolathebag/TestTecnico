using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestTecnico.Migrations
{
    /// <inheritdoc />
    public partial class AlterColumnNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Parameter4",
                table: "Measures",
                newName: "p4");

            migrationBuilder.RenameColumn(
                name: "Parameter3",
                table: "Measures",
                newName: "p3");

            migrationBuilder.RenameColumn(
                name: "Parameter2",
                table: "Measures",
                newName: "p2");

            migrationBuilder.RenameColumn(
                name: "Parameter1",
                table: "Measures",
                newName: "p1");

            migrationBuilder.AlterColumn<int>(
                name: "MeasureId",
                table: "Measures",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "p4",
                table: "Measures",
                newName: "Parameter4");

            migrationBuilder.RenameColumn(
                name: "p3",
                table: "Measures",
                newName: "Parameter3");

            migrationBuilder.RenameColumn(
                name: "p2",
                table: "Measures",
                newName: "Parameter2");

            migrationBuilder.RenameColumn(
                name: "p1",
                table: "Measures",
                newName: "Parameter1");

            migrationBuilder.AlterColumn<long>(
                name: "MeasureId",
                table: "Measures",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }
    }
}
