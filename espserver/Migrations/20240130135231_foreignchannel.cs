using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace espserver.Migrations
{
    /// <inheritdoc />
    public partial class foreignchannel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CahannelAdressId",
                table: "ReleChannelDef",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReleChannelDef_CahannelAdressId",
                table: "ReleChannelDef",
                column: "CahannelAdressId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReleChannelDef_CahannelAdressDef_CahannelAdressId",
                table: "ReleChannelDef",
                column: "CahannelAdressId",
                principalTable: "CahannelAdressDef",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReleChannelDef_CahannelAdressDef_CahannelAdressId",
                table: "ReleChannelDef");

            migrationBuilder.DropIndex(
                name: "IX_ReleChannelDef_CahannelAdressId",
                table: "ReleChannelDef");

            migrationBuilder.DropColumn(
                name: "CahannelAdressId",
                table: "ReleChannelDef");
        }
    }
}
