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
            this.duracionItem = 5;
        }

        public override void display()
        {

            Console.WriteLine("PocionV");

        }
    }
}