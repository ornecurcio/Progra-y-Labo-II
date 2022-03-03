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
    public partial class FrmIngresoDatos : Form, ICargarCmb
    {
        bool esCirujano; 
        
        public FrmIngresoDatos()
        {
            InitializeComponent();
        }
        public FrmIngresoDatos(bool esCirujano):this()
        {
            this.esCirujano = esCirujano; 
        }
        private void FrmIngresoDatos_Load(object sender, EventArgs e)
        {
            if (esCirujano)
            {
                lblPersona.Text = "CIRUJANO";
                lblRolPatologia.Text = "Rol";
                //ICargarCmb.CargarCmbEnum<ERol>(cmbRolPatologia,ERol rol);
                cmbRolPatologia.DataSource = Enum.GetValues(typeof(ERol));
                esCirujano = true;
            }
            else
            {
                lblPersona.Text = "PACIENTE";
                lblRolPatologia.Text = "Patologia";
                //ICargarCmb.CargarCmbEnum<EPatologia>(cmbRolPatologia, EPatoloiga pat);
                cmbRolPatologia.DataSource = Enum.GetValues(typeof(EPatologia));
            }
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(txtApellido.Text) && !string.IsNullOrWhiteSpace(txtNombre.Text) 
                && txtApellido.Text.All(char.IsLetter) && txtNombre.Text.All(char.IsLetter) 
                && txtDni.Text.All(char.IsDigit) && !string.IsNullOrWhiteSpace(cmbRolPatologia.Text))
            {
                 if(esCirujano && Enum.TryParse(cmbRolPatologia.Text, out ERol auxR))
                 {
                    Hospital.CargarCirujanos(new Cirujano(txtNombre.Text, txtApellido.Text, double.Parse(txtDni.Text), 
                                             auxR, new Estadistica())); 
                 }
                 else if(Enum.TryParse(cmbRolPatologia.Text, out EPatologia auxP)) 
                 {
                    List<EPatologia> patologias = new List<EPatologia>();
                    patologias.Add(auxP); 
                    Hospital.CargarPacientes(new Paciente(txtNombre.Text, txtApellido.Text, double.Parse(txtDni.Text), patologias)); 
                 }
                this.Close(); 
            }
            else
            {
                MessageBox.Show("Chequee datos ingresados", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void FrmIngresoDatos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro desea salir?", "Salir", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        public void CargarCmbLista<T>(ComboBox d, List<T> lista) where T : class
        {
            d.DataSource = lista; 
        }

        void ICargarCmb.CargarCmbEnum<T>(ComboBox d, T enu)
        {
            d.DataSource = Enum.GetValues(typeof(T));
        }
    }
}
