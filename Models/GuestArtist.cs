namespace SD_330_F22SD_Assignment_1.Models
{
    public class GuestArtist
    {
        public int Id { get; set; }

        public Artist Artist { get; set; }

        public int ArtistId { get; set; }

        public Episode Episode { get; set; }

        public int EpisodeId { get; set; }

        public GuestArtist() { }

        public GuestArtist(Artist artist, Episode episode)
        {
            Artist = artist;
            ArtistId = artist.Id;
            Episode = episode;
            EpisodeId = episode.EpisodeId;
        }
    }
}
