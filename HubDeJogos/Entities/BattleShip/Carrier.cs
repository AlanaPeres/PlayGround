using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubDeJogos.Entities
{
    public class Carrier : Navios
    {
        public Carrier()
        {
            Nome = "Aircraft Carrier";
            Largura = 5;
            ocupacao = Ocupacao.Carrier;
        }


    }
}
