using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubDeJogos.Entities
{
    public class Cruiser : Navios
    {
        public Cruiser()
        {
            Nome = "Cruzador";
            Largura = 3;
            ocupacao = Ocupacao.Cruiser;
        }

    }
}
