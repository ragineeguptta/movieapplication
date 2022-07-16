using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace movieapplication.Data.Migrations
{
    public partial class adddd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AIdNavigationActorId",
                table: "MoviesActorIds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MIdNavigationMovieId",
                table: "MoviesActorIds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MoviesActorIds_AIdNavigationActorId",
                table: "MoviesActorIds",
                column: "AIdNavigationActorId");

            migrationBuilder.CreateIndex(
                name: "IX_MoviesActorIds_MIdNavigationMovieId",
                table: "MoviesActorIds",
                column: "MIdNavigationMovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_MoviesActorIds_Actors_AIdNavigationActorId",
                table: "MoviesActorIds",
                column: "AIdNavigationActorId",
                principalTable: "Actors",
                principalColumn: "ActorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoviesActorIds_Movies_MIdNavigationMovieId",
                table: "MoviesActorIds",
                column: "MIdNavigationMovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoviesActorIds_Actors_AIdNavigationActorId",
                table: "MoviesActorIds");

            migrationBuilder.DropForeignKey(
                name: "FK_MoviesActorIds_Movies_MIdNavigationMovieId",
                table: "MoviesActorIds");

            migrationBuilder.DropIndex(
                name: "IX_MoviesActorIds_AIdNavigationActorId",
                table: "MoviesActorIds");

            migrationBuilder.DropIndex(
                name: "IX_MoviesActorIds_MIdNavigationMovieId",
                table: "MoviesActorIds");

            migrationBuilder.DropColumn(
                name: "AIdNavigationActorId",
                table: "MoviesActorIds");

            migrationBuilder.DropColumn(
                name: "MIdNavigationMovieId",
                table: "MoviesActorIds");
        }
    }
}
