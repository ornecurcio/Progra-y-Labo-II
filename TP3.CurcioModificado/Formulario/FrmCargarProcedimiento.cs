using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Entidades; 

namespace Formulario
{
    public partial class FrmCargarProcedimiento : Form, ICargarCmb
    {
        bool esMedico; 
        public FrmCargarProcedimiento()
        {
            InitializeComponent();
        }
        public FrmCargarProcedimiento(bool esMedico):this()
        {
            this.esMedico = esMedico; 
        }
        //Load formulario si esMedico True carga cmb con cirujanos y cmb con pacientes 
        // si no es medico carga cmb con paciente y sus patologias
        private void FrmCargarProcedimiento_Load(object sender, EventArgs e)
        {
            if (esMedico)
            {
                lblPersona.Text = "Cirujano";
                CargarCmbLista(cmbApellidoNombre, Hospital.Cirujanos); 
                lblPacientevsCirujano.Text = "Paciente";
                CargarCmbLista(cmbPacientevsCirujano, Hospital.Pacientes); 
                cmbPatologia.DataSource = Hospital.Pacientes[0].Patologia;
            }
            else
            {
                lblPersona.Text = "Paciente";
                CargarCmbLista(cmbApellidoNombre, Hospital.Pacientes);
                lblAgregarNuevo2.Visible = false;
                lblPacientevsCirujano.Visible = false;
                cmbPacientevsCirujano.Visible = false;
                lblProcedimiento.Visible = false;
                cmbProcedimiento.Visible = false;
                ActualizarCmbPatologia(Hospital.Pacientes[0]);
            }
            cmbProcedimiento.Enabled = false;
        }
        // Si no es medico al cambiar el cmb actualiza el cmb de patologias del paciente 
        private void cmbApellidoNombre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!esMedico)
            {
                Paciente aux = (Paciente)cmbApellidoNombre.SelectedItem;
                ActualizarCmbPatologia(aux);
            }
        }
        //dependiendo de la patologia seleccionada se carga el cmb de procedimiento
        private void cmbPatologia_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbProcedimiento.Enabled = true;
            if (cmbPatologia.CanSelect)
            {
                switch (cmbPatologia.Text)
                {
                    case "Columna":
                        cmbProcedimiento.Items.Clear(); 
                        cmbProcedimiento.Items.AddRange(new String[] { "RAFI", "Artrodecis", "Osteotomia", "Yeso" });
                        break;
                    case "MiembroSuperior":
                        cmbProcedimiento.Items.Clear();
                        cmbProcedimiento.Items.AddRange(new String[] { "RAFI", "Artrodecis", "Osteotomia", "Yeso", "ReduccionCerrada", "Osteodesis" });
                        break;
                    case "MiembroInferior":
                        cmbProcedimiento.Items.Clear();
                        cmbProcedimiento.Items.AddRange(new String[] { "RAFI", "Artrodecis", "Osteotomia", "Yeso", "ReduccionCerrada", "Osteodesis" });
                        break;
                    case "Pelvis":
                        cmbProcedimiento.Items.Clear();
                        cmbProcedimiento.Items.AddRange(new String[] { "Artrodecis", "Osteotomia", "Yeso" });
                        break;
                }
            }
        }
        //abre form para ingresar nuevo cirujano
        private void lblAgregarNuevo_Click(object sender, EventArgs e)
        {
            FrmIngresoDatos ingresoDatos = new FrmIngresoDatos(esMedico);
            if(ingresoDatos.ShowDialog()==DialogResult.OK)
            {
                this.Close(); 
            }
        }
        //abre form para ingresar nuevo paciente
        private void lblAgregarNuevo2_Click(object sender, EventArgs e)
        {
            FrmIngresoDatos ingresoDatos = new FrmIngresoDatos(!esMedico);
            if (ingresoDatos.ShowDialog() == DialogResult.OK)
            {
                this.Close();
            }
        }
        //Si es medico se carga el combo con las patologias del paciente seleccionado
        private void cmbPacientevsCirujano_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (esMedico)
            {
                Paciente aux = (Paciente)cmbPacientevsCirujano.SelectedItem;
                cmbPatologia.DataSource = null;
                cmbPatologia.DataSource = aux.Patologia;
            }
        }
        //se chequean los datos ingresados y se genera una instancia de una nueva cirugia 
        //se agrega la cirugia a la lista de cirugias del Hospital y actualizan las estadisticas
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (esMedico && cmbApellidoNombre.CanSelect && cmbPatologia.CanSelect
               && cmbPacientevsCirujano.CanSelect && cmbProcedimiento.CanSelect)
            {
                Enum.TryParse(cmbPatologia.Text, out EPatologia auxP);
                Enum.TryParse(cmbProcedimiento.Text, out EProcedimiento auxPr);

                Cirugia aux = new Cirugia((Paciente)cmbPacientevsCirujano.SelectedItem, DateTime.Now,
                                  (Cirujano)cmbApellidoNombre.SelectedItem, auxP, auxPr);
                ((Cirujano)cmbApellidoNombre.SelectedItem).Estadistica.ActualizarPatologia(auxP);
                ((Cirujano)cmbApellidoNombre.SelectedItem).Estadistica.ActualizarProcedimiento(auxPr);
                Hospital.CargarCirugia(aux);

                this.Close();
            }
            else if (!esMedico && cmbApellidoNombre.CanSelect && cmbPatologia.CanSelect &&
                     Enum.TryParse(cmbPatologia.Text, out EPatologia auxP))
            {
                Paciente aux = (Paciente)cmbApellidoNombre.SelectedItem;
                aux.Patologia.Add(auxP);
                Hospital.ActualizarPaciente(aux);

                this.Close();
            }
            else
            {
                MessageBox.Show("Seleccione una opcion de cada casilla", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Actualiza el cmb de Patologias en base a las patologias del paciente
        /// </summary>
        /// <param name="paciente">paciente sobre el que se actualiza la lista</param>
        private void ActualizarCmbPatologia(Paciente paciente)
        {
            List<EPatologia> diferente = new List<EPatologia>();
            foreach (EPatologia item in Enum.GetValues(typeof(EPatologia)))
            {
                if (!paciente.Patologia.Exists((x) => item == x))
                {
                    diferente.Add(item);
                }
            }
            cmbPatologia.DataSource = null;
            cmbPatologia.DataSource = diferente;
        }
        // Aplicacion de interfase, se cargan los ComboBox en base a los datos que necesitan ser cargados
        public void CargarCmbLista<T>(ComboBox d, List<T> lista) where T : class
        {
            if (lista is not null && lista.Count > 0)
            {
                d.DataSource = lista;
            }
        }

        void ICargarCmb.CargarCmbEnum<T>(ComboBox d, T enu)
        {
            d.DataSource = Enum.GetValues(typeof(T));
        }
    }
}
