using System;


namespace Tablero
{
    public class Celda

    {
        ///Inicialisaciones///
        public IEnemigos enemigo;
        public Items objeto;
        public int valor;
        public Boolean visibilidad;
        public int vecinos;
        public int llaves;
        public Celda()
        {
           
            visibilidad = false;
            valor = 0;
            vecinos = 0;
            llaves = 0;
            objeto = null;
            enemigo = null;
        }

        ///Conversion  a muro///
        public void Muro()
        {
            valor = TipoCelda.Muro;
        }

        ///Funcion para saber si es muro o no ///
        public bool isWalkable()
        {
            if (valor == TipoCelda.floor || valor == TipoCelda.Salida || valor==TipoCelda.SueloMarc)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        ///Dibujos de las celdas, objetos y enemigos///
        public void Display()
        {
            if (visibilidad == true)
            {
                if (this.enemigo != null)
                {
                    if (this.enemigo is Zombie)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write("Z");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    else if (this.enemigo is RocaRodante)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write("R");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                }
                else
                {

                    if (this.objeto != null)
                    {

                        if (this.objeto is Marca)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write("x");
                            Console.ForegroundColor = ConsoleColor.Cyan;

                        }
                        else if (this.objeto is PocionV)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write("P");
                            Console.ForegroundColor = ConsoleColor.Cyan;

                        }
                        else if (this.objeto is Llaves)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write("K");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        }
                        else if (this.objeto is Monedas)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write("$");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        }
                        else if (this.objeto is PocionG)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write("G");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        }
                        else if (this.objeto is Brujula)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write("B");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        }

                    }
                    else
                    {
                        switch (valor)
                        {
                            case TipoCelda.Muro:
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write("#");
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                break;
                            case TipoCelda.floor:
                                Console.Write(" ");
                                break;

                            case TipoCelda.Salida:
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.Write("S");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                break;
                            case TipoCelda.SueloMarc:
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("X");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                break;
                        }
                    }
                }
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("F");
                Console.ForegroundColor = ConsoleColor.Cyan;
            }



        }
    }
}