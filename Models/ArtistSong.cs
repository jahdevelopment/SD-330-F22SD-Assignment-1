namespace SD_330_F22SD_Assignment_1.Models
{
    public class ArtistSong
    {
        public int Id { get; set; }

        public virtual Artist Artist { get; set; }

        public int ArtistId { get; set; }

        public virtual Song Song { get; set; }

        public int SongId { get; set; }

        public ArtistSong() 
        {
        
        }

        public ArtistSong(Artist artist, Song song)
        {
            Artist = artist;

            ArtistId = artist.Id;

            Song = song;

            SongId = song.Id;
        }
    }
}
