using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubDeJogos.Entities
{
    public static class Extencao
    {
        //fornece todas as casas que estão no quadrado definido pelas coordenadas de linha e coluna passadas
        public static StatusTabuleiro At(this List<StatusTabuleiro> Casas, int linha, int coluna)
        {
            //retorna o primeiro elemento da sequencia de casas q cumpre o predicado.
            return Casas.Where(x => x.coordenadas.Linha == linha && x.coordenadas.Coluna == coluna).First(); //where filtra uma sequencia de valores com base em um predicado.
        }

        //fornece todos os painéis que estão no quadrado definido pelas coordenadas de linha e coluna passada
        public static List<StatusTabuleiro> Range(this List<StatusTabuleiro> Casas, int linhaInicio, int colunaInicio, int linhaFinal, int colunaFinal)
        {
            return Casas.Where(x => x.coordenadas.Linha >= linhaInicio && x.coordenadas.Coluna >= colunaInicio && x.coordenadas.Linha <= linhaFinal && x.coordenadas.Coluna <= colunaFinal).ToList();
        }
    }
}
