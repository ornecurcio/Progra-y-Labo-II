using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public static class Extension
    {

        public static List<Usuario> ObtenerTodos(this Usuario usuario)
        {

              return Usuario.ReadAll();
        }
    }
}
