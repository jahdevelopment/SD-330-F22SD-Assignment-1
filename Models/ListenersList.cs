using System.ComponentModel.DataAnnotations;

namespace SD_330_F22SD_Assignment_1.Models
{
    public class ListenersList
    {
        public int ListenersListId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "You must fill the name field")]
        [StringLength(100, ErrorMessage = "The listener name must be between 2 and 100 characters in length", MinimumLength = 2)]
        public string Name { get; set; }

        public virtual HashSet<ListenersListPodcast> ListenerslistsPodcasts { get; set; } = new HashSet<ListenersListPodcast>();

        public ListenersList() { }

        public ListenersList(string name) 
        {
            Name = name;
        }
    }
}
