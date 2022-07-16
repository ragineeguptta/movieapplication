using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace movieapplication.Data.Migrations
{
    public partial class addd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActorIds",
                table: "MoviesActorIds");

            migrationBuilder.DropColumn(
                name: "MovieIds",
                table: "MoviesActorIds");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActorIds",
                table: "MoviesActorIds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MovieIds",
                table: "MoviesActorIds",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
