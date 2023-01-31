using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using HubDeJogos.Entities;

namespace Csharp_PlayGround
{
    internal class Program
    {

        static void DeserializeJson(List<Account> jogadores, string Filepath)
        {
            string jsonstring = File.ReadAllText(Filepath);

            if (!String.IsNullOrEmpty(Filepath))
            {
                List<Account> allplayers = JsonSerializer.Deserialize<List<Account>>(jsonstring);

                allplayers.ForEach(usuario => jogadores.Add(usuario));
            }

        }
        static void Main(string[] args)
        {

            List<Account> jogadores = new List<Account>();
            string rootPath = @"C:\Users\alana\source\repos\HubDeJogos\HubDeJogos\jogadores.json";
            string Filepath = rootPath;
            DeserializeJson(jogadores, Filepath);

            Menu.MenuInicial(jogadores, Filepath);

            int player1Wins = 0, player2Wins = 0;

            
            Game game1 = new Game();
            game1.PlayToEnd();
            if (game1.Player1.Perdeu)
            {
                player2Wins++;
            }
            else
            {
                player1Wins++;
            }


            Console.WriteLine("Player 1 Wins: " + player1Wins.ToString());
            Console.WriteLine("Player 2 Wins: " + player2Wins.ToString());
            Console.ReadLine();
        }
    }
}