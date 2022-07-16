using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace movieapplication.Data.Migrations
{
    public partial class dvb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoviesActorIds_Actors_AIdNavigationActorId",
                table: "MoviesActorIds");

            migrationBuilder.DropForeignKey(
                name: "FK_MoviesActorIds_Movies_MIdNavigationMovieId",
                table: "MoviesActorIds");

            migrationBuilder.RenameColumn(
                name: "MIdNavigationMovieId",
                table: "MoviesActorIds",
                newName: "MovieId");

            migrationBuilder.RenameColumn(
                name: "AIdNavigationActorId",
                table: "MoviesActorIds",
                newName: "ActorId");

            migrationBuilder.RenameIndex(
                name: "IX_MoviesActorIds_MIdNavigationMovieId",
                table: "MoviesActorIds",
                newName: "IX_MoviesActorIds_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_MoviesActorIds_AIdNavigationActorId",
                table: "MoviesActorIds",
                newName: "IX_MoviesActorIds_ActorId");

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

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "MoviesActorIds",
                newName: "MIdNavigationMovieId");

            migrationBuilder.RenameColumn(
                name: "ActorId",
                table: "MoviesActorIds",
                newName: "AIdNavigationActorId");

            migrationBuilder.RenameIndex(
                name: "IX_MoviesActorIds_MovieId",
                table: "MoviesActorIds",
                newName: "IX_MoviesActorIds_MIdNavigationMovieId");

            migrationBuilder.RenameIndex(
                name: "IX_MoviesActorIds_ActorId",
                table: "MoviesActorIds",
                newName: "IX_MoviesActorIds_AIdNavigationActorId");

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
    }
}
