namespace MediaPlayer.Core
{ 
    public class Playlist
    {
        private readonly List<string> playlistItems;

        public Playlist()
        {
            playlistItems = new List<string>();
        }

        public void AddItem(string item)
        {
            playlistItems.Add(item);
        }

        public void RemoveItem(string item)
        {
            playlistItems.Remove(item);
        }

        public void DisplayItems()
        {
            Console.WriteLine("Playlist Contents:");
            foreach (var item in playlistItems)
            {
                Console.WriteLine(item);
            }
        }
    }
}

