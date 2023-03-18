using System;

namespace SteamGamesRemover
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool end = false;
            //int[] idGames = new int[];
            List<int> idGames = new List<int> {};
            string links = "";
            int i = 0;
            Console.WriteLine("Введите айди игр (после ввода 1 айди нажимайте Enter и снова вводите). При окончании ввода напишите /s");
            while (!end) // читание нескольких строк
            {
                string textRead = Console.ReadLine();
                if (textRead != "/s")
                {
                    idGames.Add(idGames.Count + 1);
                    idGames[i] = Convert.ToInt32(textRead);
                    i++;
                }
                else
                {
                    end = true;
                }
            }
            Console.WriteLine("Получение ссылок...");
            for (int n = 0; n < idGames.Count; n++)
            {
                links += "\nhttps://help.steampowered.com/ru/wizard/HelpWithGameIssue/?appid=" + idGames[n] + "&issueid=123";
            }
            Console.WriteLine(links);
        }
    }
}