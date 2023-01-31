using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubDeJogos.Entities
{
    public class Battleship : Navios
    {
        public Battleship()
        {
            Nome = "Encouraçado";
            Largura = 4;
            ocupacao = Ocupacao.Battleship;
        }

    }
}
