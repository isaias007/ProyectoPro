using System;
using System.Collections.Generic;
using System.Text;

namespace Tablero
{
    public class Brujula:Items
    {
        public int duracionItem;

        public Brujula()
        {
            duracionItem = 10;
        }



        public override void display()
        {
            Console.WriteLine("Brujula");
        }

        public void uso(Jugador j)
        {

            Console.SetCursorPosition(70, 23);
            if (j.x > j.mapa.Sx) Console.Write("<  ");
            else if (j.x < j.mapa.Sx) Console.Write("  >");
            else Console.Write("   ");

            Console.SetCursorPosition(70, 22);
            if (j.y > j.mapa.Sy)
            {
                Console.Write("^");
            }
            else
            {
                Console.Write(" ");
            }


            Console.SetCursorPosition(70, 24);
            if (j.y < j.mapa.Sy)
            {
                Console.Write("v");
            }
            else
            {
                Console.Write(" ");
            }
        }
    }
}