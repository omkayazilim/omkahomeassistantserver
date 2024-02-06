using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace espserver.Migrations
{
    /// <inheritdoc />
    public partial class foreignkeydelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CahannelAdressDef_ReleChannelDef_ChannelDefId",
                table: "CahannelAdressDef");

            migrationBuilder.DropIndex(
                name: "IX_CahannelAdressDef_ChannelDefId",
                table: "CahannelAdressDef");

            migrationBuilder.DropColumn(
                name: "ChannelDefId",
                table: "CahannelAdressDef");

            migrationBuilder.RenameColumn(
                name: "ChannelAdrtessUrl",
                table: "CahannelAdressDef",
                newName: "ChannelAdressUrl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ChannelAdressUrl",
                table: "CahannelAdressDef",
                newName: "ChannelAdrtessUrl");

            migrationBuilder.AddColumn<long>(
                name: "ChannelDefId",
                table: "CahannelAdressDef",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_CahannelAdressDef_ChannelDefId",
                table: "CahannelAdressDef",
                column: "ChannelDefId");

            migrationBuilder.AddForeignKey(
                name: "FK_CahannelAdressDef_ReleChannelDef_ChannelDefId",
                table: "CahannelAdressDef",
                column: "ChannelDefId",
                principalTable: "ReleChannelDef",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
