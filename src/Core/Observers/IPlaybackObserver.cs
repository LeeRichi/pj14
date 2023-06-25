namespace MediaPlayer.Core
{
    public interface IPlaybackObserver
    {
        void OnPlay();
        void OnPause();
        void OnStop();
    }
}


