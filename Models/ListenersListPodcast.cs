namespace SD_330_F22SD_Assignment_1.Models
{
    public class ListenersListPodcast
    {
        public int ListenersListPodcastId { get; set; }

        public ListenersList ListenersList { get; set; }

        public int ListenersListId { get; set; }

        public virtual HashSet<Podcast> Podcasts { get; set; }  = new HashSet<Podcast>();

        public ListenersListPodcast() { }

        public ListenersListPodcast(ListenersList listenersList) 
        {
            ListenersList = listenersList;
            ListenersListId = listenersList.ListenersListId;
        }
    }
}
