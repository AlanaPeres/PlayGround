using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubDeJogos.Entities
{
    public class Submarine : Navios
    {
        public Submarine()
        {
            string Name = "Submarino";
            int Width = 3;
            ocupacao = Ocupacao.Submarine;
        }

    }
}
