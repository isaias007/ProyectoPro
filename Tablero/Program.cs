
using System;
using System.IO;


namespace Tablero
{
    class Program
    {

        
        ///////////////Creaciones//////////////
        
        public static Jugador P1;
        public static Tablero miTablero;
        public static SpawnEnemys Senemigos;

        static void Main(string[] args)
        {



            Console.ForegroundColor = ConsoleColor.Red;

            if (File.Exists("../../data/Menu.txt"))
            {
                StreamReader archivo;
                String Contenido;

                archivo = new StreamReader("../../data/Menu.txt");
                Contenido = archivo.ReadToEnd();
                Console.WriteLine(Contenido);

                ConsoleKeyInfo pantalla;
                pantalla = Console.ReadKey(true);

                if (pantalla.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    juego();
                }

            }

            

            





            /*-------------------------------------------------------------*/

             void juego()
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                ConsoleKeyInfo opcion;


                ///////////LLamamientos////////////
                miTablero = new Tablero();
                Senemigos = new SpawnEnemys(miTablero);
                
                miTablero.RandomWalker(5000);
                miTablero.PutKey(3);
                miTablero.PutItems(100, new Monedas());
                miTablero.PutItems(50, new PocionV());
                miTablero.PutItems(10, new Marca());
                miTablero.PutItems(10, new PocionG());
                miTablero.PutItems(4, new Brujula());
                miTablero.PutSalida(1);
                ////////////////////////////////////
                /////Esto sirve para hacer una limpieza de imperfecciones al generar el mapa////
                for (int i = 0; i < 2; i++)
                {
                    miTablero.CalculaVecinos();
                    miTablero.QuitaMuros();
                }
                /////Creamos el jugador////////
                P1 = new Jugador(150, 150, miTablero);
                //////////////////////////////
                /////////Generamos los enemigos y los ponemos en el mapa////////
                Senemigos.GenerarEnemigos(30);
                Senemigos.PutEnemigos();
                /////////////////////////////////////////////////
                //////Dibujamos el mapa y el jugador////////
                miTablero.Display(P1.x, P1.y);
                P1.Listado();
                P1.Display();
                //////////////////////////////////
                //////Do while para el movimiento//////
                do
                {


                    while (Console.KeyAvailable == true)
                    {

                        Console.ReadKey(true);

                    }


                    Console.CursorVisible = false;
                    opcion = Console.ReadKey(true);
                    /////////Movimiento y acciones del jugador
                    switch (opcion.Key)
                    {
                        case ConsoleKey.W:
                            P1.MueveArriba();
                            break;
                        case ConsoleKey.S:
                            P1.MueveAbajo();
                            break;
                        case ConsoleKey.A:
                            P1.MueveIzquierda();
                            break;
                        case ConsoleKey.D:
                            P1.MueveDerecha();
                            break;
                        case ConsoleKey.Spacebar:
                            P1.CogerItems();
                            break;
                        case ConsoleKey.Enter:
                            P1.UsaItem();
                            break;
                        case ConsoleKey.UpArrow:
                            P1.selectPreviusItem();
                            break;
                        case ConsoleKey.DownArrow:
                            P1.selectNextItem();
                            break;
                        /////////Condicion para ganar y boton que hay que apretar cuando llegues a la salida////////
                        case ConsoleKey.R:
                            if (miTablero.celdas[P1.x, P1.y].valor == TipoCelda.Salida && miTablero.llaves == 0)
                            {
                                /////////reinicio del mapa cuando se gane un nivel///////
                                Console.Clear();
                                juego();

                            }
                            break;
                    }
                    ////////Revision del choque a los enemigos
                    P1.Choque();
                    /////////Efectos de las pociones y etc.. + movimientos de los enemigos
                    P1.Effects();
                    foreach (IEnemigos enemigos in Senemigos.Enemigos)
                    {
                        enemigos.movimiento();
                    }

                    ////////De nuevo revision de choque de los enemigos///////
                    P1.Choque();
                    ////////Dibujar el mapa y al jugador////////
                    miTablero.Display(P1.x, P1.y);
                    P1.Listado();
                    P1.Display();
                    //////Condicion para salir del juego/////
                } while (opcion.Key != ConsoleKey.Escape && P1.vida == true); 

                if (P1.vida == false)
                {
                    Console.Clear();
                    if (File.Exists("../../data/GameOver.txt"))
                    {
                        StreamReader archivo;
                        String Contenido;

                        archivo = new StreamReader("../../data/GameOver.txt");
                        Contenido = archivo.ReadToEnd();
                        Console.WriteLine(Contenido);

                    }

                }


                Console.ReadKey();

            }
        }
    }


}
