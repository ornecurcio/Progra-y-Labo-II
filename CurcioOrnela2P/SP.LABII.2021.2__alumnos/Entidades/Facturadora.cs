using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Facturadora<T> where T : Producto
    {
        public static bool ImprimirTicket(Caja<T> car)
        {
            bool rta = true;

            string path = Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + @"\facturas.log";

            try
            {
                using (StreamWriter f = new StreamWriter(path, true))
                {
                    f.Write("Fecha: ");
                    f.WriteLine(System.DateTime.Now);
                    f.Write("Precio Total: ");
                    f.WriteLine(car.PrecioTotal);
                    f.WriteLine("---------------------------------");
                }
            }
            catch
            {
                rta = false;
            }
            return rta;
        }
    }
}
