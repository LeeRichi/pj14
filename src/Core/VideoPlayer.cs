namespace MediaPlayer.Core
{
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
    }
}


