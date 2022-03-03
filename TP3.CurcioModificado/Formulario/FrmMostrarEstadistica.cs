using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Entidades; 

namespace Formulario
{
    public partial class FrmMostrarEstadistica : Form
    {
        List<Cirugia> cirugias;
        List<Paciente> pacientes;
        bool hayPacientes; 
        public FrmMostrarEstadistica()
        {
            InitializeComponent();
            cirugias = new List<Cirugia>();
            pacientes = new List<Paciente>();
        }
        //Sobrecarga Constructor recibe una patologia y se mostraran los pacientes que tengan esa patologia
        public FrmMostrarEstadistica(EPatologia patologia) : this()
        {
            lblDescripcion.Text = $"Pacientes por {patologia}";
            foreach (Paciente item in Hospital.Pacientes)
            {
                if(item.Patologia.Contains(patologia))
                {
                    pacientes.Add(item);
                }
            }
            hayPacientes = true; 
        }
        //Sobrecarga, se ingresa desde el hospital y se muestran todas las cirugias
        public FrmMostrarEstadistica(bool esServicio):this()
        {
            lblDescripcion.Text = "Cirugias Totales";
            if (esServicio)
            {
                cirugias = Hospital.Cirugias;
            } 
        }
        //Sobrecarga, se ingresa desde el hospital y se muestran las cirugias con esa patologia
        public FrmMostrarEstadistica(bool esServicio, EPatologia patologia) : this()
        {
            if (esServicio)
            {
                lblDescripcion.Text = $"Cirugias de {patologia}";
                cirugias = Hospital.CirugiasXPatologia(patologia);
            }
        }
        //Sobrecarga, se ingresa desde el hospital y se muestran las cirugias con ese procedimiento
        public FrmMostrarEstadistica(bool esServicio, EProcedimiento procedimiento) : this()
        {
            lblDescripcion.Text = $"Cirugias de {procedimiento}";
            if (esServicio && Hospital.Cirugias.Count > 0)
            {
                cirugias = Hospital.CirugiasXProcedimiento(procedimiento);
            }
        }
        //Sobrecarga, se selecciona un cirujano y muestra todas las cirugias del mismo
        public FrmMostrarEstadistica(Cirujano cirujano) : this()
        {
            lblDescripcion.Text = $"Cirugias de {cirujano}";
            cirugias = Hospital.CirugiasXCirujano(cirujano);
        }
        //Sobrecarga, se selecciona un cirujano y se muestra las cirugias con esa patologia
        public FrmMostrarEstadistica(Cirujano cirujano, EPatologia patologia) : this()
        {
            lblDescripcion.Text = $"Cirugias de {cirujano} \n{patologia}";
            cirugias = Hospital.CirugiasXPatologiaYCirujano(patologia,cirujano);
        }
        //Sobrecarga, se selecciona un cirujano y se muestra las cirugias con ese procedimiento
        public FrmMostrarEstadistica(Cirujano cirujano, EProcedimiento procedimiento) : this()
        {
            lblDescripcion.Text = $"Cirugias de {cirujano} \n{procedimiento}";
            cirugias = Hospital.CirugiasXProcedimientoYCirujano(procedimiento, cirujano);
        }
        private void FrmMostrarEstadistica_Load(object sender, EventArgs e)
        {
            if (cirugias.Count > 0)
            {
                dataEstadistica.DataSource = null;
                dataEstadistica.DataSource = cirugias;
                dataEstadistica.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            if(pacientes.Count>0)
            {
                dataEstadistica.DataSource = null;
                dataEstadistica.DataSource = pacientes;
            }
        }
        //genera un archivo Json con los filtros aplicados
        private void btnExportarAJson_Click(object sender, EventArgs e)
        {
            string ruta = SerializacionAJason.GenerarRuta(lblDescripcion.Text + ".json");
            if (hayPacientes)
            {
                SerializacionAJason.SerializarAJason(ruta, pacientes);
            }
            else
            {
                SerializacionAJason.SerializarAJason(ruta, cirugias);
            }

            MessageBox.Show("Archivo generado con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
        //Genera Archivo Xml con los filtros aplicados
        private void btnExportarAXml_Click(object sender, EventArgs e)
        {
            string ruta = SerializacionAJason.GenerarRuta(lblDescripcion.Text + ".xml");

            if (hayPacientes)
            {
                SerializacionAXml<List<Paciente>>.SerializarAXmlLista(ruta, pacientes);
            }
            else
            {
                SerializacionAXml<List<Cirugia>>.SerializarAXmlLista(ruta, cirugias);
            }
            MessageBox.Show("Archivo generado con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();

        }
    }
}
