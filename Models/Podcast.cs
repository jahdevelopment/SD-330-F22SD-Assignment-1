using System.ComponentModel.DataAnnotations;

namespace SD_330_F22SD_Assignment_1.Models
{
    public class Podcast
    {
        public int PodcastId { get; set; }

        public string Name { get; set; }

        public virtual HashSet<ListenersListPodcast>? ListenerslistsPodcasts { get; set; } = new HashSet<ListenersListPodcast>();

        public virtual HashSet<Episode> Episodes { get; set; } = new HashSet<Episode>();

        public virtual HashSet<PodcastArtist> PodcastArtists { get; set; } = new HashSet<PodcastArtist>();

        public Podcast() { }

        public Podcast(string name)
        {
            Name = name;
        }
    }
}
