using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace JwtApi.netcore.Migrations
{
    public partial class postupdate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentModel_PostModel_PostId",
                table: "CommentModel");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentModel_AspNetUsers_UserId",
                table: "CommentModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PostModel_AspNetUsers_UserId",
                table: "PostModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostModel",
                table: "PostModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommentModel",
                table: "CommentModel");

            migrationBuilder.RenameTable(
                name: "PostModel",
                newName: "Posts");

            migrationBuilder.RenameTable(
                name: "CommentModel",
                newName: "Comments");

            migrationBuilder.RenameIndex(
                name: "IX_PostModel_UserId",
                table: "Posts",
                newName: "IX_Posts_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CommentModel_UserId",
                table: "Comments",
                newName: "IX_Comments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CommentModel_PostId",
                table: "Comments",
                newName: "IX_Comments_PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posts",
                table: "Posts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_PostId",
                table: "Comments",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_UserId",
                table: "Posts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_PostId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_UserId",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Posts",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.RenameTable(
                name: "Posts",
                newName: "PostModel");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "CommentModel");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_UserId",
                table: "PostModel",
                newName: "IX_PostModel_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_UserId",
                table: "CommentModel",
                newName: "IX_CommentModel_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_PostId",
                table: "CommentModel",
                newName: "IX_CommentModel_PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostModel",
                table: "PostModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommentModel",
                table: "CommentModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentModel_PostModel_PostId",
                table: "CommentModel",
                column: "PostId",
                principalTable: "PostModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentModel_AspNetUsers_UserId",
                table: "CommentModel",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostModel_AspNetUsers_UserId",
                table: "PostModel",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
