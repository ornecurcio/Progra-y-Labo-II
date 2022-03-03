using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejoArchivos
{
    public class SerializacionException :  Exception
    {
        public SerializacionException()
              : base("Error en la serializacion")
        {
        }

        public SerializacionException(string mensaje)
            : base(mensaje)
        {
        }

        public SerializacionException(string mensaje, Exception innerException)
            : base(mensaje, innerException)
        {
        }

        public SerializacionException(string mensaje, Exception innerException, string origenError)
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
