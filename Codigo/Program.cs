using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemperaPaleta;

namespace TemperaPaletaTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Tempera t1 = new Tempera(ConsoleColor.Red, "Alba", 10);
            Tempera t2 = new Tempera(ConsoleColor.Red, "Alba", 20);
            Tempera t3 = new Tempera(ConsoleColor.Blue, "Tito", 30);
            Tempera t4 = new Tempera(ConsoleColor.Blue, "Alba", 40);

            Console.WriteLine(Tempera.Mostrar(t1));
            Console.WriteLine(Tempera.Mostrar(t2));
            Console.WriteLine(Tempera.Mostrar(t3));
            Console.WriteLine(Tempera.Mostrar(t4));

            if(t1 == t2)// son iguales
            {
                Console.WriteLine("Las temperas son iguales.");
            }
            if (t1 != t3)// son distintas
            {
                Console.WriteLine("Las temperas son distintas.");
            }
            if (t1 == t4)// color diferente y marca igual, son distintas
            {
                Console.WriteLine("Las temperas son iguales.");
            }
            else
            {
                Console.WriteLine("Las temperas son distinas.");
            }
            if(t3 != t4)// color igual y marcadiferente, son distintas
            {
                Console.WriteLine("Las temperas son distinas.\n");
            }

            int suma = 1 + t1; // implicit int
            Console.WriteLine(suma);

            t1 += t2;
            Console.WriteLine(Tempera.Mostrar(t1)); // suma de temperas

            t3 += 2;
            Console.WriteLine(Tempera.Mostrar(t3)); // suma de tempera y int

            Paleta p1 = 4; // creo paleta de max 4 colores, con el implicit Paleta

            Console.WriteLine((string)p1); // muestro la paleta vacia, con el explicit String

            p1 += t1; 
            p1 += t3;
            p1 += t4; // agrego temperas distintas a la paleta con la sobrecarga del + (Paleta,Tempera)
            Console.WriteLine((string)p1);// verifico que se haya agregado

            p1 += t2; // agrego una tempera que ya esta en la paleta, entonces se suma a la cantidad que ya tiene
            Console.WriteLine((string)p1);// verifico que se haya sumado

            p1 -= t1; // le resto una tempera que se encuentra en la paleta (t1 =30)
            Console.WriteLine((string)p1);

            p1 -= t2; // le resto a la misma tempera de la paleta (t2 =20), para que de 0 y ver si se quita la tempera
            Console.WriteLine((string)p1);

            Paleta p2 = 3; // creo una nueva paleta
            p2 += t1;
            p2 += t3;
            p2 += new Tempera(ConsoleColor.Yellow, "Nueva", 100);
            p2 += new Tempera(ConsoleColor.Gray, "Nova", 100); // nohaymasespacio, no deberia agregarse
            Console.WriteLine((string)p2);

            Paleta p36 = p1+p2; // sumo las dos paletas, algunas temperas estan en ambas paletas y otras son unicas
            Console.WriteLine((string)p36); 

            Console.ReadKey();

        }
    }
}
