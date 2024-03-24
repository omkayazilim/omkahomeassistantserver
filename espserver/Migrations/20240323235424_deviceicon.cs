using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace espserver.Migrations
{
    /// <inheritdoc />
    public partial class deviceicon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeviceChannelIcon",
                table: "DeviceChannelDef",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeviceChannelIcon",
                table: "DeviceChannelDef");
        }
    }
}
