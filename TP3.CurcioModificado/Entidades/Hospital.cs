using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Hospital
    {
        #region Atributos
        private static List<Paciente> pacientes;
        private static List<Cirujano> cirujanos;
        private static List<Cirugia> cirugias;
        private static Estadistica estadistica;
        #endregion

        #region Constructor
        static Hospital()
        {
            try
            {
                pacientes = new List<Paciente>();
                cirujanos = new List<Cirujano>();
                cirugias = new List<Cirugia>();
                estadistica = new Estadistica();

                string ruta = SerializacionAJason.GenerarRuta("Pacientes.json");
                pacientes = SerializacionAJason.DeserealizarDesdeJson<List<Paciente>>(ruta);
                ruta = SerializacionAJason.GenerarRuta("Cirujanos.json");
                cirujanos = SerializacionAJason.DeserealizarDesdeJson<List<Cirujano>>(ruta);
                ruta = SerializacionAJason.GenerarRuta("Cirugias.json");
                cirugias = SerializacionAJason.DeserealizarDesdeJson<List<Cirugia>>(ruta);
                Hospital.ActualizarEstadistica(cirugias);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo cargar Hospital", ex);
            }
        }
        #endregion

        #region Propiedades
        public static List<Paciente> Pacientes
        {
            get
            {
                return pacientes;
            }
            set
            {
                if (value is not null)
                {
                    pacientes = value;
                }
            }
        }
        public static List<Cirujano> Cirujanos
        {
            get
            {
                return cirujanos;
            }
            set
            {
                if (value is not null)
                {
                    cirujanos = value;
                }
            }
        }
        public static List<Cirugia> Cirugias
        {
            get
            {
                return cirugias;
            }
            set
            {
                if (value is not null)
                {
                    cirugias = value;
                }
            }
        }
        public static Estadistica Estadistica
        {
            get
            {
                return estadistica;
            }
            set
            {
                if (value is not null)
                {
                    estadistica = value;
                }
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Serializa a Archivo Json una lista de pacientes
        /// </summary>
        public static void SerializarPacientes()
        {
            string ruta = SerializacionAJason.GenerarRuta("Pacientes.json");
            SerializacionAJason.SerializarAJason(ruta, pacientes);
        }
        /// <summary>
        /// Serializa a Archivo Json una lista de cirugias
        /// </summary>
        public static void SerializarCirugias()
        {
            string ruta = SerializacionAJason.GenerarRuta("Cirugias.json");
            SerializacionAJason.SerializarAJason(ruta, cirugias);
        }
        /// <summary>
        /// Serializa a Archivo Json una lista de cirujanos 
        /// </summary>
        public static void SerializarCirujanos()
        {
            string ruta = SerializacionAJason.GenerarRuta("Cirujanos.json");
            SerializacionAJason.SerializarAJason(ruta, cirujanos);
        } 
        /// <summary>
        /// Carga una nueva cirugia a la lista de cirugias y actualiza la estadistica del cirujano y el htal
        /// </summary>
        /// <param name="aux"> cirugia a ser agregada</param>
        /// <returns>TRUE si se cargo con exito</returns>
        public static bool CargarCirugia(Cirugia aux)
        {
            try
            {
                if (aux is not null)
                {
                    cirugias.Add(aux);
                    estadistica.ActualizarPatologia(aux.Patologia);
                    estadistica.ActualizarProcedimiento(aux.Procedimiento);
                    SerializarCirugias();
                    SerializarCirujanos();
                    return true; 
                }
                return false; 
            }
            catch(Exception ex)
            {
                throw new Exception("Fallo en cargar cirugia", ex); 
            }
        }
        /// <summary>
        /// Agrega un nuevo cirujano a la lista si el mismo no existe 
        /// </summary>
        /// <param name="aux"> cirujano a agregar</param>
        /// <returns>TRUE si se cargo con exito</returns>
        public static bool CargarCirujanos(Cirujano aux)
        {
            if (aux is not null)
            {
                foreach (Cirujano item in cirujanos)
                {
                    if (item==aux)
                    {
                        return false;
                    }
                }
                cirujanos.Add(aux);
                SerializarCirujanos();
                return true; 
            }
            return false;
        }
        /// <summary>
        /// Actualiza los datos de un paciente
        /// </summary>
        /// <param name="aux">paciente a actualizar</param>
        /// <returns>TRUE si pudo modificarlo</returns>
        public static bool ActualizarPaciente(Paciente aux)
        {
            foreach (Paciente item in Pacientes)
            {
                if (aux == item)
                {
                    Pacientes.Remove(item);
                    Pacientes.Add(aux);
                    SerializarPacientes(); 
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Agrega un paciente a la lista si el paciente no existe
        /// </summary>
        /// <param name="aux">paciente a agregar</param>
        /// <returns></returns>
        public static bool CargarPacientes(Paciente aux)
        {
            if (aux is not null)
            {
                foreach (Paciente item in Pacientes)
                {
                    if (aux == item)
                    {
                        return false;
                    }
                }
                Pacientes.Add(aux);
                SerializarPacientes();
                return true;
            }
            return false;
        }
        /// <summary>
        /// Actualiza la estadistica del hospital al iniciarse el programa
        /// </summary>
        /// <param name="cirugias"> listado de cirugias</param>
        public static void ActualizarEstadistica(List<Cirugia>cirugias)
        {
            foreach (Cirugia item in cirugias)
            {
                Hospital.Estadistica.ActualizarPatologia(item.Patologia);
                Hospital.Estadistica.ActualizarProcedimiento(item.Procedimiento);
            }
        }
        /// <summary>
        /// Genera una lista de cirugias por el patologia operada
        /// </summary>
        /// <param name="patologia">tipo de patologia a filtrar</param>
        /// <returns>Lista de cirugias con esa patologia</returns>
        public static List<Cirugia> CirugiasXPatologia(EPatologia patologia)
        {
            List<Cirugia> cirugiasXPatologia = new List<Cirugia>();
            foreach (Cirugia item in Hospital.cirugias)
            {
                if(item.Patologia == patologia)
                {
                    cirugiasXPatologia.Add(item); 
                }
            }
            return cirugiasXPatologia; 
        }
        /// <summary>
        /// Genera una lista de cirugias por procedimiento echo
        /// </summary>
        /// <param name="procedimiento">tipo de procedimiento a filtrar</param>
        /// <returns>Lista de cirugias con el procedimiento echo </returns>
        public static List<Cirugia> CirugiasXProcedimiento(EProcedimiento procedimiento)
        {
            List<Cirugia> cirugiasXProcedimiento = new List<Cirugia>();
            foreach (Cirugia item in Hospital.cirugias)
            {
                if (item.Procedimiento == procedimiento)
                {
                    cirugiasXProcedimiento.Add(item);
                }
            }
            return cirugiasXProcedimiento;
        }
        /// <summary>
        /// Genera una lista de cirugias por cirujano
        /// </summary>
        /// <param name="cirujano">cirujano que realizo la cirugia</param>
        /// <returns>Lista de cirugias con ese cirujano</returns>
        public static List<Cirugia> CirugiasXCirujano(Cirujano cirujano)
        {
            List<Cirugia> cirugiasXCirujano = new List<Cirugia>();
            foreach (Cirugia item in Hospital.cirugias)
            {
                if (item.Cirujano == cirujano)
                {
                    cirugiasXCirujano.Add(item);
                }
            }
            return cirugiasXCirujano;
        }
        /// <summary>
        /// Genera lista de cirigia por cirujano y procedimiento
        /// </summary>
        /// <param name="procedimiento">Tipo de cirugia echa</param>
        /// <param name="cirujano">quien hizo la cirugia</param>
        /// <returns>lista filtrada</returns>
        public static List<Cirugia> CirugiasXProcedimientoYCirujano(EProcedimiento procedimiento, Cirujano cirujano)
        {
            List<Cirugia> cirugiasXProcedimientoYCirujano = new List<Cirugia>();
            foreach (Cirugia item in Hospital.cirugias)
            {
                if (item.Procedimiento == procedimiento && item.Cirujano==cirujano)
                {
                    cirugiasXProcedimientoYCirujano.Add(item);
                }
            }
            return cirugiasXProcedimientoYCirujano;
        }
        /// <summary>
        /// Genera lista de cirugia por patologia y cirujano
        /// </summary>
        /// <param name="patologia">la patologia a filtrar </param>
        /// <param name="cirujano">cirujano que realizo</param>
        /// <returns>Lista filtrada</returns>
        public static List<Cirugia> CirugiasXPatologiaYCirujano(EPatologia patologia, Cirujano cirujano)
        {
            List<Cirugia> cirugiasXPatologiaYCirujano = new List<Cirugia>();
            foreach (Cirugia item in Hospital.cirugias)
            {
                if (item.Patologia == patologia && item.Cirujano == cirujano)
                {
                    cirugiasXPatologiaYCirujano.Add(item);
                }
            }
            return cirugiasXPatologiaYCirujano;
        }
        #endregion
    }
}
