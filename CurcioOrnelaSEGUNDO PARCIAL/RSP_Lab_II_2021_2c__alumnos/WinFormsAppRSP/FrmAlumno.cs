using System;
using System.Linq;
using System.Windows.Forms;
using EntidadesRSP; 


namespace WinFormsAppRSP
{
    public partial class FrmAlumno : Form
    {
        private Alumno alumno;

        public Alumno Alumno
        {
            get { return alumno; }
        }

        public FrmAlumno()
        {
            InitializeComponent();
        }
        public FrmAlumno(Alumno miAlumno) : this()
        {
            this.txtApellido.Text = miAlumno.Apellido;
            this.txtNombre.Text = miAlumno.Nombre;
            this.txtNota.Text = miAlumno.Nota.ToString();
            this.txtDNI.Text = miAlumno.Dni.ToString();
            this.txtDNI.Enabled = false;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.txtApellido.Text) && !string.IsNullOrWhiteSpace(this.txtNombre.Text)
                  && this.txtDNI.Text.All(char.IsDigit) && this.txtNota.Text.All(char.IsDigit))
            {
                this.alumno = new Alumno(this.txtApellido.Text, this.txtNombre.Text, int.Parse(this.txtDNI.Text), double.Parse(this.txtNota.Text));
                //this.Alumno.Apellido = this.txtApellido.Text;
                //this.Alumno.Nombre = this.txtNombre.Text;
                //this.Alumno.Dni = int.Parse(this.txtDNI.Text);
                //this.Alumno.Nota = double.Parse(this.txtNota.Text); 
            }
            this.DialogResult = DialogResult.OK;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
