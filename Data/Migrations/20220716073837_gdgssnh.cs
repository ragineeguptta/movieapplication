using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace movieapplication.Data.Migrations
{
    public partial class gdgssnh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActorId",
                table: "MoviesActorIds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MoviesActorIds_ActorId",
                table: "MoviesActorIds",
                column: "ActorId");

            migrationBuilder.AddForeignKey(
                name: "FK_MoviesActorIds_Actors_ActorId",
                table: "MoviesActorIds",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "ActorId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoviesActorIds_Actors_ActorId",
                table: "MoviesActorIds");

            migrationBuilder.DropIndex(
                name: "IX_MoviesActorIds_ActorId",
                table: "MoviesActorIds");

            migrationBuilder.DropColumn(
                name: "ActorId",
                table: "MoviesActorIds");
        }
    }
}
