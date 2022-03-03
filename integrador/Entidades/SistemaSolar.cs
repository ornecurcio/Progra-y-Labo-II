using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class SistemaSolar<T> where T: Planeta
    {
        public List<T> lista;
        protected int capacidad; 

        public SistemaSolar()
        {
            this.lista = new List<T>(); 
        }
        public SistemaSolar(int capacidad):this()
        {
            this.capacidad = capacidad; 
        }

        public bool Agregar(Planeta planeta)
        {
            bool rta = false; 
            if(this.lista.Count < this.capacidad)
            {
                lista.Add((T)planeta);
                rta = true; 
            }
            return rta; 
        }
    }
}
