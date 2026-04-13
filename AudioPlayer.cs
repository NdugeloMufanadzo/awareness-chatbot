using System;
using System.IO;
using System.Threading;
using NAudio.Wave;

public static class AudioPlayer
{
    public static void PlayVoiceGreeting()
    {
        try
        {
            string audioPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "POE.wav");

            if (!File.Exists(audioPath))
            {
                Console.WriteLine($"[System] Audio file missing at: {audioPath}");
                return;
            }

            using (var audioFile = new WaveFileReader(audioPath))
            using (var outputDevice = new WaveOutEvent())
            {
                outputDevice.Init(audioFile);
                outputDevice.Play();

                while (outputDevice.PlaybackState == PlaybackState.Playing)
                {
                    Thread.Sleep(100);
                }
            }
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error playing audio: " + ex.Message);
            Console.ResetColor();
        }
    }
}
