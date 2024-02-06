using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace espserver.Migrations
{
    /// <inheritdoc />
    public partial class countadd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IOPortType",
                table: "DevicePortDef",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalIOPortCount",
                table: "DeviceDef",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IOPortType",
                table: "DevicePortDef");

            migrationBuilder.DropColumn(
                name: "TotalIOPortCount",
                table: "DeviceDef");
        }
    }
}
