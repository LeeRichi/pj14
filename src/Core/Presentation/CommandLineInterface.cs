namespace MediaPlayer.Core.Presentation
{
    public class CommandLineInterface
    {
        private readonly MediaPlayerManager mediaPlayerManager;
        private readonly MediaList mediaList;
        private readonly Playlist playlist;

        public CommandLineInterface()
        {
            mediaPlayerManager = MediaPlayerManager.Instance;
            mediaList = new MediaList();
            playlist = new Playlist();

            // Register media players
            mediaPlayerManager.RegisterMediaPlayer(new AudioPlayer());
            mediaPlayerManager.RegisterMediaPlayer(new VideoPlayer());

            // Add playback observer
            mediaPlayerManager.AddObserver(new PlaybackObserver());
        }

        public void Run()
        {
            Console.WriteLine("Media Player Application");
            Console.WriteLine("------------------------");

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Available Commands:");
                Console.WriteLine("1. Play");
                Console.WriteLine("2. Pause");
                Console.WriteLine("3. Stop");
                Console.WriteLine("4. Seek");
                Console.WriteLine("5. Add Media File");
                Console.WriteLine("6. Remove Media File");
                Console.WriteLine("7. Display Media Library");
                Console.WriteLine("8. Add Playlist Item");
                Console.WriteLine("9. Remove Playlist Item");
                Console.WriteLine("10. Display Playlist");
                Console.WriteLine("0. Exit");
                Console.Write("Enter command number: ");

                if (int.TryParse(Console.ReadLine(), out int command))
                {
                    Console.WriteLine();

                    switch (command)
                    {
                        case 0:
                            return;

                        case 1:
                            mediaPlayerManager.Play();
                            break;

                        case 2:
                            mediaPlayerManager.Pause();
                            break;

                        case 3:
                            mediaPlayerManager.Stop();
                            break;

                        case 4:
                            Console.Write("Enter position in seconds: ");
                            if (int.TryParse(Console.ReadLine(), out int position))
                            {
                                mediaPlayerManager.Seek(TimeSpan.FromSeconds(position));
                            }
                            else
                            {
                                Console.WriteLine("Invalid position, please use valid number");
                            }
                            break;

                        case 5:
                            Console.Write("Add media file name: ");
                            string mediaFile = Console.ReadLine();
                            string filePath = Path.Combine(Directory.GetCurrentDirectory(), mediaFile);
                            mediaList.AddMediaFile(filePath);
                            break;

                        case 6:
                            Console.Write("Remove media file path: ");
                            mediaFile = Console.ReadLine();
                            mediaList.RemoveMediaFile(mediaFile);
                            break;

                        case 7:
                            mediaList.DisplayMediaFiles();
                            break;

                        case 8:
                            Console.Write("Add playlist item: ");
                            string playlistItem = Console.ReadLine();
                            playlist.AddItem(playlistItem);
                            break;

                        case 9:
                            Console.Write("Remove playlist item: ");
                            playlistItem = Console.ReadLine();
                            playlist.RemoveItem(playlistItem);
                            break;

                        case 10:
                            playlist.DisplayItems();
                            break;

                        default:
                            Console.WriteLine("Invalid command");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid command");
                }
            }
        }
    }
}


