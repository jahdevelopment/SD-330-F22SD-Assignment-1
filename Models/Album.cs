using System.ComponentModel.DataAnnotations;

namespace SD_330_F22SD_Assignment_1.Models
{
    public class Album
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "You must fill the title field")]
        [StringLength(150, ErrorMessage = "The title field must be between 2 and 150 characters length", MinimumLength = 2)]
        public string Title { get; set; }
        [Display(Name = "List of Songs")]
        public virtual HashSet<Song> Songs { get; set; } = new HashSet<Song>();

        public Album() 
        {

        }

        public Album(string title)
        {
            Title = title;
        }
    }
}
