using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsAppTest
{
    public partial class FrmPrincipal : Form
    {
        protected Hospital hospital;
        protected List<Personal> egresados;

        public FrmPrincipal()
        {
            InitializeComponent();

            ///Establecer con su apellido y nombre
            string alumno = "Apellido y nombre del alumno";

            MessageBox.Show(alumno);
            this.Text = alumno;

            this.StartPosition = FormStartPosition.CenterScreen;

            this.hospital = "Fiorito";
            this.egresados = new List<Personal>();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            FrmMedico frm = new FrmMedico();
            frm.StartPosition = FormStartPosition.CenterScreen;

            if(frm.ShowDialog() == DialogResult.OK)
            {
                this.hospital += frm.PersonalDelForm;
            }

            this.RefrescarListados();
        }

        private void RefrescarListados()
        {
            this.lstIngresado.Items.Clear();
            this.lstEgresado.Items.Clear();

            for (int i = 0; i < this.hospital.CantidadPersonal; i++)
            {
                this.lstIngresado.Items.Add(this.hospital[i].ToString());
            }

            foreach (Personal item in this.egresados)
            {
                this.lstEgresado.Items.Add(item.ToString());
            }
        }

        private void btnEgresar_Click(object sender, EventArgs e)
        {
            int i = this.lstIngresado.SelectedIndex;

            if (i > -1)
            {
                Personal obj = this.hospital[i];

                FrmMedicoEgresado frm = new FrmMedicoEgresado((Medico)obj);
                frm.StartPosition = FormStartPosition.CenterScreen;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.hospital -= obj;
                    this.egresados.Add(frm.PersonalDelForm);

                    this.RefrescarListados();
                }
            }
        }

        private void cboOrdenarEgresados_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = this.cboOrdenarEgresados.SelectedIndex;
            Comparison<Personal> comparador = null;
            switch (i)
            {
                case 0:
                    comparador = Personal.OrdenarPorLegajoASC;
                    break;
                case 1:
                    comparador = Personal.OrdenarPorLegajoDESC;
                    break;
                default:
                    break;
            }

            this.egresados.Sort(comparador);

            this.RefrescarListados();
        }

    }
}
