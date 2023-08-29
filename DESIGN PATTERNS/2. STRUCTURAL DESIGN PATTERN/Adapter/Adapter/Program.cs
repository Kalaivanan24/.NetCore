using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    internal class Program
    {
        interface IMediaPlayer
        {
            void Play(string filename);
        }

        class Mp3Player
        {
            public void PlayMp3(string filename)
            {
                Console.WriteLine($"Playing MP3 file: {filename}");
            }
        }

        class Mp4Player
        {
            public void PlayMp4(string filename)
            {
                Console.WriteLine($"Playing MP4 file: {filename}");
            }
        }

        class MediaAdapter : IMediaPlayer
        {
            private Mp3Player mp3Player;
            private Mp4Player mp4Player;

            public MediaAdapter()
            {
                mp3Player = new Mp3Player();
                mp4Player = new Mp4Player();
            }

            public void Play(string filename)
            {
                if (filename.EndsWith(".mp3"))
                {
                    mp3Player.PlayMp3(filename);
                }
                else if (filename.EndsWith(".mp4"))
                {
                    mp4Player.PlayMp4(filename);
                }
                else
                {
                    Console.WriteLine($"Unsupported media format: {filename}");
                }
            }
        }


      
        
            static void Main(string[] args)
            {
                IMediaPlayer player = new MediaAdapter();

                player.Play("song.mp3");
                player.Play("movie.mp4");
                player.Play("document.pdf");
            }
        }

    }

