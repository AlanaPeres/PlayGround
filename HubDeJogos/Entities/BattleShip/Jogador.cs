using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HubDeJogos.Entities
{
    public class Jogador
    { //cada jogador precisa de uma coleção de navios, uma instancia de GameBoard, FiringBoard e uma bandeira que dirá se ele perdeu ou não 
        public string Name;
        public string Vez { get; set; }
        public string Jogador1;
        public string Jogador2;
        public TabuleirodeJogo tabuleiroDeJogo { get; set; }
        public MeuTabuleiro meuTabuleiro { get; set; }
        public List<Navios> Navios { get; set; }
        public bool Perdeu
        {
            get
            {
                return Navios.All(x => x.EstaAfundado);
            }
        }
        public Jogador(string name)
        {
            
            Vez = Jogador1;
            Navios = new List<Navios>()
                {

                    new Destroyer(),
                    new Submarine(),
                    new Cruiser(),
                    new Battleship(),
                    new Carrier()
                };
            tabuleiroDeJogo = new TabuleirodeJogo();
            meuTabuleiro = new MeuTabuleiro();
        }

        public void InvertPlayer()
        {
            if(Vez == Jogador1)
            {
                Vez = Jogador2;
            }
            else
            {
                Vez = Jogador1;
            }

        }

        //envia o tabuleiro atual para a linha de comando
        public void TabuleiroDeSaida() // mostra onde estão os navios
        {
            Console.WriteLine();

            Console.WriteLine("Meus Navios:                                                                     Tabuleiro de Ataque:");
            for (int linha = 1; linha <= 10; linha++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(10 - linha + " "); // para imprimir o número das linhas.
                Console.ResetColor();
                for (int ownColun = 1; ownColun <= 10; ownColun++)
                {
                    Console.Write(tabuleiroDeJogo.TabuleiroDeExibicao.At(linha, ownColun).Status);
                }
                Console.Write("                                                ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(10 - linha + " "); // para imprimir o número das linhas.
                Console.ResetColor();
                for (int colunaDeTiro = 1; colunaDeTiro <= 10; colunaDeTiro++)
                {
                    Console.Write(meuTabuleiro.TabuleiroDeExibicao.At(linha, colunaDeTiro).Status);
                }
                Console.WriteLine(Environment.NewLine);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   A  B  C  D  E  F  G  H  I  J                                                    A  B  C  D  E  F  G  H  I  J");
            Console.ResetColor();
            Console.WriteLine(Environment.NewLine);
        }
        //Seleciona uma combinação aleatória de linha/coluna, em seguida, se nenhuma das casas propostas estiverem ocupadas, coloca o navio
        public void ColocarNavios()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());

            foreach (var navios in Navios)
            {

                bool estaLivre = true;
                while (estaLivre)
                {
                    //Selecione uma orientação (horizontal ou vertical) aleatoriamente.
                    var colunaInicial = rand.Next(1, 11); //Next retorna um número inteiro do intervalo
                    var linhaInicial = rand.Next(1, 11);
                    int endrow = linhaInicial, colunaFinal = colunaInicial;
                    var orientacao = rand.Next(1, 101) % 2; //0 for Horizontal

                    List<int> numeroDeCasas = new List<int>();
                    //Tente colocar o navio nos painéis propostos. Se algum desses painéis já estiver ocupado ou fora dos limites do tabuleiro de jogo, comece de 1.
                    if (orientacao == 0)
                    {
                        for (int i = 1; i < navios.Largura; i++)
                        {
                            endrow++;
                        }
                    }
                    else
                    {
                        for (int i = 1; i < navios.Largura; i++)
                        {
                            colunaFinal++;
                        }
                    }

                    //Não podemos colocar navios além dos limites do tabuleiro
                    if (endrow > 10 || colunaFinal > 10)
                    {
                        estaLivre = true;
                        continue; //Reinicie o loop while para selecionar um novo painel aleatório
                    }

                    //Verifique se os painéis especificados estão ocupados
                    var casasDesocupadas = tabuleiroDeJogo.TabuleiroDeExibicao.Range(linhaInicial, colunaInicial, endrow, colunaFinal);

                    if (casasDesocupadas.Any(x => x.IsOccupied))
                    {
                        estaLivre = true;
                        continue;
                    }

                    foreach (var panel in casasDesocupadas)
                    {
                        panel.ocupacao = navios.ocupacao;
                    }
                    estaLivre = false;
                }
            }
        }

        public Coordenada RecebendoPosicaodeTiro()
        {
            Console.WriteLine("Vamos atirar em qual posição comandante ?");
            string posicao = Console.ReadLine().ToUpper();
            int coluna = posicao[0];
            int linha = int.Parse(posicao[1] + "");

            while (linha < 0 || linha > 10 || coluna < 0 || coluna > 10)
            {
                Console.WriteLine("Posição inválida, atire novamente: ");
                posicao = Console.ReadLine();

            }

            Coordenada coords = new Coordenada(linha, coluna);
            ReagindoATiros(coords);
            return coords;
            
        }
    
        public ResultadoDoTiro ReagindoATiros(Coordenada coords)
        {
            
            //Localiza o painel de destino no GameBoard
            var panel = tabuleiroDeJogo.TabuleiroDeExibicao.At(coords.Linha, coords.Coluna);

            //Se o painel não estiver ocupado por um navio
            if (!panel.IsOccupied)
            {
                
                Console.WriteLine(Vez + " Fui atingido!!\"");
                return Entities.ResultadoDoTiro.Miss;
            }

            //Se o painel ESTÁ ocupado por uma navio, determine qual.
            var navio = Navios.First(x => x.ocupacao == panel.ocupacao);

            //Incrementar o contador de visitas
            navio.Acertos++;

            //Chamar um hit
            Console.WriteLine(Vez + " Hit!");

            //Se o navio agora está afundado, diga qual navio foi afundado
            if (navio.EstaAfundado)
            {
                Console.WriteLine(Vez + " diz: \"Você afundou meu" + navio.Nome + "!\"");
            }

            //Para um hit ou um afundado, retorne um status de Hit
            return Entities.ResultadoDoTiro.Hit;
        }
        //ProcessShotResult vai passar o resultado do chute do jogador defensor (que chama "Hit" ou "Miss") para o jogador atacante.
        public void ResultadoDoTiro(Coordenada coords, ResultadoDoTiro result)
        {

            var casa = meuTabuleiro.TabuleiroDeExibicao.At(coords.Linha, coords.Coluna);
            switch (result)
            {
                case Entities.ResultadoDoTiro.Hit:
                    casa.ocupacao = Ocupacao.Hit;
                    break;

                default:
                    casa.ocupacao = Ocupacao.Miss;
                    break;
            }
        }
    }
}
