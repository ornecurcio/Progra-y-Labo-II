using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace EntidadesRSP
{
    public class SerializarXml
    {
        static string path = Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop).ToString() + "\\Ornela.Ivana.Curcio.Alumnos.xml";
        public static bool SerializaXml(List<Alumno> lista) 
        {
            bool rta = true;
            
            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(path, System.Text.Encoding.UTF8))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Alumno>));

                    serializer.Serialize(writer, lista);
                }

            }
            catch (Exception)
            {
                rta = false;
            }

            return rta;
        }

        public static bool DeseralizaXml(out List<Alumno> l)
        {
            bool rta = true;

            try
            {
                using (XmlTextReader read = new XmlTextReader(path))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(List<Alumno>));

                    l = (List<Alumno>)ser.Deserialize(read);

                }

            }
            catch (Exception)
            {
                rta = false;
                l = new List<Alumno>();
            }
            return rta;
        }
    }
}
