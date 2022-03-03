using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehiculos
{
    public abstract class Vehiculo
    {
        protected short cantidadRuedas;
        protected short cantidadPuertas;
        protected short cantidadMarchas;
        protected Colores color;

        public Vehiculo()
        {
            this.color = Colores.Negro;
        }
        public Vehiculo(short cantidadRuedas, short cantidadPuertas, short cantidadMarchas, Colores color)
        {
            this.cantidadRuedas = cantidadRuedas;
            this.cantidadPuertas = cantidadPuertas;
            this.cantidadMarchas = cantidadMarchas;
            this.color = color; 
        }

    }
}
