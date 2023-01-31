using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubDeJogos.Entities
{
    public abstract class Navios
    {

        public string Nome { get; set; }
        public int Largura { get; set; }
        public int Acertos { get; set; }
        public Ocupacao ocupacao { get; set; }
        public bool EstaAfundado //retorna verdadeiro se o número de acertos que o navio sofreu for maior ou igual à sua largura.
        {
            get
            {
                return Acertos >= Largura;
            }

        }
    }
}
