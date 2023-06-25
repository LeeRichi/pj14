## Key Concepts
1. Use C# and .net framework to build the media player
2. functions of play, stop, pause, seek; add, remove media and playlist.

## Tech Stack
1. C#, .net
2. Solid
3. Software Architecture
4. observer

## Result


## Instructure
1. clone the app: https://github.com/LeeRichi/fs15_14-MediaPlayer.git
2. In root folder, run script 'dotnet run'.


## Sturcture
````
└── src
    └── Core
        ├── AudioPlayer.cs
        ├── Entities
        │   ├── MediaLibrary.cs
        │   └── Playlist.cs
        ├── Interface
        │   └── IMediaPlayer.cs
        ├── MediaPlayerManager.cs
        ├── Observers
        │   ├── IPlaybackObserver.cs
        │   └── PlaybackObserver.cs
        ├── Presentation
        │   ├── CommandLineInterface.cs
        │   └── Program.cs
        └── VideoPlayer.cs
````
# pj14
