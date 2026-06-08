using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniRedSocial
{
    internal class GrafoNPND
    {
        private int[,] red;

        public GrafoNPND(int cantPers) {
            red = new int[cantPers, cantPers];
        }

        public void Conectar(int orig, int dest) { //Conexión ND de Amistad Social
            red[orig, dest] = 1;
            red[dest, orig] = 1;
        }

        public bool SonAmigos(int orig, int dest, int cant) //Recorrido en amplitud BFS
        {
            bool[] visitado = new bool[cant];
            Queue<int> cola = new Queue<int>();

            visitado[orig] = true;
            cola.Enqueue(orig);

            while (cola.Count>0)
            {
                int actual = cola.Dequeue();
                if (actual == dest) return true;

                for (int i=0; i<cant; i++)
                {
                    if (red[actual, i] == 1 && !visitado[i]) {
                        visitado[i] = true;
                        cola.Enqueue(i);
                    }
                }
            }
            return false;
        }
    }
}
