using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HubDeJogos.Entities
{
    internal class Tabuleiro
    {
        Velha Velha = new Velha();

        public void InputPosition(List<Account> jogadores, string Filepath)
        {
            Console.WriteLine("\n\nVez do Jogador " +
                (Velha.currentPlayer == 'X' ? Velha.Player1 : Velha.Player2));

            Console.WriteLine("Digite a posição");
            if (!char.TryParse(Console.ReadLine(), out char position))
            {
                Console.WriteLine("Posição inválida");
                InputPosition(jogadores, Filepath);
            }

            if (Velha.AddPosition(position, jogadores, Filepath))
                ShowBoard(jogadores, Filepath);
            else
                ShowWinner(jogadores, Filepath);
        }

        public void ShowWinner(List<Account> jogadores, string Filepath)
        {
            int status = Velha.CheckEarned(jogadores, Filepath);

            if (status > 0 && status < 3)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"O jogador {(status == 1 ? Velha.Player1 : Velha.Player1)} ganhou");
                Console.ResetColor();
                Thread.Sleep(3000);
                

            }
            else if (status == 0)
                Console.WriteLine("Deu velha!");

            Velha.board = Velha.ResetBoard();
        }



        public void ShowBoard(List<Account> jogadores, string Filepath)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("   ___                         _         _   _      _ _           ");
            Console.WriteLine("  |_  |                       | |       | | | |    | | |          ");
            Console.WriteLine("    | | ___   __ _  ___     __| | __ _  | | | | ___| | |__   __ _ ");
            Console.WriteLine("    | |/ _ \\ / _` |/ _ \\   / _` |/ _` | | | | |/ _ \\ | '_ \\ / _` |");
            Console.WriteLine("/\\__/ / (_) | (_| | (_) | | (_| | (_| | \\ \\_/ /  __/ | | | | (_| |");
            Console.WriteLine("\\____/ \\___/ \\__, |\\___/   \\__,_|\\__,_|  \\___/ \\___|_|_| |_|\\__,_|");
            Console.WriteLine("              __/ |                                               ");
            Console.WriteLine("             |___/                                                ");
            Console.ResetColor();
            Console.WriteLine("\n\n");

            for (int linha = 0; linha < Velha.board.GetLength(0); linha++)
            {
                for (int coluna = 0; coluna < Velha.board.GetLength(1); coluna++)
                {
                    Console.Write($"\t|{Velha.board[linha, coluna]}|");
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\t-------------------");
                Console.ResetColor();
            }
            InputPosition(jogadores, Filepath);
        }

        public void InputPlayer(List<Account> jogadores, string Filepath)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("   ___                         _         _   _      _ _           ");
            Console.WriteLine("  |_  |                       | |       | | | |    | | |          ");
            Console.WriteLine("    | | ___   __ _  ___     __| | __ _  | | | | ___| | |__   __ _ ");
            Console.WriteLine("    | |/ _ \\ / _` |/ _ \\   / _` |/ _` | | | | |/ _ \\ | '_ \\ / _` |");
            Console.WriteLine("/\\__/ / (_) | (_| | (_) | | (_| | (_| | \\ \\_/ /  __/ | | | | (_| |");
            Console.WriteLine("\\____/ \\___/ \\__, |\\___/   \\__,_|\\__,_|  \\___/ \\___|_|_| |_|\\__,_|");
            Console.WriteLine("              __/ |                                               ");
            Console.WriteLine("             |___/                                                ");
            Console.ResetColor();
            Console.WriteLine("\n\n");

            Console.WriteLine("\nDigite o login do Jogador 1 ((X))");
            Velha.Player1 = Console.ReadLine() + "(X)";
            Console.WriteLine("SENHA: ");
            string senha = Console.ReadLine();

            int shearch = jogadores.FindIndex(x => x.User == Velha.Player1 && x.Password == senha);

            while(shearch == -1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Não foi possível iniciar partida.");
                Console.WriteLine("MOTIVO: usuário ou senha inválidos.");
                Console.ResetColor();
                Thread.Sleep(3000);
                InputPlayer(jogadores,Filepath);
            }

            Console.WriteLine("Digite o login do Jogador 2 ((O))");
            Velha.Player2 = Console.ReadLine() + "(O)";
            Console.WriteLine("SENHA: ");
            string senha2 = Console.ReadLine();

            int shearch2 = jogadores.FindIndex(x => x.User == Velha.Player2 && x.Password == senha2);

            while (shearch2 == -1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Não foi possível iniciar partida.");
                Console.WriteLine("MOTIVO: usuário ou senha inválidos.");
                Console.ResetColor();
                Thread.Sleep(3000);
                InputPlayer(jogadores, Filepath);
            }

            ShowBoard(jogadores, Filepath);
        }

        public void BackMenu(List<Account> jogadores, string Filepath)
        {
            Console.WriteLine("\n Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
            Console.Clear();
            MenuVelha(jogadores, Filepath);
        }



        public void MenuVelha(List<Account> jogadores, string Filepath)
        {

            int option;
            do
            {

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("   ___                         _         _   _      _ _           ");
                Console.WriteLine("  |_  |                       | |       | | | |    | | |          ");
                Console.WriteLine("    | | ___   __ _  ___     __| | __ _  | | | | ___| | |__   __ _ ");
                Console.WriteLine("    | |/ _ \\ / _` |/ _ \\   / _` |/ _` | | | | |/ _ \\ | '_ \\ / _` |");
                Console.WriteLine("/\\__/ / (_) | (_| | (_) | | (_| | (_| | \\ \\_/ /  __/ | | | | (_| |");
                Console.WriteLine("\\____/ \\___/ \\__, |\\___/   \\__,_|\\__,_|  \\___/ \\___|_|_| |_|\\__,_|");
                Console.WriteLine("              __/ |                                               ");
                Console.WriteLine("             |___/                                                ");
                Console.ResetColor();
                Console.WriteLine("\n0 - Voltar ao menu inicial.");
                Console.WriteLine("1 - Iniciar partida.");

                option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 0: Menu.MenuInicial(jogadores, Filepath); break;

                    case 1:
                        Velha partida = new Velha();
                        InputPlayer(jogadores, Filepath);

                        break;

                    default:
                        Console.WriteLine("Opção inválida! ");

                        break;
                }

            } while (option != 0);
        }

    }

}

