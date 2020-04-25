using System;
using System.Collections.Generic;
using System.Text;

namespace Tablero
{
    public class Jugador
    {
        public int x, y;
        public int Puntaje;
        public int movimiento;
        public PocionV efectoPocV;
        public PocionG efectoPocG;
        public Brujula efectoBru;
        public Tablero mapa;
        public Inventario mochila;
        public bool vida;

        public Jugador(int x, int y, Tablero t)
        {
            this.x = x;
            this.y = y;
            this.mapa = t;
            this.mochila= new Inventario();
            this.movimiento = 1;
            this.Puntaje = 0;
            this.vida = true;
        }



        
        public void Effects()
        {
            if (efectoPocV !=null)
            {
                efectoPocV.duracionItem--;
                movimiento = 2;

                if (efectoPocV.duracionItem == 0)
                {
                    
                    efectoPocV = null;
                    movimiento = 1;
                }
                
            }

            if (efectoPocG != null)
            {
                efectoPocG.duracionItem--;
                mapa.Mostrar();
                if (efectoPocG.duracionItem == 0)
                {
                    efectoPocG = null;
                    mapa.Ocultar();
                }
            }

            if (efectoBru!= null)
            {
                efectoBru.duracionItem--;
                efectoBru.uso(this);

                if (efectoBru.duracionItem == 0)
                {
                    efectoBru = null;
                    Console.SetCursorPosition(70, 20);
                    Console.WriteLine("                ");
                    Console.SetCursorPosition(70, 21);
                    Console.WriteLine("                ");
                    Console.SetCursorPosition(70, 22);
                    Console.WriteLine("                ");
                    Console.SetCursorPosition(70, 23);
                    Console.WriteLine("                ");
                    Console.SetCursorPosition(70, 24);
                    Console.WriteLine("                ");
                }

            }

        }
        public void Display()
        {


            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            mochila.Display();

 
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(20, 10);

         
            Console.Write("§");
            
            
        }

        public void MueveIzquierda()
        {

            if (mapa.isSafe(x-1, y) == true && mapa.celdas[x - 1, y].isWalkable()) 
            { 
              x=x-movimiento;
            }

            
        }

        public void MueveArriba()
        {
            
            if (mapa.isSafe(x,y-1)==true && mapa.celdas[x,y-1].isWalkable() )
            {
                y=y-movimiento;
            }

            
        }

        public void MueveAbajo()
        {

            if (mapa.isSafe(x, y + 1) == true && mapa.celdas[x, y + 1].isWalkable())
            {
               y=y+movimiento;
            }
        }

        public void MueveDerecha()
        {

            if (mapa.isSafe(x+1, y) == true && mapa.celdas[x+1, y].isWalkable())
            {
               x=x+movimiento;
            }
        }

       



        public void Choque()
        {
            if (mapa.celdas[x, y].enemigo != null)
            {
                vida = false;
            }

        }



        public void CogerItems()
        {
            if (mapa.celdas[x,y].objeto!=null)
            {

                bool PuedesCoger;

               PuedesCoger = mochila.Añadir(mapa.celdas[x, y].objeto);
                
                
                if (PuedesCoger==true)
                {
             

                if (mapa.celdas[x, y].objeto is Llaves)
                {

                    mapa.llaves--;
                    
                }
                

                    mapa.celdas[x, y].objeto = null;
                }


            }
           
           

        }

        public void selectNextItem()
        {

            mochila.ItemIdex++;
            if (mochila.ItemIdex > mochila.items.Count - 1)
            {
                mochila.ItemIdex = 0;
            }
        }

        public void selectPreviusItem()
        {
            mochila.ItemIdex--;
            if (mochila.ItemIdex < 0)
            {
                mochila.ItemIdex = mochila.items.Count-1;
            }
        }

        public void UsaItem()
        {
 
            mochila.UsarItem(this);
        }

        
        public void Listado()
        {
            Console.SetCursorPosition(41, 2);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Posicion X =" + x);
            Console.SetCursorPosition(41, 3);
            Console.WriteLine("Posicion Y =" + y);
            Console.SetCursorPosition(41, 4);
            Console.WriteLine("Cantidad de Llaves a recoger =" + mapa.llaves);
            Console.SetCursorPosition(70, 2);
            Console.WriteLine("Puntos: " + Puntaje);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(0, 20);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Leyenda");
            Console.SetCursorPosition(0, 22);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("$");
            Console.SetCursorPosition(2, 22);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Te suma 100 puntos cada vez que lo uses");
            Console.SetCursorPosition(0, 23);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("K");
            Console.SetCursorPosition(2, 23);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Son las llaves a recoger");
            Console.SetCursorPosition(0, 24);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("P");
            Console.SetCursorPosition(2, 24);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Una pocion de velocidad aumenta tus pasos");
            Console.SetCursorPosition(0, 25);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("G");
            Console.SetCursorPosition(2, 25);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Una pocion de vision 'Cuidado' da amnesia");
            Console.SetCursorPosition(0, 26);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("X");
            Console.SetCursorPosition(2, 26);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Te ayuda a marcar el suelo y asi saber por donde te has movido");
            Console.SetCursorPosition(0, 27);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("B");
            Console.SetCursorPosition(2, 27);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Es una brujula que en diez pasos te dira donde esta la salida");
            Console.SetCursorPosition(0, 28);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("S");
            Console.SetCursorPosition(2, 28);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("La salida a encontrar 'Puede que este debajo de un item'");
        }
        
        public void Instrucciones()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(0,12);
            Console.WriteLine("INSTRUCCIONES:");
            Console.SetCursorPosition(0,15);
            Console.WriteLine("Los movimientos son con W,A,S,D");
            Console.WriteLine("Los objetos se recogen con el ESPACIO");
            Console.WriteLine("Los objetos se utilizan con el ENTER eligiendolos en el inventario con las flechas de movimiento ARRIBA Y ABAJO");

        }

    }
}