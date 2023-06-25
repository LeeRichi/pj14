namespace MediaPlayer.Core.Presentation
{
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
            foreach (var mediaPlayer in mediaPlayers)
            {
                mediaPlayer.Play();
            }

            NotifyPlay();
        }

        public void Pause()
        {
            foreach (var mediaPlayer in mediaPlayers)
            {
                mediaPlayer.Pause();
            }

            NotifyPause();
        }

        public void Stop()
        {
            foreach (var mediaPlayer in mediaPlayers)
            {
                mediaPlayer.Stop();
            }

            NotifyStop();
        }

        public void Seek(TimeSpan position)
        {
            foreach (var mediaPlayer in mediaPlayers)
            {
                mediaPlayer.Seek(position);
            }
        }
    }
}