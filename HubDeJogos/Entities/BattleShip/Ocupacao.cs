using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubDeJogos.Entities
{
    public enum Ocupacao
    {   // registra o caractere de exibição usado para cada um desses status.
        [Description(" O ")]
        Empty,

        [Description(" B ")]
        Battleship,

        [Description(" C ")]
        Cruiser,

        [Description(" D ")]
        Destroyer,

        [Description(" S ")]
        Submarine,

        [Description(" A ")]
        Carrier,

        [Description(" X ")]
        Hit,

        [Description(" M ")]
        Miss
    }

    public enum ResultadoDoTiro
    {
        Miss,
        Hit
    }
}
