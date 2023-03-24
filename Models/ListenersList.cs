using System.ComponentModel.DataAnnotations;

namespace SD_330_F22SD_Assignment_1.Models
{
    public class ListenersList
    {
        public int ListenersListId { get; set; }

        public string Name { get; set; }

        public virtual HashSet<ListenersListPodcast> ListenerslistsPodcasts { get; set; } = new HashSet<ListenersListPodcast>();

        public ListenersList() { }

        public ListenersList(string name) 
        {
            Name = name;
        }
    }
}
