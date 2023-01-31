using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubDeJogos.Entities
{
    //Representa um local de linha e coluna onde um tiro pode ser disparado (e onde um navio pode ou não existir).
    public class Coordenada
    {
        public int Linha { get; set; }
        public int Coluna { get; set; }

        public Coordenada(int linha, int coluna)
        {
            Linha = linha;
            Coluna = coluna;
        }
    }
    /*sempre que um tiro é disparado, a pessoa que dispara o tiro o faz chamando as coordenadas e, portanto, essa classe não apenas representará as coordenadas no jogo e nos tabuleiros de tiro, mas também as coordenadas que estão sob ataque.*/
}
