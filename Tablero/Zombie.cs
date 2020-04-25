using System;
using System.Collections.Generic;
using System.Text;

namespace Tablero
{
    public class Zombie : IEnemigos
    {


        public Tablero mapa { get; set; }
        public int x { get; set; }
        public int y { get; set; }

         public Zombie()
        {
            this.x = 0;
            this.y = 0;
            this.mapa = null;
        }       
        
        public void Display()
        {
           
        }

        public void movimiento()
        {
            int direccion;    
            Random r = new Random();


            direccion = r.Next(4)+1;
            mapa.celdas[x, y].enemigo = null;
            switch (direccion)
            {
                
                case 1:
                    if (mapa.isSafe(x, y) == true && mapa.celdas[x + 1, y].isWalkable() == true)
                    {
                        x++;
                    }
                    
                    break;
                case 2:
                    if (mapa.isSafe(x, y) == true && mapa.celdas[x - 1, y].isWalkable() == true)
                    {
                        x--;
                    }
                    break;
                case 3:
                    if (mapa.isSafe(x, y) == true && mapa.celdas[x, y+1].isWalkable() == true)
                    {
                        y++;
                    }
                    break;
                case 4:
                    if (mapa.isSafe(x, y) == true && mapa.celdas[x, y-1].isWalkable() == true)
                    {
                        y--;
                    }
                    break;
            }
            mapa.celdas[x, y].enemigo = this;


        }
    }
}