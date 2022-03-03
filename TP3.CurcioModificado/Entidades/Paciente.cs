using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paciente : Persona
    {
        #region Atributo
        private List<EPatologia> patologias;
        #endregion

        #region Constructor
        public Paciente() : this("sin nombre", "sin apellido", 0, new List<EPatologia>())
        { }
        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="nombre">nombre del paciente</param>
        /// <param name="apellido">apellido del paciente</param>
        /// <param name="dni">dni del paciente</param>
        /// <param name="patologia">lista de patologias que tiene el paciente</param>
        public Paciente(string nombre, string apellido, double dni, List<EPatologia> patologia)
                        : base(nombre, apellido, dni)
        {
            this.patologias = patologia;
        }
        #endregion

        #region Propiedades
        public List<EPatologia> Patologia
        {
            get
            {
                return this.patologias; 
            }
            set
            {
                this.patologias = value; 
            }
        }
        #endregion

        #region Sobrecarga
        /// <summary>
        /// Sobrecarga operador, compara dos pacientes por dni
        /// </summary>
        /// <param name="a">paciente a</param>
        /// <param name="b">paciente b</param>
        /// <returns>TRUE si los pacientes son iguales</returns>
        public static bool operator ==(Paciente a, Paciente b)
        {
            if(a is null && b is null)
            {
                return true; 
            }
            else if(a is not null && b is not null && a.Dni == b.Dni)
            {
                return true; 
            }
            return false; 
        }
        public static bool operator !=(Paciente a, Paciente b)
        {
            return !(a == b); 
        }
        /// <summary>
        /// Sobrecarga operador ToString
        /// </summary>
        /// <returns>cadena string con Apellido, Nombre, Dni</returns>
        public override string ToString()
        {
            return this.Apellido + ", " + this.Nombre + ". " + this.Dni;
        }
        #endregion
    }
}
