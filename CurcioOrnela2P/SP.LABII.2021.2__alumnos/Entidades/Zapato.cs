using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{
    ///Zapato->hereda de producto 
    ///ToString():string (polimorfismo; reutilizar código) (mostrar TODOS los valores).
    public class Zapato : Producto, ISerializa, IDeserealiza
    {
        public Zapato():this("sin marca", "sin tipo", 0, 0)
        { }
        public Zapato(string marca, string tipo, double precio, int codigo) : base(marca, tipo, precio, codigo)
        {
        }

        public string Path
        {
            get
            {
                return Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop).ToString() + "\\Ornela.Ivana.Curcio.zapato.xml";
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public bool Xml()
        {
            bool rta = true;

            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(this.Path, System.Text.Encoding.UTF8))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Zapato));

                    serializer.Serialize(writer, this);
                }

            }
            catch (Exception)
            {
                rta = false;
            }

            return rta;
        }

        bool IDeserealiza.Xml(out Zapato l)
        {
            bool rta = true;

            try
            {
                using (XmlTextReader read = new XmlTextReader(this.Path))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(Zapato));

                    l = (Zapato)ser.Deserialize(read);

                }

            }
            catch (Exception)
            {
                rta = false;
                l = new Zapato(); 
            }
            return rta;
        }
    }
}
