using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosExtension_Generics
{
    public class Generica<T, U>
    {

        protected List<T> lista;
        protected U atributo;

        public Generica()
        {
            this.lista = new List<T>();
        }

        public Generica(U atributo) : this()
        {
            this.atributo = atributo;
        }


        public List<T> Lista { get => lista; set => lista = value; }
        public U Atributo { get => atributo; set => atributo = value; }


        public static bool operator +(Generica<T, U> generica, T a)
        {
            if (!generica.lista.Contains(a))
            {
                generica.lista.Add(a);
                return true;
            }
            return false;
        }

        public static bool operator -(Generica<T, U> generica, T a)
        {
            if (generica.lista.Contains(a))
            {
                generica.lista.Remove(a);
                return true;
            }

            return false;
        }

        public bool Agregar(T a)
        {
            return this + a;
        }

        public bool Remover(T a)
        {
            return this - a;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Mi atributo es " + atributo);
            stringBuilder.AppendLine("Listado de: " + typeof(T).Name);
            foreach (T item in this.lista)
            {
                stringBuilder.AppendLine(item.ToString());
            }


            return stringBuilder.ToString();
        }

    }
}
