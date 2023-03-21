namespace SD_330_F22SD_Assignment_1.Models
{
    public class PlaylistSong
    {
        public int Id { get; set; }

        public virtual Playlist Playlist { get; set; }

        public int PlaylistId { get; set; }
        
        public virtual Song Song { get; set; }

        public int SongId { get; set; }

        public PlaylistSong() 
        {
        
        }

        public PlaylistSong(Playlist playlist, Song song)
        {
            Playlist = playlist;

            PlaylistId = playlist.Id;

            Song = song;
            
            SongId = song.Id;
        }
    }
}
