using System;
using System.Collections.Generic;
using System.Text;

namespace Tablero
{
    public class Inventario
    {

        ///Inicialisacion, ArrayList///
        public List<Items> items;
        public int Tamañoinv;
        public int ItemIdex;

        ///Constructor///
        public Inventario()
        {
            ItemIdex = -1;
            items = new List<Items>();
            Tamañoinv = 5;

        }
        ///Display del inventario que tiene el jugador///
        public void Display()
        {
            
            for (int i = 0; i < items.Count; i++)
            {

                if (i != ItemIdex)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;

                    
                }
                Console.SetCursorPosition(41, 7 + i);
                items[i].display();
            }

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(41, 7 + items.Count);
            Console.WriteLine("       ");
        }
        ///Funcion para añadir el objeto al inventario///
        public bool Añadir(Items objeto)
        {
            if (items.Count<Tamañoinv) 
            {
                items.Add(objeto);
                return true;
            }
            else
            {
                return false;
            }
        }
        ///Funcion que selecciona el item del inventario///
        public void SelectItem(int NumeroItem)
        {
            ItemIdex = NumeroItem;
        }

        ///Funcion de los usos de los items///
        public bool UsarItem(Jugador J)
        {
            if (ItemIdex!=-1 && items.Count>0) {
                Items objeto = items[ItemIdex];
                if (objeto is Marca)
                {
                    (objeto as Marca).Marcar(J.mapa.celdas[J.x,J.y]);
                    this.BorrarItem(ItemIdex);
                    return true;

                }
                else if (objeto is Monedas)
                {
                    J.Puntaje= J.Puntaje + 100;
                    this.BorrarItem(ItemIdex);
                    return true;
                }
                else if (objeto is Llaves)
                {
                    return true;
                }else if (objeto is PocionV)
                {
                    J.efectoPocV = objeto as PocionV;
                    this.BorrarItem(ItemIdex);
                    return true;
                }else if (objeto is PocionG)
                {
                    J.efectoPocG = objeto as PocionG;
                    this.BorrarItem(ItemIdex);
                    return true;
                }else if (objeto is Brujula)
                {
                    J.efectoBru = objeto as Brujula;
                    (objeto as Brujula).uso(J);
                    this.BorrarItem(ItemIdex);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        ///Funcion para borrar los items del arraylist///

        public void BorrarItem( int NumeroItem)
        {
            items.RemoveAt(NumeroItem);
            if (ItemIdex >= items.Count)
            {
                ItemIdex = items.Count - 1;
            }

        }





    }
}