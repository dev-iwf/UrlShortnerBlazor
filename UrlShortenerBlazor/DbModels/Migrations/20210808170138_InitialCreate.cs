using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UrlShortenerBlazor.DbModels.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShortenedUrls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullUrl = table.Column<string>(type: "TEXT", nullable: false),
                    Short = table.Column<string>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShortenedUrls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UrlVisit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ShortenedUrlId = table.Column<int>(type: "INTEGER", nullable: false),
                    VisitedBy = table.Column<string>(type: "TEXT", nullable: true),
                    VisitedOn = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrlVisit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UrlVisit_ShortenedUrls_ShortenedUrlId",
                        column: x => x.ShortenedUrlId,
                        principalTable: "ShortenedUrls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShortenedUrls_FullUrl",
                table: "ShortenedUrls",
                column: "FullUrl",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShortenedUrls_Short",
                table: "ShortenedUrls",
                column: "Short",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UrlVisit_ShortenedUrlId",
                table: "UrlVisit",
                column: "ShortenedUrlId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UrlVisit");

            migrationBuilder.DropTable(
                name: "ShortenedUrls");
        }
    }
}
