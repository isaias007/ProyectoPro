using System;
using System.Collections.Generic;
using System.Text;

namespace Tablero
{
    public class PocionG:Items
    {
        public int duracionItem;

        public PocionG()
        {
            this.duracionItem = 3;
        }


        public override void display()
        {
            Console.WriteLine("PocionG");
        }
    }
}