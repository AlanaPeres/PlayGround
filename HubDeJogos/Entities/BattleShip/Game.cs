using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubDeJogos.Entities
{
    public class Game
    {
        public Jogador Player1 { get; set; }
        public Jogador Player2 { get; set; }

        public Game()
        {

            Player1 = new Jogador("jogador1");
            Player2 = new Jogador("jogador2");

            Player1.ColocarNavios();
            Player2.ColocarNavios();

            Player1.TabuleiroDeSaida();
            Player2.TabuleiroDeSaida();

        }

        //public void PlayRound()
        //{
        //    var coordinates = Player1.Tiros();
        //    var result = Player2.ReagindoATiros(coordinates);
        //    Player1.ResultadoDoTiro(coordinates, result);

        //    if (!Player2.Perdeu) //Se o jogador 2 já perdeu,não podemos deixá-los dar outra volta.

        //    {
        //        coordinates = Player2.Tiros();
        //        result = Player1.ReagindoATiros(coordinates);
        //        Player2.ResultadoDoTiro(coordinates, result);
        //    }
        //}

        public void PlayToEnd()
        {
            Game game1 = new Game();

            while (Player1.Perdeu || Player2.Perdeu)
            {
                Player1.TabuleiroDeSaida();
                Player2.TabuleiroDeSaida();

            }

            Player1.TabuleiroDeSaida();
            Player2.TabuleiroDeSaida();

            if (Player1.Perdeu)
            {
                Console.WriteLine(Player2.Name + " ganhou o jogo!");
            }
            else if (Player2.Perdeu)
            {
                Console.WriteLine(Player1.Name + " ganhou o jogo!");
            }
        }
    }
}
