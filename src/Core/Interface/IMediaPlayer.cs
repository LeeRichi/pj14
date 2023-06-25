namespace MediaPlayer.Core
{
    public interface IMediaPlayer
    {
        void Play();
        void Pause();
        void Stop();
        void Seek(TimeSpan position);
    }
}

