using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubDeJogos.Entities
{
    public class StatusTabuleiro
    {
        public Ocupacao ocupacao { get; set; }
        public Coordenada coordenadas { get; set; }

        public StatusTabuleiro(int linha, int coluna)
        {
            coordenadas = new Coordenada(linha, coluna);
            ocupacao = Ocupacao.Empty;
        }

        public string Status
        {
            get
            {
                return ocupacao.GetAttributeOfType<DescriptionAttribute>().Description;
            }


        }

        //IsOccupiedpropriedade é usada para determinar onde colocar os navios.
        public bool IsOccupied
        {
            get
            {
                return (ocupacao == Ocupacao.Battleship) || (ocupacao == Ocupacao.Destroyer) || (ocupacao == Ocupacao.Cruiser) || (ocupacao == Ocupacao.Submarine) || (ocupacao == Ocupacao.Carrier);
            }

        }
        //IsRandomAvailablenos designa cada posição onde as coordenadas de linha e coluna são ímpares, ou ambas as posições são pares, como estando disponíveis para uma seleção de tomada "aleatória".
        public bool IsRandomAvailable
        {
            get
            {
                return coordenadas.Linha % 2 == 0 && coordenadas.Coluna % 2 == 0 || (coordenadas.Linha % 2 == 1 && coordenadas.Coluna % 2 == 1);
            }

        }
    }
}
