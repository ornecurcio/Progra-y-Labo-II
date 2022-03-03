using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehiculos
{
    public class Automovil:Vehiculo
    {
        protected int cantidadPasajeros;

        public Automovil() : base()
        { }
        public Automovil(short cantidadRuedas, short cantidadPuertas, short cantidadMarchas, Colores color,
            int cantidadPasajeros) : base(cantidadRuedas, cantidadRuedas, cantidadMarchas, color)
        {
            this.cantidadPasajeros = cantidadPasajeros;
        }
    }
}
