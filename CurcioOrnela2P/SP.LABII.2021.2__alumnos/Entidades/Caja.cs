using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    ///Crear, en EntidadesSP, la clase Caja<T>, dónde T sea de tipo Zapato, Fósforo o Remedio.
    ///atributos: capacidad:int y elementos:List<T> (TODOS protegidos)        
    ///Propiedades:
    ///Elementos:(sólo lectura) expone al atributo de tipo List<T>.
    ///PrecioTotal:(sólo lectura) retorna el precio total de la caja (la suma de los precios de sus elementos).
    ///Constructor
    ///Caja(), Caja(int); 
    ///El constructor por default es el único que se encargará de inicializar la lista.
    ///Métodos:
    ///ToString: Mostrará en formato de tipo string: 
    ///.-el tipo de caja, la capacidad, la cantidad actual de elementos, el precio total y el listado completo 
    ///de todos los elementos contenidos en la misma. Reutilizar código.
    ///Sobrecarga de operadores:
    ///(+) Será el encargado de agregar elementos a la caja, 
    ///siempre y cuando no supere la capacidad máxima de la misma.
    public class Caja<T> where T:Producto
    {
        protected int capacidad;
        protected List<T> elementos;
        public delegate void EventoPrecio(object sender, EventArgs e);
        public EventoPrecio PrecioSuperado;

        public List<T> Elementos { get { return this.elementos; } }

        public double PrecioTotal
        {
            get
            {
                double total = 0;
                foreach (T item in this.elementos)
                {
                    total += item.Precio;
                }
                return total;
            }
        }

        public Caja()
        {
            this.elementos = new List<T>();
        }

        public Caja(int capacidad): this()
        {
            this.capacidad = capacidad;
        }
        ///ToString: Mostrará en formato de tipo string: 
        ///.-el tipo de caja, la capacidad, la cantidad actual de elementos, el precio total y el listado completo 
        ///de todos los elementos contenidos en la misma. Reutilizar código.
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat($"Caja de {typeof(T).Name}\n" +
                $"Capacidad: {this.capacidad}\n" +
                $"Cantidad de elementos {this.elementos.Count.ToString()}\n" +
                $"Precio total {this.PrecioTotal}\n" +
                $"Lista de elementos:\n");
            foreach (Producto item in this.elementos)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }

        public static Caja<T> operator +(Caja<T> l, T u)
        {
            if (l.elementos.Count < l.capacidad && l != null)
            {
                l.elementos.Add(u);
            }
            else if (l.elementos.Count >= l.capacidad)
            {
                throw new CajaLlenaException();
            }

            if (l.PrecioTotal > 999 && l.PrecioSuperado != null)
            {
                l.PrecioSuperado.Invoke(l, EventArgs.Empty);
            }

            return l;
        }
    }
}

