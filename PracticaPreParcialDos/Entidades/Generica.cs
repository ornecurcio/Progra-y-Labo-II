using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{
    public class Generica <T, U> : ISerializar<T,U>
    {

        protected List<T> lista;
        protected U atributo;



        public Generica()
        {
            this.lista = new List<T>();
        }

        public Generica(U atributo): this()
        {
            this.atributo = atributo;
        }


        public List<T> Lista { get => lista; set => lista = value; }
        public U Atributo { get => atributo; set => atributo = value; }


        public static bool operator +(Generica<T,U> generica, T a)
        {
            if (!generica.lista.Contains(a))
            {
                generica.lista.Add(a);
                return true;
            }
            return false;
        }

        public static bool operator -(Generica<T,U> generica, T a)
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

        public bool Serializar(string path)
         {
            bool retorno = false;
            try
            {

                if (path != null)
                {
                    using (StreamWriter streamWriter = new StreamWriter(path))
                    {
                        XmlSerializer nuevoXml = new XmlSerializer(typeof(Generica<T, U>));
                        nuevoXml.Serialize(streamWriter, this);
                        retorno = true;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return retorno;
        }

        public bool Deserializar(string path, out Generica<T, U> datos )
        {
            bool retorno = false;
            datos = default;

            try
            {
                if (path != null)
                {
                    using (StreamReader auxReader = new StreamReader(path))
                    {
                        XmlSerializer nuevoXml = new XmlSerializer(typeof(Generica<T, U>));
                        datos = (Generica<T, U>)nuevoXml.Deserialize(auxReader);
                        retorno = true;
                    }
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        
            return retorno;
        }

        public bool ValidarSiExisteArchivo(string ruta)
        {
            if (File.Exists(ruta))
            {
                return true;
            }
            else
            {
                throw new ArchivoIncorrectoException("El archivo no existe");
            }

        }
    }

 
}
