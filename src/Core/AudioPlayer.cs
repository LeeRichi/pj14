namespace MediaPlayer.Core
{
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
    }
}
