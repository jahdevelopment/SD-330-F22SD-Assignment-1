using System.ComponentModel.DataAnnotations;

namespace SD_330_F22SD_Assignment_1.Models
{
    public class Artist
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "You must fill the name field")]
        [StringLength(200, ErrorMessage = "Artist name must be between 2 and 200 characters in length", MinimumLength = 2)]
        public string Name { get; set; }

        public virtual HashSet <ArtistSong> ArtistSongs { get; set; } = new HashSet<ArtistSong> ();

        public virtual HashSet<PodcastArtist> PodcastsArtists { get; set; } = new HashSet<PodcastArtist>();

        public virtual HashSet<GuestArtist> GuestsArtists { get; set; } = new HashSet<GuestArtist>();

        public Artist() 
        {
        
        }

        public Artist(string name)
        {
            Name = name;
        }
    }
}
