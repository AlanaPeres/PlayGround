using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubDeJogos.Entities
{
    public class Destroyer : Navios
    {

        public Destroyer()
        {

            Nome = "Destroyer";
            Largura = 2;
            ocupacao = Ocupacao.Destroyer;


        }


    }
}
