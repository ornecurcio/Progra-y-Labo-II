
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization; 

namespace Entidades
{
    public delegate void DelegadoPlaneta(double gravedad);
    public class Planeta: ISerializable
    {
        public int id;
        public string nombre; 
        public int satelites;
        public double gravedad;
        public event DelegadoPlaneta muchaGravedad; 
        public Planeta()
        {
        }
        public Planeta(int id, string nombre, int satelites, double gravedad)
        {
            this.id = id;
            this.nombre = nombre;
            this.satelites = satelites;
            this.gravedad = gravedad; 
        }

        public string Path
        {
            get
            {
                string rutaAlt = AppDomain.CurrentDomain.BaseDirectory;
                string rutaArchivo = System.IO.Path.Combine(rutaAlt, "planetaSerializado.Xml");
                return rutaArchivo; 
            }
        }
        public double Gravedad
        {
            set
            {
                if(value>30)
                {
                    this.gravedad = value; 
                }
            }
        }
        public string DeserializarXml()
        {
            XmlTextReader xmlReader = null;
            XmlSerializer serializador = null;
            Planeta objetoDesealizado = null; 
            try
            {
                xmlReader = new XmlTextReader(this.Path);
                serializador = new XmlSerializer(typeof(Planeta));
                objetoDesealizado = (Planeta)serializador.Deserialize(xmlReader);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (xmlReader != null)
                {
                    xmlReader.Close();
                }
            }
            return objetoDesealizado.ToString();
        }

        public bool SerializarXml()
        {
            bool rta = false; 
            XmlTextWriter xmlWriter = null;
            XmlSerializer serializador = null;
            try
            {
                xmlWriter = new XmlTextWriter(this.Path, Encoding.UTF8);
                xmlWriter.Formatting = Formatting.Indented;
                serializador = new XmlSerializer(typeof(Planeta));
                serializador.Serialize(xmlWriter, this);
            }
            catch (Exception ex)
            {
                throw ex; 
            }
            finally
            {
                if (xmlWriter != null)
                {
                    rta = true; 
                    xmlWriter.Close();
                }
            }
            return rta; 
        }

        public override string ToString()
        {
            return $"ID: {this.id}\n" +
                    $"Nombre: { this.nombre}\n" +
                    $"Satelites: {this.satelites}\n"+
                    $"Gravedad: {this.gravedad}"; 
        }


    }
}
