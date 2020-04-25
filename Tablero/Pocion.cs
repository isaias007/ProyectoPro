using System;
using System.Collections.Generic;
using System.Text;

namespace Tablero
{
    
    public class PocionV:Items
    {
        public int duracionItem;
        public PocionV()
        {
            this.duracionItem = 3;
        }

        public override void display()
        {

            Console.WriteLine("PocionV");

        }
    }
}