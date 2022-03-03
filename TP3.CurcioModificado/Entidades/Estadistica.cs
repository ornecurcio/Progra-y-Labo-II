using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Estadistica
    {
        #region Atributos
        private int cantColumna;
        private int cantMiembroSuperior;
        private int cantMiembroInferior;
        private int cantPelvis;
        private int cantRAFI;
        private int cantReduccionCerrada;
        private int cantOsteotomia;
        private int cantArtrodecis;
        private int cantOsteodesis; 
        private int cantYeso;
        #endregion

        #region Constructor
        public Estadistica()
        {
        }
        #endregion

        #region Propiedades
        public int CantColumna
        {
            get
            {
                return this.cantColumna;
            }
            set
            {
                this.cantColumna = value;
            }
        }
        public int CantMiembroSuperior
        {
            get
            {
                return this.cantMiembroSuperior;
            }
            set
            {
                this.cantMiembroSuperior = value;
            }
        }
        public int CantMiembroInferior
        {
            get
            {
                return this.cantMiembroInferior;
            }
            set
            {
                this.cantMiembroInferior = value;
            }
        }
        public int CantPelvis
        {
            get
            {
                return this.cantPelvis;
            }
            set
            {
                this.cantPelvis = value;
            }
        }
        public int CantRAFI
        {
            get
            {
                return this.cantRAFI;
            }
            set
            {
                this.cantRAFI = value;
            }
        }
        public int CantReduccionCerrada
        {
            get
            {
                return this.cantReduccionCerrada;
            }
            set
            {
                this.cantReduccionCerrada = value;
            }
        }
        public int CantOsteotomia
        {
            get
            {
                return this.cantOsteotomia;
            }
            set
            {
                this.cantOsteotomia = value;
            }
        }
        public int CantArtrodecis
        {
            get
            {
                return this.cantArtrodecis;
            }
            set
            {
                this.cantArtrodecis = value;
            }
        }
        public int CantOsteodesis 
        {
            get
            {
                return this.cantOsteodesis;
            }
            set
            {
                this.cantOsteodesis = value;
            }
        }
        public int CantYeso
        {
            get
            {
                return this.cantYeso;
            }
            set
            {
                this.cantYeso = value;
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Actualiza contador de la patologia recibida
        /// </summary>
        /// <param name="patologia">Tipo de patologia a contabilizar</param>
        public void ActualizarPatologia(EPatologia patologia)
        {
            switch (patologia)
            {
                case EPatologia.Columna:
                    this.cantColumna++; 
                    break;
                case EPatologia.MiembroSuperior:
                    this.cantMiembroSuperior++; 
                    break;
                case EPatologia.MiembroInferior:
                    this.cantMiembroInferior++; 
                    break;
                case EPatologia.Pelvis:
                    this.cantPelvis++; 
                    break;
            }
        }
        /// <summary>
        /// Actualiza contador de procedimiento 
        /// </summary>
        /// <param name="procedimiento">Tipo de procedimiento a contabilizar</param>
        public void ActualizarProcedimiento(EProcedimiento procedimiento)
        {
            switch (procedimiento)
            {
                case EProcedimiento.Artrodecis:
                    this.cantArtrodecis++;
                    break;
                case EProcedimiento.RAFI:
                    this.cantRAFI++;
                    break;
                case EProcedimiento.Osteotomia:
                    this.cantOsteotomia++;
                    break;
                case EProcedimiento.Osteodesis:
                    this.CantOsteodesis++;
                    break;
                case EProcedimiento.ReduccionCerrada:
                    this.cantReduccionCerrada++;
                    break;
                case EProcedimiento.Yeso:
                    this.cantYeso++;
                    break;
            }
        }
        #endregion
    }
}
