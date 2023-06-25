namespace MediaPlayer.Core
{
    public class MediaList
    {
        private readonly List<string> mediaFiles;

        public MediaList()
        {
            mediaFiles = new List<string>();
        }

        public void AddMediaFile(string file)
        {
            mediaFiles.Add(file);
        }

        public void RemoveMediaFile(string file)
        {
            mediaFiles.Remove(file);
        }

        public void DisplayMediaFiles()
        {
            Console.WriteLine("MediaList includes:");
            foreach (var file in mediaFiles)
            {
                Console.WriteLine(file);
            }
        }
    }
}
