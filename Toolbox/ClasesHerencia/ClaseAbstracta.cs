using System;
using System.Text;

namespace ClasesHerencia
{
    public abstract class ClaseAbstracta
    {
        public string nombre;
        public double numero;

        public ClaseAbstracta()
        {
        }
        public ClaseAbstracta(string nombre, double numero)
        {
            this.nombre = nombre;
            this.numero = numero;
        }

        protected virtual string UtilesToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat($"Nombre: {this.nombre}\nNumero: {this.numero}");

            return sb.ToString();
        }

        public override string ToString()
        {
            return this.UtilesToString();

        }

    }
}
