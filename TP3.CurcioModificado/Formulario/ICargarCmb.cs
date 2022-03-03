using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Windows.Forms; 

namespace Formulario
{
    public interface ICargarCmb
    {
        void CargarCmbLista<T>(ComboBox d, List<T> lista)
            where T : class;
        void CargarCmbEnum<T>(ComboBox d, T enu) 
            where T : Type;  
    }
}
