using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperaPaleta
{
    public class Tempera
    {
        private ConsoleColor color;
        private string marca;
        private int cantidad;

        #region Constructor
        public Tempera(ConsoleColor color, string marca, int cantidad)
        {
            this.color = color;
            this.marca = marca;
            this.cantidad = cantidad;
        }

        #endregion

        #region Metodos
        private string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Color: ");
            sb.AppendLine(this.color.ToString());
            sb.Append("Marca: ");
            sb.AppendLine(this.marca);
            sb.Append("Cantidad: ");
            sb.AppendLine(this.cantidad.ToString());

            return sb.ToString();
        }

        public static string Mostrar(Tempera tempera)
        {
            return tempera.Mostrar();
        }

        #endregion

        #region Operadores
        public static bool operator ==(Tempera t1, Tempera t2)
        {
            bool retorno = false;
            if ((object)t1 == null && (object)t2 == null) // if(Equals(t1, t2))
            {
                retorno = true;
            }
            else
            {
                if((object)t1 != null && (object)t2 != null)
                {
                    if (t1.color == t2.color && t1.marca == t2.marca)
                    {
                        retorno = true;            
                    }
                }
            }

            return retorno;
        }

        public static bool operator !=(Tempera t1, Tempera t2)
        {
            return !(t1 == t2);
        }

        public static implicit operator int(Tempera tempera)
        {
            return tempera.cantidad;
        }

        public static Tempera operator +(Tempera t1, Tempera t2)
        {
            Tempera suma = t1;
            if(t1 == t2 && t1 != null)
            {
                suma = new Tempera(t1.color, t1.marca, t1.cantidad + t2); // ??? t1.cantidad += t2; y retornar el mismo t1
            }
            return suma;
        }

        public static Tempera operator +(Tempera tempera, int numero)
        {
            Tempera suma =  tempera;
            if (tempera != null)
            {
                suma = new Tempera(tempera.color, tempera.marca, tempera.cantidad + numero); // ???
            }
            return suma;
        }
        #endregion

        }
}
