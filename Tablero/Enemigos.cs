using System;
using System.Collections.Generic;
using System.Text;

namespace Tablero
{
    public interface IEnemigos
    {
        Tablero mapa { get; set; }
        int x { get; set; }
        int y { get; set; }

        void Display();
        void movimiento();


        

    }
}