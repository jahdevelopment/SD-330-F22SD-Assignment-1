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

        public DbSet<Song> Song { get; set; } = default!;
        
        public DbSet<Album> Album { get; set; } = default!;

        public DbSet <Artist> Artist { get; set;} = default!;

        public DbSet<ArtistSong> ArtistSong { get; set; } = default!;

        public DbSet<Playlist> Playlist { get; set; } = default!;

        public DbSet<PlaylistSong> PlaylistSong { get; set; } = default!;
    }
}
