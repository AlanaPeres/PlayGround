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
         
        }
    }
}