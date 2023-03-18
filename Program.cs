using System;
using System.Diagnostics;

namespace SteamGamesRemover
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool end = false;
            //int[] idGames = new int[];
            List<int> idGames = new List<int> { };
            List<string> links = new List<string> { };
            Console.WriteLine("Введите айди игр (после ввода 1 айди нажимайте Enter и снова вводите). При окончании ввода напишите /s");
            while (!end) // читание нескольких строк
            {
                string? textRead = Console.ReadLine();
                if (textRead != "/s")
                {
                    bool success = int.TryParse(textRead, out int num);
                    if (success)
                    {
                        idGames.Add(num);
                    }
                    else
                    {
                        Console.WriteLine("Неверный айди! Указывайте только число, например, 1000");
                    }
                }
                else
                {
                    end = true;
                }
            }
            Console.WriteLine("Получение ссылок...");
            for (int n = 0; n < idGames.Count; n++)
            {
                links.Add("https://help.steampowered.com/ru/wizard/HelpWithGameIssue/?appid=" + idGames[n] + "&issueid=123");
                Console.WriteLine(links[n]);
            }
            Console.WriteLine("Хотите открыть ссылки? (Y - Yes, N - No)");
            string? confirmation = Console.ReadLine();
            {
                if (confirmation.ToLower() == "y" || confirmation.ToLower() == "yes")
                {
                    for (int n = 0; n < links.Count; n++)
                    {
                        Process.Start(new ProcessStartInfo("cmd", $"/c start {links[n]}") { CreateNoWindow = true });
                    }
                }
            }
            Console.WriteLine("Нажмите любую клавишу для выхода");
            Console.ReadKey(true);
        }
    }
}