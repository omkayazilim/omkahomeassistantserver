using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace espserver.Migrations
{
    /// <inheritdoc />
    public partial class dbinit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EspPortDef",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PortNumber = table.Column<int>(type: "integer", nullable: false),
                    PortKey = table.Column<string>(type: "text", nullable: true),
                    PortDesc = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedUser = table.Column<string>(type: "text", nullable: false),
                    UpdatedUser = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EspPortDef", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReleChannelDef",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EspPortDefId = table.Column<long>(type: "bigint", nullable: false),
                    ReleChannelName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    ReleChannelDesc = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    ChannelNo = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedUser = table.Column<string>(type: "text", nullable: false),
                    UpdatedUser = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReleChannelDef", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReleChannelDef_EspPortDef_EspPortDefId",
                        column: x => x.EspPortDefId,
                        principalTable: "EspPortDef",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReleChannelDef_EspPortDefId",
                table: "ReleChannelDef",
                column: "EspPortDefId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReleChannelDef");

            migrationBuilder.DropTable(
                name: "EspPortDef");
        }
    }
}
