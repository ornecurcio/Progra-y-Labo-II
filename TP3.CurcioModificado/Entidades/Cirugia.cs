using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cirugia
    {
        #region Atributos
        private Cirujano cirujano;
        private Paciente paciente;
        private EPatologia patologia;
        private EProcedimiento procedimiento; 
        private DateTime fecha;
        #endregion

        #region Constructores
        public Cirugia()
        { }
        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="paciente">paciente a ser operado</param>
        /// <param name="fecha">la fecha de la cirugia</param>
        /// <param name="cirujano">cirujano que lo opera</param>
        /// <param name="patologia">la patologia por la que se opera</param>
        /// <param name="procedimiento">el procedimiento que se realiza</param>
        public Cirugia(Paciente paciente, DateTime fecha, Cirujano cirujano, 
                       EPatologia patologia, EProcedimiento procedimiento) 
        {
            this.paciente = paciente;
            this.fecha = fecha;
            this.cirujano = cirujano;
            this.patologia = patologia;
            this.procedimiento = procedimiento;
           
        }
        #endregion

        #region Propiedades
        public Cirujano Cirujano
        {
            get
            {
                return this.cirujano; 
            }
            set
            {
                if(value is not null)
                {
                    this.cirujano = value; 
                }
            }
        }
        public EProcedimiento Procedimiento
        {
            get
            {
                return this.procedimiento; 
            }
            set
            {
                this.procedimiento = value; 
            }
        }
        public EPatologia Patologia
        {
            get
            {
                return this.patologia;
            }
            set
            {
                this.patologia = value; 
            }
        }
        public Paciente Paciente
        {
            get
            {
                return this.paciente; 
            }
            set
            {
                if(value is not null)
                {
                    this.paciente = value; 
                }
            }
        }
        public DateTime Fecha
        {
            get
            {
                return this.fecha;
            }
            set
            {
                this.fecha = value;
            }
        }
        #endregion
    }
}
