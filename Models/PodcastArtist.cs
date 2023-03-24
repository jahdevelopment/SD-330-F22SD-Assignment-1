namespace SD_330_F22SD_Assignment_1.Models
{
    public class PodcastArtist
    {
        public int Id { get; set; }

        public Podcast Podcast { get; set; }

        public int PodcastId { get; set; }

        public Artist Artist { get; set; }

        public int ArtistId { get; set;}

        public PodcastArtist() { }

        public PodcastArtist(Podcast podcast, Artist artist)
        {            
            Podcast = podcast;
            PodcastId = podcast.PodcastId;
            Artist = artist;
            ArtistId = artist.Id;
        }
    }
}
