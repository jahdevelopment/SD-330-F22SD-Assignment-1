using System.ComponentModel.DataAnnotations;

namespace SD_330_F22SD_Assignment_1.Models
{
    public class Song
    {
        public int Id { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "You must fill the title field")]
        [StringLength(200, ErrorMessage = "The title must be between 2 and 200 characters in length", MinimumLength = 2)]
        public string Title { get; set; }

        [Range(1,1200, ErrorMessage = "Seconds must be between 1 and 1200")]
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
