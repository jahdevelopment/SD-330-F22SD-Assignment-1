namespace SD_330_F22SD_Assignment_1.Models
{
    public class Song
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int DurationSeconds { get; set; }

        public Album Album { get; set; }

        public int AlbumId { get; set; }

        public virtual HashSet<PlaylistSong> PlaylistSongs { get; set; } = new HashSet<PlaylistSong>();

        public Song()
        {

        }

        public Song(string title, int durationSeconds, Album album)
        {
            Title = title;
            
            DurationSeconds = durationSeconds;
            
            Album = album;

            AlbumId = album.Id;
        }
    }
}
