using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehiculos
{
    public class Camion:Vehiculo
    {
        protected int pesoCarga;

        public Camion() : base()
        { }
        public Camion(short cantidadRuedas, short cantidadPuertas, short cantidadMarchas, Colores color,
            int pesoCarga) : base(cantidadRuedas, cantidadRuedas, cantidadMarchas, color)
        {
            this.pesoCarga = pesoCarga;
        }
    }
}
