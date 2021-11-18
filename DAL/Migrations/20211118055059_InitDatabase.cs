using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class InitDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "album",
                columns: table => new
                {
                    album_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    album_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    album_description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_album", x => x.album_id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    user_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    user_surname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    user_email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    user_nickname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    user_passwordhash = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "image",
                columns: table => new
                {
                    image_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    album_id = table.Column<long>(type: "bigint", nullable: false),
                    image_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    image_capture_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    image_captured_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    image_tags = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    geolocation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    other_metadata = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_image", x => x.image_id);
                    table.ForeignKey(
                        name: "FK_image_album_album_id",
                        column: x => x.album_id,
                        principalTable: "album",
                        principalColumn: "album_id");
                });

            migrationBuilder.CreateTable(
                name: "a_permission",
                columns: table => new
                {
                    i_permission_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    album_id = table.Column<long>(type: "bigint", maxLength: 100, nullable: false),
                    user_id = table.Column<long>(type: "bigint", maxLength: 100, nullable: false),
                    a_permission_type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_a_permission", x => x.i_permission_id);
                    table.ForeignKey(
                        name: "FK_a_permission_album_album_id",
                        column: x => x.album_id,
                        principalTable: "album",
                        principalColumn: "album_id");
                    table.ForeignKey(
                        name: "FK_a_permission_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "i_permission",
                columns: table => new
                {
                    i_permission_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    image_id = table.Column<long>(type: "bigint", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    i_permission_type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_i_permission", x => x.i_permission_id);
                    table.ForeignKey(
                        name: "FK_i_permission_image_image_id",
                        column: x => x.image_id,
                        principalTable: "image",
                        principalColumn: "image_id");
                    table.ForeignKey(
                        name: "FK_i_permission_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_a_permission_album_id",
                table: "a_permission",
                column: "album_id");

            migrationBuilder.CreateIndex(
                name: "IX_a_permission_user_id",
                table: "a_permission",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_i_permission_image_id",
                table: "i_permission",
                column: "image_id");

            migrationBuilder.CreateIndex(
                name: "IX_i_permission_user_id",
                table: "i_permission",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_image_album_id",
                table: "image",
                column: "album_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "a_permission");

            migrationBuilder.DropTable(
                name: "i_permission");

            migrationBuilder.DropTable(
                name: "image");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "album");
        }
    }
}
