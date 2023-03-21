using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SD_330_F22SD_Assignment_1.Migrations
{
    /// <inheritdoc />
    public partial class PodcastSectionCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Artist",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Album",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.CreateTable(
                name: "ListenersList",
                columns: table => new
                {
                    ListenersListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListenersList", x => x.ListenersListId);
                });

            migrationBuilder.CreateTable(
                name: "ListenersListPodcast",
                columns: table => new
                {
                    ListenersListPodcastId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListenersListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListenersListPodcast", x => x.ListenersListPodcastId);
                    table.ForeignKey(
                        name: "FK_ListenersListPodcast_ListenersList_ListenersListId",
                        column: x => x.ListenersListId,
                        principalTable: "ListenersList",
                        principalColumn: "ListenersListId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Podcast",
                columns: table => new
                {
                    PodcastId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ListenersListPodcastId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Podcast", x => x.PodcastId);
                    table.ForeignKey(
                        name: "FK_Podcast_ListenersListPodcast_ListenersListPodcastId",
                        column: x => x.ListenersListPodcastId,
                        principalTable: "ListenersListPodcast",
                        principalColumn: "ListenersListPodcastId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Episode",
                columns: table => new
                {
                    EpisodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    AirDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PodcastId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episode", x => x.EpisodeId);
                    table.ForeignKey(
                        name: "FK_Episode_Podcast_PodcastId",
                        column: x => x.PodcastId,
                        principalTable: "Podcast",
                        principalColumn: "PodcastId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PodcastArtist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PodcastId = table.Column<int>(type: "int", nullable: false),
                    ArtistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PodcastArtist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PodcastArtist_Artist_Id",
                        column: x => x.Id,
                        principalTable: "Artist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PodcastArtist_Podcast_PodcastId",
                        column: x => x.PodcastId,
                        principalTable: "Podcast",
                        principalColumn: "PodcastId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GuestArtist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    EpisodeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestArtist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuestArtist_Artist_Id",
                        column: x => x.Id,
                        principalTable: "Artist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GuestArtist_Episode_EpisodeId",
                        column: x => x.EpisodeId,
                        principalTable: "Episode",
                        principalColumn: "EpisodeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Episode_PodcastId",
                table: "Episode",
                column: "PodcastId");

            migrationBuilder.CreateIndex(
                name: "IX_GuestArtist_EpisodeId",
                table: "GuestArtist",
                column: "EpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_ListenersListPodcast_ListenersListId",
                table: "ListenersListPodcast",
                column: "ListenersListId");

            migrationBuilder.CreateIndex(
                name: "IX_Podcast_ListenersListPodcastId",
                table: "Podcast",
                column: "ListenersListPodcastId");

            migrationBuilder.CreateIndex(
                name: "IX_PodcastArtist_PodcastId",
                table: "PodcastArtist",
                column: "PodcastId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuestArtist");

            migrationBuilder.DropTable(
                name: "PodcastArtist");

            migrationBuilder.DropTable(
                name: "Episode");

            migrationBuilder.DropTable(
                name: "Podcast");

            migrationBuilder.DropTable(
                name: "ListenersListPodcast");

            migrationBuilder.DropTable(
                name: "ListenersList");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Artist",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Album",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
