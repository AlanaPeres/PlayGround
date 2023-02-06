using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace HubDeJogos.Entities
{
    public class Account
    {
        public string User { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int VitoriaTicTacToe;
        public int VitoriaChess;
        public int VitoriaNavalBattle;


        public Account(string user, string email, string password)
        {
            User = user;
            Email = email;
            Password = password;
            VitoriaTicTacToe = 0;
            VitoriaNavalBattle = 0;
            VitoriaChess = 0;

        }

        public override string ToString() => $"User: {User} | Pontos Jogo da Velha {VitoriaTicTacToe} | Pontos Batalha Naval {VitoriaNavalBattle} | Pontos Jogo de Xadrez{VitoriaChess} ";

        public static void SerializeJson(List<Account> jogadores, string Filepath)
        {
            string jsonString = JsonSerializer.Serialize(jogadores);

            File.WriteAllText(Filepath, jsonString);
        }

        public static void CreateNewAccount(List<Account> jogadores, string Filepath)
        {
            Console.WriteLine("CRIAR UMA NOVA CONTA\n");
            Console.WriteLine("User: ");
            string user = Console.ReadLine();
            Console.WriteLine("E-mail: ");
            string email = Console.ReadLine();
            Console.WriteLine("Senha: ");
            string password = Console.ReadLine();
            int vitoriaTicTacToe = 0;
            int vitoriaNavalBattle = 0;
            int vitoriaChess = 0;


            int shearch = jogadores.FindIndex(x => x.User == user );
            int shearch2 = jogadores.FindIndex(y => y.Email == email);

            if (shearch != -1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nome de usuário indisponível.");
                Console.ResetColor();
                Thread.Sleep(3000);
            }
            else if (shearch2 != -1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("E-mail já cadastrado.");
                Console.ResetColor();
                Thread.Sleep(3000);
            }
            else
            {
                Account newAccount = new Account(user, email, password);
                jogadores.Add(newAccount);
                SerializeJson(jogadores, Filepath);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Conta cadastrada com sucesso! ");
                Console.ResetColor();
                Thread.Sleep(2000);

            }

        }


        public static void UpdatePassword(List<Account> jogadores, string Filepath)
        {
            Console.WriteLine("ALTERAR SENHA\n");
            Console.WriteLine("Confirme seu e-mail: ");
            string email = Console.ReadLine();
            Console.WriteLine("Senha atual: ");
            string senhaAtual = Console.ReadLine();
            Console.WriteLine("Nova Senha: ");
            string novaSenha = Console.ReadLine();
            int shearch = jogadores.FindIndex(x => x.User == senhaAtual);


            if (shearch != -1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Não foi possível alterar a senha.");
                Console.WriteLine("MOTIVO: senha incorreta.");
                Console.ResetColor();
                Thread.Sleep(3000);
            }
            else
            {
                Account alterarSenha = jogadores.Find(x => x.Password == senhaAtual);
                alterarSenha.Password = novaSenha;
                SerializeJson(jogadores, Filepath);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Senha alterada com sucesso.");
                Console.ResetColor();
                Thread.Sleep(3000);
            }

        }

        public static void Login(List<Account> jogadores, string Filepath)
        {
            //Console.WriteLine("\nPara iniciar uma nova partida é necessário dois jogadores. ");
            //Console.WriteLine("Entre com o usuário de cada jogador: ");
            Console.WriteLine("\nLOGIN: ");
            string jogador1 = Console.ReadLine();
            Console.WriteLine("\nSENHA: ");
            string senha1 = Console.ReadLine();
            int buscarIndex = jogadores.FindIndex(x => x.User == jogador1 && x.Password == senha1);
            

            if (buscarIndex != -1 )
            {
                Menu.MenuHub(jogadores, Filepath);

            }
            else
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Não foi possível inicar partida.");
                Console.WriteLine("Usuário não encontrado. Volte e cadastre os jogadores.");
                Console.ResetColor();
                Thread.Sleep(3000);

            }

            //Console.ForegroundColor = ConsoleColor.Cyan;
            //Console.WriteLine("\nLOGIN JOGADOR 2: ");
            //string jogador2 = Console.ReadLine();
            //Console.WriteLine("\nSENHA: ");
            //string senha2 = Console.ReadLine();
            //Console.ResetColor();

            //int buscaIndex2 = jogadores.FindIndex(x => x.User == jogador2 && x.Password == senha2);


            //if (buscaIndex2 != -1)
            //{
            //    Menu.MenuHub(jogadores, Filepath);

            //}
            //else
            //{

            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.WriteLine("Não foi possível inicar partida.");
            //    Console.WriteLine("Usuário não encontrado. Volte e cadastre os jogadores.");
            //    Console.ResetColor();
            //    Thread.Sleep(3000);

            //}

        }

        public static void Ranking(List<Account> jogadores, string Filepath)
        {
            Console.Clear();
            int[] pontosVelha = new int[jogadores.Count];
            List<string> list = new List<string>();

            for (int i = 0; i < jogadores.Count; i++)
            {
                pontosVelha[i] = jogadores[i].VitoriaTicTacToe;
                list.Add(jogadores[i].User);
            }

            Array.Sort(pontosVelha);
            Array.Reverse(pontosVelha);

            for (int j = 0; j < jogadores.Count; j++)
            {
                int index = jogadores.FindIndex(x => x.VitoriaTicTacToe == pontosVelha[j] && list.Exists(jogador => x.User == jogador));
                Console.WriteLine($"Jogador(a): {jogadores[index].User} |Jogo da Velha: {pontosVelha[j]}  ");
                list.Remove(jogadores[index].User);

            }

            //ranking Chess
            int[] pontosXadrez = new int[jogadores.Count];
            List<string> listXadrez = new List<string>();

            for (int i = 0; i < jogadores.Count; i++)
            {
                pontosXadrez[i] = jogadores[i].VitoriaChess;
                listXadrez.Add(jogadores[i].User);
            }

            Array.Sort(pontosXadrez);
            Array.Reverse(pontosXadrez);

            for (int j = 0; j < jogadores.Count; j++)
            {
                int index = jogadores.FindIndex(x => x.VitoriaChess == pontosXadrez[j] && list.Exists(jogador => x.User == jogador));
                Console.WriteLine($"Jogador(a): {jogadores[index].User} |Jogo de Xadrez: {pontosXadrez[j]}  ");
                listXadrez.Remove(jogadores[index].User);

            }

            //ranking NavalBattle
            int[] pontosBatalha = new int[jogadores.Count];
            List<string> listBatalha = new List<string>();

            for (int i = 0; i < jogadores.Count; i++)
            {
                pontosBatalha[i] = jogadores[i].VitoriaNavalBattle;
                listBatalha.Add(jogadores[i].User);
            }

            Array.Sort(pontosBatalha);
            Array.Reverse(pontosBatalha);

            for (int j = 0; j < jogadores.Count; j++)
            {
                int index = jogadores.FindIndex(x => x.VitoriaNavalBattle == pontosBatalha[j] && list.Exists(jogador => x.User == jogador));
                Console.WriteLine($"Jogador(a): {jogadores[index].User} |Jogo Batalha Naval: {pontosBatalha[j]}  ");
                listBatalha.Remove(jogadores[index].User);

            }


            Thread.Sleep(2000);
        }


        public static void DeleteAccount(List<Account> jogadores, string Filepath)
        {
            Console.WriteLine("DELETAR CONTA\n");
            Console.WriteLine("Confirme seu e-mail: ");
            string email = Console.ReadLine();
            Console.WriteLine("Confirme sua senha: ");
            string senha = Console.ReadLine();
            int shearch = jogadores.FindIndex(x => x.User == senha);


            if (shearch != -1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Não foi possível deletar esta conta.");
                Console.WriteLine("MOTIVO: senha incorreta.");
                Console.ResetColor();
                Thread.Sleep(3000);
            }
            else
            {
                Account deletarConta = jogadores.Find(x => x.Email == email);
                jogadores.Remove(deletarConta);
                SerializeJson(jogadores, Filepath);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Conta deletada com sucesso.");
                Console.ResetColor();
                Thread.Sleep(3000);
            }



        }



    }
}