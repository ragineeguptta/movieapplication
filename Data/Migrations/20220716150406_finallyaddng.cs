using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace movieapplication.Data.Migrations
{
    public partial class finallyaddng : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MoviesActorIds",
                table: "MoviesActorIds");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "MoviesActorIds");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateofRelease",
                table: "Movies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_MoviesActorIds",
                table: "MoviesActorIds",
                columns: new[] { "ActorId", "MovieId" });

            migrationBuilder.CreateIndex(
                name: "IX_MoviesActorIds_MovieId",
                table: "MoviesActorIds",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_MoviesActorIds_Actors_ActorId",
                table: "MoviesActorIds",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "ActorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoviesActorIds_Movies_MovieId",
                table: "MoviesActorIds",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoviesActorIds_Actors_ActorId",
                table: "MoviesActorIds");

            migrationBuilder.DropForeignKey(
                name: "FK_MoviesActorIds_Movies_MovieId",
                table: "MoviesActorIds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MoviesActorIds",
                table: "MoviesActorIds");

            migrationBuilder.DropIndex(
                name: "IX_MoviesActorIds_MovieId",
                table: "MoviesActorIds");

            migrationBuilder.DropColumn(
                name: "DateofRelease",
                table: "Movies");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "MoviesActorIds",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MoviesActorIds",
                table: "MoviesActorIds",
                column: "Id");
        }
    }
}
