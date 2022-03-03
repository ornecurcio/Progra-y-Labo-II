using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Formulario
{
    public partial class FrmEstadisticaHospital : Form
    {
        public FrmEstadisticaHospital()
        {
            InitializeComponent();
        }

        private void FrmEstadisticaHospital_Load(object sender, EventArgs e)
        {
            CargarInfoPacientes();
            CargarInfoCirujanos();
        }


        private void CargarInfoPacientes()
        {
            float cantidadPacientesMayoresDeEdad = 0;
            float porcentaje;
            foreach (Paciente item in Hospital.Pacientes)
            {
                if (item.Edad > 18)
                    cantidadPacientesMayoresDeEdad++;
            }

            porcentaje = cantidadPacientesMayoresDeEdad / Hospital.Pacientes.Count;

            this.rchInfoHospital.Text += $"Pacientes mayores de edad representan el {Math.Round(porcentaje,2)} de los pacientes";
            this.rchInfoHospital.Text += $"(Cantidad de pacientes mayores de edad: {cantidadPacientesMayoresDeEdad} de {Hospital.Pacientes.Count}) \n\n";

        }

        private void CargarInfoCirujanos()
        {
            float cantCirujanos = 0;
            float porcentaje;
            foreach (Cirujano item in Hospital.Cirujanos)
            {
                if (item.Rol == ERol.Ayudante)
                    cantCirujanos++;
            }

            porcentaje = cantCirujanos / Hospital.Cirujanos.Count;

            this.rchInfoHospital.Text += $"Los ayudantes representan el {Math.Round(porcentaje, 2)} de los medicos";
            this.rchInfoHospital.Text += $"(Cantidad ayudantes: {cantCirujanos} de {Hospital.Cirujanos.Count}) \n\n";

        }




    }
}
