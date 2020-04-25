using System;
using System.Collections.Generic;
using System.Text;

namespace Tablero
{
    public class SpawnEnemys
    {
        public List<IEnemigos> Enemigos;
        public Tablero mapa;

        public SpawnEnemys(Tablero t)
        {
            Enemigos = new List<IEnemigos>();
            this.mapa = t;
        }



        public void GenerarEnemigos(int cantidad)
        {
            Random r = new Random();
            for (int i = 0; i < cantidad; i++)
            {
                if (r.Next(10) < 5)
                {

                    Enemigos.Add(new Zombie());

                }
                else
                {
                    Enemigos.Add(new RocaRodante());
                }
            }
          
        }

        public void PutEnemigos()
        {
            Random r = new Random();

            for (int i = 0; i < Enemigos.Count; i++)
            {
                int x, y;

                do
                {

                    x = r.Next(this.mapa.celdas.GetLength(0));
                    y = r.Next(this.mapa.celdas.GetLength(1));


                } while (mapa.celdas[x, y].valor != TipoCelda.floor || mapa.celdas[x, y].enemigo != null);


                mapa.celdas[x, y].enemigo = Enemigos[i];

                Enemigos[i].x = x;
                Enemigos[i].y = y;
                Enemigos[i].mapa = this.mapa;





            }


        
        }
    }
}