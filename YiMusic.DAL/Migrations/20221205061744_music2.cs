using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YiMusic.DAL.Migrations
{
    /// <inheritdoc />
    public partial class music2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MusicPathUrl",
                table: "Music",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MusicPathUrl",
                table: "Music");
        }
    }
}
