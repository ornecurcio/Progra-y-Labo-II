using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CajaLlenaException:Exception
    {
        public CajaLlenaException()
              : base("Error no hay mas lugar en la caja")
        {
        }

        public CajaLlenaException(string mensaje)
            : base(mensaje)
        {
        }

        public CajaLlenaException(string mensaje, Exception innerException)
            : base(mensaje, innerException)
        {
        }

        public CajaLlenaException(string mensaje, Exception innerException, string origenError)
            : base(mensaje, innerException)
        {
            base.Source = origenError;
        }

        public override string ToString()
        {
            return "Mensaje de error: " + base.Message + "\nOrigen: " + base.Source;
        }
    }
}
