namespace SD_330_F22SD_Assignment_1.Models
{
    public class Playlist
    {
        public int Id { get; set; }

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
