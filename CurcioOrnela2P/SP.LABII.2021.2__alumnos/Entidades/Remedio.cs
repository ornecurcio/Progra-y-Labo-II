using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Remedio : Producto
    {
        public Remedio(string marca, string tipo, double precio, int codigo) : base(marca, tipo, precio, codigo)
        {
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
