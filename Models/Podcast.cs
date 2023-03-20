using System.ComponentModel.DataAnnotations;

namespace SD_330_F22SD_Assignment_1.Models
{
    public class Podcast
    {
        public int PodcastId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "You must fill the name field")]
        [StringLength(100, ErrorMessage = "Podcast name must be between 2 and 100 characters in length", MinimumLength = 2)]
        public string Name { get; set; }

        public ListenersListPodcast ListenerslistPodcast { get; set; }

        public int ListenersListPodcastId { get; set; }

        public virtual HashSet<Episode> Episodes { get; set; } = new HashSet<Episode>();

        public virtual HashSet<PodcastArtist> PodcastArtists { get; set; } = new HashSet<PodcastArtist>();

        public Podcast() { }

        public Podcast(string name, ListenersListPodcast listenersListPodcast)
        {
            Name = name;
            ListenerslistPodcast = listenersListPodcast;
            ListenersListPodcastId = listenersListPodcast.ListenersListPodcastId;
        }
    }
}
