using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace movieapplication.Data.Migrations
{
    public partial class djfavlk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoviesActorIds_Actors_ActorId",
                table: "MoviesActorIds");

            migrationBuilder.DropForeignKey(
                name: "FK_MoviesActorIds_Movies_MovieId",
                table: "MoviesActorIds");

            migrationBuilder.DropIndex(
                name: "IX_MoviesActorIds_ActorId",
                table: "MoviesActorIds");

            migrationBuilder.DropIndex(
                name: "IX_MoviesActorIds_MovieId",
                table: "MoviesActorIds");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_MoviesActorIds_ActorId",
                table: "MoviesActorIds",
                column: "ActorId");

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
    }
}
