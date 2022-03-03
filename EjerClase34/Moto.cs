using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehiculos
{
    class Moto :VehiculoTerrestre
    {
        public short cilindrada;

        public Moto() : base()
        {
        }
        public Moto(short cantidadRuedas, short cantidadPuertas, short cantidadMarchas, Colores color, 
                    short cilindrada) : base(cantidadRuedas, cantidadRuedas, cantidadMarchas, color)
        {
            this.cilindrada = cilindrada; 
        }
    }
}
