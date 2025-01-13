using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using WMPLib;
using System.Threading.Tasks;

namespace SchoolBellSystem.Infrastructure
{
    public class AudioPlayer
    {
        private readonly WindowsMediaPlayer _player;

        public AudioPlayer()
        {
            _player = new WindowsMediaPlayer();
        }

        public void Play(string filePath)
        {
            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
            {
                Console.WriteLine("File not found or path is empty.");
                return;
            }

            try
            {
                _player.URL = filePath;
                _player.controls.play();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error playing sound: {ex.Message}");
            }
        }
    }
}