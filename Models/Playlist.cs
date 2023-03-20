using System.ComponentModel.DataAnnotations;

namespace SD_330_F22SD_Assignment_1.Models
{
    public class Playlist
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "You must fill the name field")]
        [StringLength(100, ErrorMessage = "Playlist name must be between 2 and 100 characters length", MinimumLength =2)]
        public string Name { get; set; }

        public virtual HashSet<PlaylistSong> PlaylistSongs { get; set; } = new HashSet<PlaylistSong>();

        public Playlist() 
        {
        
        }

        public Playlist(string name)
        {
            Name = name;
        }
    }
}
