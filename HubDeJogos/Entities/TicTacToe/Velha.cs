using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Data;

namespace HubDeJogos.Entities
{
    internal class Velha
    {
        public char[,] board = new char[3, 3] { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };
        public char currentPlayer = 'X';
        public string Player1, Player2;
        public string Vez;

        public bool AddPosition(char position, List<Account> jogadores, string Filepath)
        {
            for (int row = 0; row < board.GetLength(0); row++)
                for (int column = 0; column < board.GetLength(1); column++)
                    if (board[row, column] == position)
                    {
                        board[row, column] = currentPlayer;
                        currentPlayer = InvertPlayer();
                    }

            if (CheckEarned(jogadores, Filepath) != 3)
                return false;

            return true;
        }

        public int CheckEarned(List<Account> jogadores, string Filepath)
        {
            string result = "";

            //CheckMainDiagonal
            for (int linha = 0; linha < board.GetLength(0); linha++)
            {
                result += board[linha, linha];

                if (result == "XXX")
                    return 1;
                else if (result == "OOO")
                    return 2;
            }

            //CheckSecondaryDiagonal
            result = "";
            for (int linha = 0; linha < board.GetLength(0); linha++)
            {
                result += board[linha, board.GetLength(0) - 1 - linha];

                if (result == "XXX")
                    return 1;
                else if (result == "OOO")
                    return 2;
            }

            //CheckRowsColumns
            for (int i = 0; i < board.GetLength(0); i++)
            {
                string linha = $"{board[i, 0]}{board[i, 1]}{board[i, 2]}";

                string coluna = $"{board[0, i]}{board[1, i]}{board[2, i]}";

                if (linha == "XXX" || coluna == "XXX")
                    return 1;
                else if (linha == "OOO" || coluna == "OOO")
                    return 2;
            }

            //CheckTie
            for (int linha = 0; linha < board.GetLength(0); linha++)
                for (int column = 0; column < board.GetLength(1); column++)
                    if (board[linha, column] == ResetBoard()[linha, column])
                        return 3;
            AtribuirResultado(jogadores, Filepath);
            return 0;
        }

        public void AtribuirResultado(List<Account> jogadores, string Filepath)
        {

            if (Vez == Player1)
            {
                Account shearch = jogadores.Find(x => x.User == Vez);
                shearch.VitoriaTicTacToe++;
                Account.SerializeJson(jogadores, Filepath);

            }
            else
            {
                Account shearch = jogadores.Find(x => x.User == Vez);
                shearch.VitoriaTicTacToe++;
                Account.SerializeJson(jogadores, Filepath);
            }

        }


        public char InvertPlayer()
        {
            if (currentPlayer == 'X')
            {

                Vez = Player2;
                return 'O';
                
            }
            else
            {
                Vez = Player1;
                return 'X';
                
            }
        }
        public char[,] ResetBoard() => new char[3, 3] { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };



    }
}
