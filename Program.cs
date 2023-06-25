// Media Player interface
public interface IMediaPlayer
{
    void Play();
    void Pause();
    void Stop();
    void Seek(TimeSpan position);
    // New method for video player
    void PlayVideo(string filePath);
}

// Audio Player implementation
public class AudioPlayer : IMediaPlayer
{
    public void Play()
    {
        Console.WriteLine("Audio playback started");
    }

    public void Pause()
    {
        Console.WriteLine("Audio playback paused");
    }

    public void Stop()
    {
        Console.WriteLine("Audio playback stopped");
    }

    public void Seek(TimeSpan position)
    {
        Console.WriteLine("Seeking audio to position: " + position);
    }

    public void PlayVideo(string filePath)
    {
        Console.WriteLine("Playing audio: " + filePath);
        // Code to play the video file
    }
}

// Video Player implementation
public class VideoPlayer : IMediaPlayer
{
    public void Play()
    {
        Console.WriteLine("Video playback started");
    }

    public void Pause()
    {
        Console.WriteLine("Video playback paused");
    }

    public void Stop()
    {
        Console.WriteLine("Video playback stopped");
    }

    public void Seek(TimeSpan position)
    {
        Console.WriteLine("Seeking video to position: " + position);
    }
    public void PlayVideo(string filePath)
    {
        Console.WriteLine("Playing video: " + filePath);
        // Code to play the video file
    }
}

// Media Player Manager
public class MediaPlayerManager
{
    private static MediaPlayerManager? instance;
    private readonly List<IMediaPlayer> mediaPlayers;
    private readonly List<IPlaybackObserver> observers;

    private MediaPlayerManager()
    {
        mediaPlayers = new List<IMediaPlayer>();
        observers = new List<IPlaybackObserver>();
    }

    public static MediaPlayerManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new MediaPlayerManager();
            }
            return instance;
        }
    }

    public void RegisterMediaPlayer(IMediaPlayer mediaPlayer)
    {
        mediaPlayers.Add(mediaPlayer);
    }

    public void UnregisterMediaPlayer(IMediaPlayer mediaPlayer)
    {
        mediaPlayers.Remove(mediaPlayer);
    }

    public void AddObserver(IPlaybackObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IPlaybackObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyPlay()
    {
        foreach (var observer in observers)
        {
            observer.OnPlay();
        }
    }

    public void NotifyPause()
    {
        foreach (var observer in observers)
        {
            observer.OnPause();
        }
    }

    public void NotifyStop()
    {
        foreach (var observer in observers)
        {
            observer.OnStop();
        }
    }

    public void Play()
    {
        // Perform play operation on all registered media players
        foreach (var mediaPlayer in mediaPlayers)
        {
            mediaPlayer.Play();
        }

        // Notify observers about the play event
        NotifyPlay();
    }

    public void Pause()
    {
        // Perform pause operation on all registered media players
        foreach (var mediaPlayer in mediaPlayers)
        {
            mediaPlayer.Pause();
        }

        // Notify observers about the pause event
        NotifyPause();
    }

    public void Stop()
    {
        // Perform stop operation on all registered media players
        foreach (var mediaPlayer in mediaPlayers)
        {
            mediaPlayer.Stop();
        }

        // Notify observers about the stop event
        NotifyStop();
    }

    public void Seek(TimeSpan position)
    {
        // Perform seek operation on all registered media players
        foreach (var mediaPlayer in mediaPlayers)
        {
            mediaPlayer.Seek(position);
        }
    }
}

// Playback observer interface
public interface IPlaybackObserver
{
    void OnPlay();
    void OnPause();
    void OnStop();
}

// Example playback observer implementation
public class PlaybackObserver : IPlaybackObserver
{
    public void OnPlay()
    {
        Console.WriteLine("Playback event: Play");
    }

    public void OnPause()
    {
        Console.WriteLine("Playback event: Pause");
    }

    public void OnStop()
    {
        Console.WriteLine("Playback event: Stop");
    }
}

// Media Library class
public class MediaLibrary
{
    private readonly List<string> mediaFiles;

    public MediaLibrary()
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
        Console.WriteLine("Media Library Contents:");
        foreach (var file in mediaFiles)
        {
            Console.WriteLine(file);
        }
    }
}

// Playlist class
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

// Command Line Interface class
public class CommandLineInterface
{
    private readonly MediaPlayerManager mediaPlayerManager;
    private readonly MediaLibrary mediaLibrary;
    private readonly Playlist playlist;

    public CommandLineInterface()
    {
        mediaPlayerManager = MediaPlayerManager.Instance;
        mediaLibrary = new MediaLibrary();
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
                            Console.WriteLine("Invalid position");
                        }
                        break;

                    case 5:
                        Console.Write("Enter media file name: ");
                        string mediaFile = Console.ReadLine();
                        string filePath = Path.Combine(Directory.GetCurrentDirectory(), mediaFile);
                        mediaLibrary.AddMediaFile(filePath);
                        break;

                    case 6:
                        Console.Write("Enter media file path: ");
                        mediaFile = Console.ReadLine();
                        mediaLibrary.RemoveMediaFile(mediaFile);
                        break;

                    case 7:
                        mediaLibrary.DisplayMediaFiles();
                        break;

                    case 8:
                        Console.Write("Enter playlist item: ");
                        string playlistItem = Console.ReadLine();
                        playlist.AddItem(playlistItem);
                        break;

                    case 9:
                        Console.Write("Enter playlist item: ");
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

public class Program
{
    public static void Main(string[] args)
    {
        CommandLineInterface cli = new CommandLineInterface();
        cli.Run();
    }
}
