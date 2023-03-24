using System.ComponentModel.DataAnnotations;

namespace SD_330_F22SD_Assignment_1.Models
{
    public class Episode
    {
        public int EpisodeId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "You must fill the Title field")]
        [StringLength(150, ErrorMessage = "Episode title must be between 2 and 150 characters in length", MinimumLength = 2)]
        public string Title { get; set; }
        
        [Range(1, 3600, ErrorMessage = "Seconds must be between 1 and 3600")]
        public int Duration { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of Addition")]
        public DateTime AirDate { get; set; }

        public Podcast Podcast { get; set; }

        public int PodcastId { get; set; }

        public virtual HashSet<GuestArtist>? GuestArtists { get; set; } = new HashSet<GuestArtist>();

        public Episode() { }

        public Episode(string title, int duration, DateTime airDate, Podcast podcast)
        {
            Title = title;
            Duration = duration;
            AirDate = airDate;
            Podcast = podcast;
            PodcastId = podcast.PodcastId;
        }
    }
}
