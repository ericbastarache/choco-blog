using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace JwtApi.netcore.Migrations
{
    public partial class posts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PostModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Content = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Published = table.Column<bool>(nullable: false),
                    Slug = table.Column<string>(nullable: true),
                    Updated = table.Column<bool>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostModel_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CommentModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Content = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    PostId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentModel_PostModel_PostId",
                        column: x => x.PostId,
                        principalTable: "PostModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentModel_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentModel_PostId",
                table: "CommentModel",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentModel_UserId",
                table: "CommentModel",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostModel_UserId",
                table: "PostModel",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentModel");

            migrationBuilder.DropTable(
                name: "PostModel");
        }
    }
}
