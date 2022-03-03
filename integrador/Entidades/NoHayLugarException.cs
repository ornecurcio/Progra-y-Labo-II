using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class NoHayLugarException:Exception
    {
        private static string mensajeError;

        static NoHayLugarException()
        {
            mensajeError = "No hay lugar para mas planetas";
        }

        public NoHayLugarException() : this(NoHayLugarException.mensajeError)
        {
        }
        public NoHayLugarException(string mensaje) : base(mensaje)
        {
        }

        public NoHayLugarException(Exception innerException) : base(NoHayLugarException.mensajeError, innerException)
        {
        }
    }
}
