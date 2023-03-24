using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SD_330_F22SD_Assignment_1.Models;

namespace SD_330_F22SD_Assignment_1.Data
{
    public class SpotifyContext : DbContext
    {
        public SpotifyContext (DbContextOptions<SpotifyContext> options)
            : base(options)
        {
        }

        private void _createListenersListModel(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<ListenersList>()
                .Property(l => l.Name)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<ListenersList>()
                .HasKey(ll => ll.ListenersListId);

            modelBuilder.Entity<ListenersList>()
                .HasMany(l => l.ListenerslistsPodcasts)
                .WithOne(lp => lp.ListenersList)
                .HasForeignKey(lp => lp.ListenersListId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Podcast>()
                .Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Podcast>()
                .HasKey(p => p.PodcastId);

            modelBuilder.Entity<Podcast>()
                .HasMany(p =>p.Episodes)
                .WithOne(lp => lp.Podcast)
                .HasForeignKey(lp => lp.PodcastId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Podcast>()
                .HasMany(p => p.PodcastArtists)
                .WithOne(pa => pa.Podcast)
                .HasForeignKey(pa => pa.PodcastId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Artist>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Artist>()
                .Property(a => a.Name)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Artist>()
                .HasMany(a => a.PodcastsArtists)
                .WithOne(pa => pa.Artist)
                .HasForeignKey(pa => pa.Id);

            modelBuilder.Entity<Artist>()
                .HasMany(a => a.GuestsArtists)
                .WithOne(ga => ga.Artist)
                .HasForeignKey(ga => ga.Id);


            modelBuilder.Entity<Episode>()
                .HasKey(e => e.EpisodeId);

            modelBuilder.Entity<Episode>()
                .Property(e => e.Title)
                .HasMaxLength(150)
                .IsRequired();

            modelBuilder.Entity<Episode>()
                .HasMany(e => e.GuestArtists)
                .WithOne(ga => ga.Episode)
                .HasForeignKey(ga => ga.EpisodeId);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _createListenersListModel(modelBuilder);
        }



        public DbSet<Song> Song { get; set; } = default!;
        
        public DbSet<Album> Album { get; set; } = default!;

        public DbSet <Artist> Artist { get; set;} = default!;

        public DbSet<ArtistSong> ArtistSong { get; set; } = default!;

        public DbSet<Playlist> Playlist { get; set; } = default!;

        public DbSet<PlaylistSong> PlaylistSong { get; set; } = default!;

        public DbSet<ListenersList> ListenersList { get; set; } = default!;

        public DbSet<ListenersListPodcast> ListenersListPodcast { get; set; } = default!;

        public DbSet<Podcast> Podcast { get; set; } = default!;

        public DbSet<PodcastArtist> PodcastArtist { get; set; } = default!;

        public DbSet<GuestArtist> GuestArtist { get; set; } = default!;

        public DbSet<Episode> Episode { get; set; } = default!;
    }
}
