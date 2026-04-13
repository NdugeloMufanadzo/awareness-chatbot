using System;
using System.Threading;

public class Chatbot
{
    private string[] questions = {
        "how are you?", "what's your purpose?", "what can i ask you about?",
        "password safety", "phishing", "safe browsing", "exit"
    };

    private string[] answers = {
        "I'm a bot, so I don't have feelings, but I'm here to help!",
        "I provide cybersecurity tips to keep you safe online.",
        "You can ask me about password safety, phishing, and safe browsing.",
        "Use strong passwords with a mix of uppercase, lowercase, numbers, and symbols. Avoid using personal details.",
        "Be cautious of emails asking for personal information. Verify links before clicking.",
        "Keep your software updated, avoid suspicious websites, and use antivirus protection.",
        "Goodbye! Stay safe online."
    };

    public void Start()
    {
        Console.Write("\nEnter your name: ");
        string name = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(name))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Name cannot be empty. Please enter your name: ");
            Console.ResetColor();
            name = Console.ReadLine();
        }

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\nHello, {name}! Welcome to your Cybersecurity Awareness Bot.");
        Console.WriteLine("You can ask me about cybersecurity topics like passwords, phishing, and safe browsing.");
        Console.ResetColor();

        Run();
    }

    private void Run()
    {
        while (true)
        {
            Console.Write("\nAsk me a question: ");
            string question = Console.ReadLine()?.ToLower().Trim();

            if (string.IsNullOrWhiteSpace(question)) continue;

            bool found = false;

            for (int i = 0; i < questions.Length; i++)
            {
                if (question == questions[i])
                {
                    Console.ForegroundColor = (questions[i] == "exit") ? ConsoleColor.Green : ConsoleColor.White;
                    TypingEffect(answers[i]);
                    Console.ResetColor();

                    if (questions[i] == "exit") return;

                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                TypingEffect("I didn't quite understand that. Try asking about 'phishing' or 'passwords'.");
                Console.ResetColor();
            }
        }
    }

    private void TypingEffect(string message)
    {
        foreach (char c in message)
        {
            Console.Write(c);
            Thread.Sleep(30);
        }
        Console.WriteLine();
    }
}