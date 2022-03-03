using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehiculos
{
    public abstract class VehiculoTerrestre
    {
        public short cantidadRuedas;
        public short cantidadPuertas;
        public short cantidadMarchas;
        public Colores color;

        public VehiculoTerrestre()
        {
            this.color = Colores.Negro;
        }
        public VehiculoTerrestre(short cantidadRuedas, short cantidadPuertas, short cantidadMarchas, Colores color)
        {
            this.cantidadRuedas = cantidadRuedas;
            this.cantidadPuertas = cantidadPuertas;
            this.cantidadMarchas = cantidadMarchas;
            this.color = color; 
        }

    }
}
