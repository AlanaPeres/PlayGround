using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubDeJogos.Entities
{
    internal class Menu
    {
        public static void MenuInicial(List<Account> jogadores, string Filepath)
        {


            int option;

            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("    ____  __            ______                           __   ______  __ __ ");
                Console.WriteLine("   / __ \\/ /___ ___  __/ ____/________  __  ______  ____/ /  / ____/_/ // /_");
                Console.WriteLine("  / /_/ / / __ `/ / / / / __/ ___/ __ \\/ / / / __ \\/ __  /  / /   /_  _  __/");
                Console.WriteLine(" / ____/ / /_/ / /_/ / /_/ / /  / /_/ / /_/ / / / / /_/ /  / /___/_  _  __/ ");
                Console.WriteLine("/_/   /_/\\__,_/\\__, /\\____/_/   \\____/\\__,_/_/ /_/\\__,_/   \\____/ /_//_/    ");
                Console.WriteLine("              /____/                                                        ");

                Console.WriteLine("\nTodos os jogos foram desenvolvidos para praticar a linguagem e se divertir");
                Console.ResetColor();
                Console.WriteLine("\n0 - Encerrar Programa");
                Console.WriteLine("1 - Cadastrar novo jogador.");
                Console.WriteLine("2 - Jogar.");

                option = int.Parse(Console.ReadLine());


                switch (option)
                {
                    case 0: Environment.Exit(0); break;

                    case 1:
                        Account.CreateNewAccount(jogadores, Filepath);
                        break;
                    case 2:
                        Account.Login(jogadores, Filepath);
                        break;

                    default:
                        Console.WriteLine("Opção inválida! ");

                        break;
                }

            } while (option != 0);


        }

        public static void MenuHub(List<Account> jogadores, string Filepath)
        {
            int option;
            do
            {

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("    ____  __            ______                           __   ______  __ __ ");
                Console.WriteLine("   / __ \\/ /___ ___  __/ ____/________  __  ______  ____/ /  / ____/_/ // /_");
                Console.WriteLine("  / /_/ / / __ `/ / / / / __/ ___/ __ \\/ / / / __ \\/ __  /  / /   /_  _  __/");
                Console.WriteLine(" / ____/ / /_/ / /_/ / /_/ / /  / /_/ / /_/ / / / / /_/ /  / /___/_  _  __/ ");
                Console.WriteLine("/_/   /_/\\__,_/\\__, /\\____/_/   \\____/\\__,_/_/ /_/\\__,_/   \\____/ /_//_/    ");
                Console.WriteLine("              /____/                                                        ");
                Console.ResetColor();
                Console.WriteLine("\n0 - Voltar ao menu inicial.");
                Console.WriteLine("1 - Apresentar Ranking.");
                Console.WriteLine("2 - Jogo da Velha.");
                Console.WriteLine("3 - Xadrez.");
                Console.WriteLine("4 - Batalha Naval.");
                Console.WriteLine("5 - Alterar senha.");
                Console.WriteLine("6 - Excluir conta.");

                option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 0: Menu.MenuInicial(jogadores, Filepath); break;

                    case 1:
                        Account.Ranking(jogadores, Filepath);
                        break;
                    case 2:
                        Tabuleiro board = new Tabuleiro();
                        board.MenuVelha(jogadores, Filepath);
                        break;
                    case 3: Menu.MenuXadrez(jogadores, Filepath);
                        
                        break;

                    case 4:
                        //Game game1 = new Game();
                        break;
                    case 5:
                        Account.UpdatePassword(jogadores, Filepath);
                        break;
                    case 6:
                        Account.DeleteAccount(jogadores, Filepath);
                        break;

                    default:
                        Console.WriteLine("Opção inválida! ");

                        break;
                }

            } while (option != 0);

        }

        public static void MenuXadrez(List<Account> jogadores, string Filepath)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("__   __          _              ");
            Console.WriteLine("\\ \\ / /         | |             ");
            Console.WriteLine(" \\ V /  __ _  __| |_ __ ___ ____");
            Console.WriteLine(" /   \\ / _` |/ _` | '__/ _ \\_  /");
            Console.WriteLine("/ /^\\ \\ (_| | (_| | | |  __// / ");
            Console.WriteLine("\\/   \\/\\__,_|\\__,_|_|  \\___/___|");
            Console.ResetColor();
            Console.WriteLine("\n0 - Voltar ao menu inicial.");
            Console.WriteLine("1 - Iniciar partida.");

            string option = Console.ReadLine();

            switch (option)
            {
                case "0": Menu.MenuInicial(jogadores, Filepath); break;

                case "1":

                    Match.StartPlay(jogadores, Filepath);
                    break;

                default:
                    Console.WriteLine("Opção inválida! ");

                    break;
            }


        }

        public static void MenuBatalhaNaval(List<Account> jogadores, string Filepath)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("______       _        _ _             _   _                  _ ");
            Console.WriteLine("| ___ \\     | |      | | |           | \\ | |                | |");
            Console.WriteLine("| |_/ / __ _| |_ __ _| | |__   __ _  |  \\| | __ ___   ____ _| |");
            Console.WriteLine("| ___ \\/ _` | __/ _` | | '_ \\ / _` | | . ` |/ _` \\ \\ / / _` | |");
            Console.WriteLine("| |_/ / (_| | || (_| | | | | | (_| | | |\\  | (_| |\\ V / (_| | |");
            Console.WriteLine("\\____/ \\__,_|\\__\\__,_|_|_| |_|\\__,_| \\_| \\_/\\__,_| \\_/ \\__,_|_|");
            Console.ResetColor();
            Console.WriteLine("\n0 - Voltar ao menu inicial.");
            Console.WriteLine("1 - Iniciar partida.");

            string option = Console.ReadLine();

            switch (option)
            {
                case "0": Menu.MenuInicial(jogadores, Filepath); break;

                case "1":

                    break;

                default:
                    Console.WriteLine("Opção inválida! ");

                    break;
            }
        }
    }
}