using System.ComponentModel.DataAnnotations;

namespace SD_330_F22SD_Assignment_1.Models
{
    public class Album
    {
        public int Id { get; set; }

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
