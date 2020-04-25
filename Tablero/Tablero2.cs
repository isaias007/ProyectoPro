using System;

namespace Tablero
{
    public class Tablero
    {
        
        ///////Inicialisaciones//////
        public Celda[,] celdas;
        public int anchura;
        public int altura;
        public int llaves;
        public int Sx;
        public int Sy;
        



        public Tablero()
        {
            ////Constructor///////
            celdas = new Celda[300, 300];
            anchura = celdas.GetLength(0);
            altura = celdas.GetLength(1);
            
            

            for (int i = 0; i < celdas.GetLength(0); i++)
            {
                for (int j = 0; j < celdas.GetLength(1); j++)
                {

                    celdas[i, j] = new Celda();


                }

            }



        }

        public void Display(int centroX, int centroY)
        {
            /////Display del mapa ///////
            int ventanaX = 40, ventanaY = 20;

            for (int i = 0; i < ventanaX; i++)
            {
                for (int j = 0; j < ventanaY; j++)
                {
                    Console.SetCursorPosition(i, j);

                    int celdaX, celdaY;
                    

                    celdaX = centroX - ventanaX / 2 + i;
                    celdaY = centroY - ventanaY / 2 + j;





                    //////Circulo de vision//////

                    if (celdaX >= 0 && celdaX < anchura && celdaY >= 0 && celdaY < altura)
                    {
                    double distancia = Math.Sqrt(Math.Pow(celdaX - centroX, 2) + Math.Pow(celdaY - centroY, 2));

                        if (distancia < 7)
                        {
                            celdas[celdaX, celdaY].visibilidad = true;
                        }
                        


                        celdas[celdaX, celdaY].Display();
                    }
                    else
                    {
                       
                        Console.Write("-");
                    }
                 

                }
            }
        }

        ///////Calcula Vecios para los muros////// 
      public void CalculaVecinos(int x, int y)
        {
            celdas[x, y].vecinos = 0;
            if (x > 0 && y > 0 && celdas[x - 1, y - 1].valor == TipoCelda.Muro)
            {
                celdas[x, y].vecinos++;
            }

            if (y > 0 && celdas[x, y - 1].valor == TipoCelda.Muro)
            {
                celdas[x, y].vecinos++;
            }

            if (x < 49 && y > 0 && celdas[x + 1, y - 1].valor == TipoCelda.Muro)
            {
                celdas[x, y].vecinos++;
            }

            if (x > 0 && celdas[x - 1, y].valor == TipoCelda.Muro)
            {
                celdas[x, y].vecinos++;
            }


            if (x < 49 && celdas[x + 1, y].valor == TipoCelda.Muro)
            {
                celdas[x, y].vecinos++;
            }


            if (x > 0 && y < 29 && celdas[x - 1, y + 1].valor == TipoCelda.Muro)
            {
                celdas[x, y].vecinos++;
            }

            if (y < 29 && celdas[x, y + 1].valor == TipoCelda.Muro)
            {
                celdas[x, y].vecinos++;
            }

            if (x < 49 && y < 29 && celdas[x + 1, y + 1].valor == TipoCelda.Muro)
            {
                celdas[x, y].vecinos++;
            }

        }
        /// Recursividad del calculaVecinos///
        public void CalculaVecinos()
        {
            for (int x = 0; x < celdas.GetLength(0); x++)
            {
                for (int y = 0; y < celdas.GetLength(1); y++)
                {
                    CalculaVecinos(x, y);


                }
            }

        }
        /// Para borrar muros ///
        public void QuitaMuros()
        {
            for (int x = 0; x < celdas.GetLength(0); x++)
            {
                for (int y = 0; y < celdas.GetLength(1); y++)
                {
                    if (celdas[x, y].valor == TipoCelda.Muro && celdas[x, y].vecinos < 3)
                    {
                        celdas[x, y].valor = TipoCelda.floor;
                    }

                }
            }
           
        }

    
        public void RandomWalker(int tamñ)

        {
            ///Un RandomWalker para generar el mapa///
            int x, y;
            int floor;
            Random r = new Random();
            Random l = new Random();

            for (int i = 0; i < celdas.GetLength(0)-1; i++)
            {
                for (int j = 0; j < celdas.GetLength(1)-1; j++)
                {
                    celdas[i, j].valor = TipoCelda.Muro;
                }
            }

            x = anchura / 2;
            y = altura / 2;


            celdas[x, y].valor = TipoCelda.Muro;
            floor = 1;

            while (floor <=tamñ)
            {
                int longitud = l.Next(6) + 1;
                int direccion = r.Next(4) + 1;


                switch (direccion)
                {
                    case 1:
                            x++;
                        break;
                    case 2:
                            x--;
                        break;
                    case 3:
                            y++;
                        break;
                    case 4:
                            y--;
                        break;
                }

                if (isSafe(x,y)==false)
                {
                    x = anchura / 2;
                    y = altura / 2;
                }


                  
                    celdas[x, y].valor = TipoCelda.floor;
                    floor++;
                

            }


         

        }


        public void PutKey(int quantity)
        {

        ///Para poner las llaves objetivo del juego///
            int a;
            int b;
            Random Key = new Random();

            for (int i = 0; i < quantity; i++)
            {
                do
                {
                    a = Key.Next(celdas.GetLength(0));
                    b = Key.Next(celdas.GetLength(1));

                } while (celdas[a, b].valor !=TipoCelda.floor|| celdas[a,b].objeto!=null);
                llaves++;
                celdas[a, b].objeto= new Llaves();
                
            }


        }
        public void PutSalida(int quantity)
        {
        ///Poner la salida ///
            int a;
            int b;
            Random Salida = new Random();

            for (int i = 0; i < quantity; i++)  
            {
                do
                {
                    a = Salida.Next(celdas.GetLength(0));
                    b = Salida.Next(celdas.GetLength(1));

                    Sx = a;
                    Sy = b;

                } while (celdas[a, b].valor != TipoCelda.floor);
                celdas[a, b].valor = TipoCelda.Salida;

            }


        }

      

        public void PutItems(int quantity, Items item)
        {
        ///Poner los items por el mapa///
            Random r = new Random();

            for (int i = 0; i < quantity; i++)
            {
                int x, y;

                do
                {

                    x = r.Next(this.anchura);
                    y = r.Next(this.altura);


                } while (celdas[x, y].valor != TipoCelda.floor||celdas[x,y].objeto!= null);


                if (item is Monedas)
                {
                    celdas[x, y].objeto = new Monedas();
                }
                else if(item is PocionV)
                {
                    celdas[x, y].objeto = new PocionV();
                }
                else if(item is Marca)
                {
                    celdas[x, y].objeto = new Marca();
                }else if (item is PocionG)
                {
                    celdas[x, y].objeto = new PocionG();
                }else if (item is Brujula)
                {
                    celdas[x, y].objeto = new Brujula();
                }

            }
        }

        public bool isSafe(int x, int y)
            ///Funcion para saber si esta dentro del array///
        {
            if(x>=0 && y>=0 && x<anchura && x < altura)
            {
                return true;
            }
            else
            {
                return false;


            }
        }

        /// Esto sirve para mostrar el mapa al completo y volver a ocultarlo ///
        public void Mostrar()
        {
            for (int i = 0; i < celdas.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < celdas.GetLength(1) - 1; j++)
                {
                    celdas[i, j].visibilidad = true;
                }
            }
        }
        public void Ocultar()
        {
            for (int i = 0; i < celdas.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < celdas.GetLength(1) - 1; j++)
                {
                    celdas[i, j].visibilidad = false;
                }
            }
        }


    }

}

    
