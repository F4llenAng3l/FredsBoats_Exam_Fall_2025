using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FredsBoats.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddComments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "comment",
                columns: table => new
                {
                    commentid = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    content = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    author = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    createdat = table.Column<DateTime>(type: "TEXT", nullable: false),
                    boatid = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comment", x => x.commentid);
                    table.ForeignKey(
                        name: "FK_comment_boat_boatid",
                        column: x => x.boatid,
                        principalTable: "boat",
                        principalColumn: "boatid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_comment_boatid",
                table: "comment",
                column: "boatid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comment");
        }
    }
}
