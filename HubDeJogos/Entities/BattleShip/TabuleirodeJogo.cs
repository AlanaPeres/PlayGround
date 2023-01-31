using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubDeJogos.Entities
{
    public class TabuleirodeJogo //rastreia onde os navios desse jogador são colocados e onde os tiros de seu oponente foram disparados.
    {
        public List<StatusTabuleiro> TabuleiroDeExibicao { get; set; }

        public TabuleirodeJogo()
        {

            TabuleiroDeExibicao = new List<StatusTabuleiro>();
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    TabuleiroDeExibicao.Add(new StatusTabuleiro(i, j));
                }
            }
        }
    }
}
