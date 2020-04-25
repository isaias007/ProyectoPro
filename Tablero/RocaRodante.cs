using System;
using System.Collections.Generic;
using System.Text;

namespace Tablero
{
    public class RocaRodante : IEnemigos
    {

        public Tablero mapa { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        bool Izq ;
        bool Drc ;

        public RocaRodante()
        {
            this.x = 0;
            this.y = 0;
            this.mapa = null;
            this.Izq = true;
            this.Drc = true;
        }

        

        public void Display()
        {
            
        }

        public void movimiento()
        {
            
            mapa.celdas[x, y].enemigo = null;

            if (mapa.isSafe(x, y) == true && mapa.celdas[x + 1, y].isWalkable() == true && Drc == true)
            {
                Izq = false;
                x++;
                
            }
            if (mapa.isSafe(x, y) == true && mapa.celdas[x - 1, y].isWalkable() == true && Izq == true )
            {
                x--;
                Drc = false;
            }
            if (mapa.isSafe(x, y) == true && mapa.celdas[x - 1, y].isWalkable() == false )
            {
                Drc = true;
                Izq = false;
            }
            if (mapa.isSafe(x, y) == true && mapa.celdas[x + 1, y].isWalkable() == false )
            {
                Izq = true;
                Drc = false;
            }



            mapa.celdas[x, y].enemigo = this;
        }
    }
}