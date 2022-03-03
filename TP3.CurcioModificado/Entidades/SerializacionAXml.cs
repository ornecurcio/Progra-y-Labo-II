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
    /// <summary>
    /// Clase Generica para escribir y leer un archivo Xml
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SerializacionAXml<T> where T: new()
    {
        /// <summary>
        /// Genera Archivo Xml
        /// </summary>
        /// <param name="ruta">donde se guardara el archivo/param>
        /// <param name="obj">el objeto a serializar</param>
        public static void SerializarAXmlLista(string ruta, T obj) 
        {
            XmlTextWriter xmlWriter = null;
            XmlSerializer serializador = null;
            try
            {
                xmlWriter = new XmlTextWriter(ruta, Encoding.UTF8);
                xmlWriter.Formatting = Formatting.Indented;
                serializador = new XmlSerializer(typeof(T));
                serializador.Serialize(xmlWriter, obj);
            }
            catch (Exception ex)
            {
                throw new SerializacionException(ex);
            }
            finally
            {
                if (xmlWriter != null)
                {
                    xmlWriter.Close();
                }
            }
        }
        /// <summary>
        /// Deserealiza un archivo Xml
        /// </summary>
        /// <param name="ruta">donde esta el archivo</param>
        /// <returns>el objeto deserealizado</returns>
        public static T DeserealizarXml(string ruta) 
        {
            XmlTextReader xmlReader = null;
            XmlSerializer serializador = null;
            try
            {
                xmlReader = new XmlTextReader(ruta);
                serializador = new XmlSerializer(typeof(T));
                T objetoDesealizado = (T)serializador.Deserialize(xmlReader);
                return objetoDesealizado;
            }
            catch (Exception ex)
            {
                throw new SerializacionException(ex);
            }
            finally
            {
                if (xmlReader != null)
                {
                    xmlReader.Close();
                }
            }
        }
    }
}
