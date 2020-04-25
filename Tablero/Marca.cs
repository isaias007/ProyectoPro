using System;
using System.Collections.Generic;
using System.Text;

namespace Tablero
{
    public class Marca : Items
    {
       //public Tablero mapa;

        public Marca()//Tablero t)
        {
            //this.mapa = t;   
        }

        public override void display()
        {

            Console.WriteLine("Marca");
        }


        public void Marcar(Celda c)
        {
            c.valor = TipoCelda.SueloMarc;
            //mapa.celdas[P1x, P1y].valor = TipoCelda.SueloMarc;
        }


    }
}