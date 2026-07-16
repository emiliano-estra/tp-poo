using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TP1_EmilianoEstrada
{
    class Configuracion
    {
        public int filas, columnas, velocidad;
        public int Filas {
            set
            {
                filas = value;
            }
            get
            {
                return filas;
            }
        }
        public int Columnas {
            set
            {
                columnas=value;
            }
            get
            {
                return columnas;
            }
        }
        public int Velocidad {
            set
            {
                velocidad = value;
            }
            get
            {
                return velocidad;
            }
        }
        public Configuracion(int filas, int columnas, int velocidad)
        {
            Filas = filas;
            Columnas = columnas;
            Velocidad = velocidad;
        }
    }
    class Copo
    {
        public int x, y;
        public Copo(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public void Mostrar()
        {
            Console.SetCursorPosition(x, y);
            Console.Write("*");
        }
        public void Desplazar()
        {
            y++;
        }
        public void Borrar() { 
        Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Random ran = new Random();
            Console.CursorVisible = false;
            Configuracion tu=new Configuracion(20,10,200);
            List<Copo> c = new List<Copo>();
            List<Copo> cf = new List<Copo>();
            while (true) {
                int lugarcopo = ran.Next(0, tu.Columnas);
                if (!c.Any(t => t.x == lugarcopo && t.y == 0) && !cf.Any(t => t.x == lugarcopo && t.y == 0))
                {
                    c.Add(new Copo(lugarcopo, 0));
                }
                for (int i = c.Count - 1; i >= 0; i--)
                {
                    Copo copos = c[i];
                    copos.Borrar();
                    if (copos.y + 1 >= tu.Filas || cf.Any(t => t.x == copos.x && t.y == copos.y + 1))
                    {
                        cf.Add(copos);
                        c.RemoveAt(i);
                    }
                    else
                    {
                        copos.Desplazar();
                        copos.Mostrar();
                    } 
                }
                foreach (var mos in cf)
                {
                    mos.Mostrar();
                }
                
                for (int i = 0; i < tu.Filas; i++)
                {
                    int columna= cf.Where(t => t.y == i).Select(t => t.x).Distinct().Count();
                    if (columna == tu.Columnas) {
                        foreach (var ho in cf.Where(f=>f.y==i))
                        {
                            Console.SetCursorPosition(ho.x, ho.y);
                            Console.Write(" ");
                        }
                        Thread.Sleep(tu.Velocidad);
                        cf.RemoveAll(f => f.y == i);
                        foreach (var ho in cf)
                        {
                            if(ho.y < i)
                            {
                                ho.Borrar();
                                ho.Desplazar();
                                ho.Mostrar();
                            }
                        }
                    }
                }
                Thread.Sleep(tu.Velocidad);
            }
            Console.ReadKey();
            /*Realizar un programa que represente una simulación de copos de nieve cayendo en la consola, utilizando el símbolo "*" para cada copo.
         El programa debe cumplir con las siguientes condiciones:
         Definir una clase Configuracion que almacene parámetros de la simulación, como la cantidad de filas, columnas y la velocidad de caída de los copos.
         Definir una clase Copo que modele el comportamiento de un copo de nieve. Cada copo debe tener una posición en la consola y un método para mostrarse y desplazarse hacia abajo.
         Usar una lista para administrar todos los copos activos durante la simulación.
         Implementar una lógica que controle la caída de los copos de nieve, evitando que se superpongan en la misma posición.
         Al completarse una fila con copos en todas las columnas, esta debe eliminarse para permitir que continúe la simulación.
         El programa debe ejecutarse en un ciclo continuo, simulando de manera animada la caída de los copos.*/

        }
    }
}
