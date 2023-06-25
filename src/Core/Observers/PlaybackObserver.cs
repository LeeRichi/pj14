namespace MediaPlayer.Core
{
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
}

