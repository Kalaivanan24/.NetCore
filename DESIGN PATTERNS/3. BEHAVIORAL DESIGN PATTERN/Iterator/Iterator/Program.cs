using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    internal class Program
    {
        public interface IIterator<T>
        {
            T Next();
            bool HasNext();
        }

        public class PlaylistIterator : IIterator<Song>
        {
            private List<Song> _songs;
            private int _currentIndex;

            public PlaylistIterator(List<Song> songs)
            {
                _songs = songs;
                _currentIndex = 0;
            }

            public Song Next()
            {
                Song song = _songs[_currentIndex];
                _currentIndex++;
                return song;
            }

            public bool HasNext()
            {
                return _currentIndex < _songs.Count;
            }
        }

        public interface IPlaylist
        {
            IIterator<Song> CreateIterator();
        }

        public class MusicPlaylist : IPlaylist
        {
            private List<Song> _songs;

            public MusicPlaylist()
            {
                _songs = new List<Song>();
            }

            public void AddSong(Song song)
            {
                _songs.Add(song);
            }

            public IIterator<Song> CreateIterator()
            {
                return new PlaylistIterator(_songs);
            }
        }

        public class Song
        {
            public string Title { get; }

            public Song(string title)
            {
                Title = title;
            }
        }

       
            static void Main(string[] args)
            {
                MusicPlaylist playlist = new MusicPlaylist();
                playlist.AddSong(new Song("Song 1"));
                playlist.AddSong(new Song("Song 2"));
                playlist.AddSong(new Song("Song 3"));

                IIterator<Song> iterator = playlist.CreateIterator();

                Console.WriteLine("Songs in the playlist:");
                while (iterator.HasNext())
                {
                    Song song = iterator.Next();
                    Console.WriteLine(song.Title);
                }
            }
        }

    }

