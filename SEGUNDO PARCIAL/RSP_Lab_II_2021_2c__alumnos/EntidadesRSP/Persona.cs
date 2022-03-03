using System;

namespace EntidadesRSP
{
    ///Crear en un proyecto de tipo class library (EntidadesRSP), las clases:
    ///Persona
    ///Atributos (todos privados)
    ///dni : int
    ///apellido : string
    ///nombre : string
    ///Propiedades públicas de lectura y escritura para todos sus atributos.
    ///Constructor que reciba parámetros para cada atributo
    ///Polimorfismo sobre ToString
    ///
    public class Persona
    {
        private string apellido;
        private string nombre;
        private int dni;

        public Persona()
        {
        }
        public Persona(string apellido, string nombre, int dni)
        {
            this.apellido = apellido;
            this.nombre = nombre;
            this.dni = dni;
        }

        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    this.apellido = value;
                }
            }
        }
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    this.nombre = value;
                }
            }
        }
        public int Dni
        {
            get
            {
                return this.dni;
            }
            set
            {
                if (value > -1)
                {
                    this.dni = value;
                }
            }
        }
        public override string ToString()
        {

            return $"Dni: {this.Dni} -- {this.Apellido}, {this.Nombre}";

        }
    }
}
