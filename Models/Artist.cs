namespace SD_330_F22SD_Assignment_1.Models
{
    public class Artist
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public virtual HashSet <ArtistSong> ArtistSongs { get; set; } = new HashSet<ArtistSong> ();

        public Artist() 
        {
        
        }

        public Artist(string name)
        {
            Name = name;
        }
    }
}
