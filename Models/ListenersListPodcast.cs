namespace SD_330_F22SD_Assignment_1.Models
{
    public class ListenersListPodcast
    {
        public int ListenersListPodcastId { get; set; }

        public ListenersList ListenersList { get; set; }

        public int ListenersListId { get; set; }

        public Podcast Podcast { get; set; }

        public int PodcastId { get; set; }

        public ListenersListPodcast() { }

        public ListenersListPodcast(ListenersList listenersList, Podcast podcast) 
        {
            ListenersList = listenersList;
            ListenersListId = listenersList.ListenersListId;
            Podcast = podcast;
            PodcastId = podcast.PodcastId;
        }
    }
}
