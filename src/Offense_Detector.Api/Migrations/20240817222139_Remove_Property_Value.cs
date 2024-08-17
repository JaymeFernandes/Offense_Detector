using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Offense_Detector.Migrations
{
    /// <inheritdoc />
    public partial class Remove_Property_Value : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "_offenses");

            migrationBuilder.RenameColumn(
                name: "OffenseValue",
                table: "_falsePositives",
                newName: "Word");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Word",
                table: "_falsePositives",
                newName: "OffenseValue");

            migrationBuilder.AddColumn<int>(
                name: "Value",
                table: "_offenses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
