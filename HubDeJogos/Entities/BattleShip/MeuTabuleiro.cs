using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubDeJogos.Entities
{
    //rastreia os tiros de cada jogador e se foram acertados ou errados.
    public class MeuTabuleiro : TabuleirodeJogo
    {

        public List<Coordenada> CasasAleatoriasDisponiveis()
        {
            return TabuleiroDeExibicao.Where(x => x.ocupacao == Ocupacao.Empty && x.IsRandomAvailable).Select(x => x.coordenadas).ToList();
        }

        public List<Coordenada> ObterNaviosAtingidos()
        {
            List<StatusTabuleiro> tab = new List<StatusTabuleiro>();

            var hits = TabuleiroDeExibicao.Where(x => x.ocupacao == Ocupacao.Hit);
            foreach (var hit in hits)
            {
                tab.AddRange(ObterNaviosVizinhos(hit.coordenadas).ToList());
            }
            return tab.Distinct().Where(x => x.ocupacao == Ocupacao.Empty).Select(x => x.coordenadas).ToList();
        }

        public List<StatusTabuleiro> ObterNaviosVizinhos(Coordenada coordinates)
        {
            int linha = coordinates.Linha;
            int coluna = coordinates.Coluna;
            List<StatusTabuleiro> panels = new List<StatusTabuleiro>();
            if (coluna > 1)
            {
                panels.Add(panels.At(linha, coluna - 1));
            }
            if (linha > 1)
            {
                panels.Add(panels.At(linha - 1, coluna));
            }
            if (linha < 10)
            {
                panels.Add(panels.At(linha + 1, coluna));
            }
            if (coluna < 10)
            {
                panels.Add(panels.At(linha, coluna + 1));
            }
            return panels;
        }



    }
}
