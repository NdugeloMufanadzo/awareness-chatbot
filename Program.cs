using System;

class Program
{
    static void Main()
    {
        AudioPlayer.PlayVoiceGreeting();
        UI.DisplayWelcomeMessage();
        UI.DisplayAsciiArt();

        Chatbot bot = new Chatbot();
        bot.Start();
    }
}
