using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace espserver.Migrations
{
    /// <inheritdoc />
    public partial class refactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReleChannelDef");

            migrationBuilder.DropTable(
                name: "CahannelAdressDef");

            migrationBuilder.DropTable(
                name: "EspPortDef");

            migrationBuilder.CreateTable(
                name: "DeviceTypeDef",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DeviceType = table.Column<int>(type: "integer", nullable: false),
                    DeviceTypeDesc = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedUser = table.Column<string>(type: "text", nullable: false),
                    UpdatedUser = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceTypeDef", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceDef",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DeviceName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    DeviceCode = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    DeviceTypeId = table.Column<long>(type: "bigint", nullable: false),
                    DeviceAdressUrl = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedUser = table.Column<string>(type: "text", nullable: false),
                    UpdatedUser = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceDef", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeviceDef_DeviceTypeDef_DeviceTypeId",
                        column: x => x.DeviceTypeId,
                        principalTable: "DeviceTypeDef",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DevicePortDef",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PortNumber = table.Column<int>(type: "integer", nullable: false),
                    PortCode = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    PortDesc = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    DeviceId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedUser = table.Column<string>(type: "text", nullable: false),
                    UpdatedUser = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevicePortDef", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DevicePortDef_DeviceDef_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "DeviceDef",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeviceChannelDef",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DevicePortId = table.Column<long>(type: "bigint", nullable: false),
                    DeviceChannelNo = table.Column<int>(type: "integer", nullable: false),
                    DeviceChannelCode = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    DeviceChannelDesc = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedUser = table.Column<string>(type: "text", nullable: false),
                    UpdatedUser = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceChannelDef", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeviceChannelDef_DevicePortDef_DevicePortId",
                        column: x => x.DevicePortId,
                        principalTable: "DevicePortDef",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeviceChannelDef_DevicePortId",
                table: "DeviceChannelDef",
                column: "DevicePortId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceDef_DeviceTypeId",
                table: "DeviceDef",
                column: "DeviceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DevicePortDef_DeviceId",
                table: "DevicePortDef",
                column: "DeviceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeviceChannelDef");

            migrationBuilder.DropTable(
                name: "DevicePortDef");

            migrationBuilder.DropTable(
                name: "DeviceDef");

            migrationBuilder.DropTable(
                name: "DeviceTypeDef");

            migrationBuilder.CreateTable(
                name: "CahannelAdressDef",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ChannelAdressName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ChannelAdressUrl = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedUser = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedUser = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CahannelAdressDef", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EspPortDef",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedUser = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    PortDesc = table.Column<string>(type: "text", nullable: true),
                    PortKey = table.Column<string>(type: "text", nullable: true),
                    PortNumber = table.Column<int>(type: "integer", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedUser = table.Column<string>(type: "text", nullable: true)
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
                    CahannelAdressId = table.Column<long>(type: "bigint", nullable: true),
                    EspPortDefId = table.Column<long>(type: "bigint", nullable: false),
                    ChannelNo = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedUser = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    ReleChannelDesc = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    ReleChannelName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedUser = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReleChannelDef", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReleChannelDef_CahannelAdressDef_CahannelAdressId",
                        column: x => x.CahannelAdressId,
                        principalTable: "CahannelAdressDef",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReleChannelDef_EspPortDef_EspPortDefId",
                        column: x => x.EspPortDefId,
                        principalTable: "EspPortDef",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReleChannelDef_CahannelAdressId",
                table: "ReleChannelDef",
                column: "CahannelAdressId");

            migrationBuilder.CreateIndex(
                name: "IX_ReleChannelDef_EspPortDefId",
                table: "ReleChannelDef",
                column: "EspPortDefId");
        }
    }
}
