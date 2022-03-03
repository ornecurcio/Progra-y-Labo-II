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
    public partial class FrmMedicoEgresado : FrmMedico
    {
        private MedicoEgresado medicoEgresado;

        public override Personal PersonalDelForm => this.medicoEgresado;

        public FrmMedicoEgresado()
        {
            InitializeComponent();
        }

        /// Implementar sobrecarga del constructor para recibir un médico,
        /// crear un médico egresado y mostrar su contenido (incluyendo el jornal).
        /// 


        protected override void btnAceptar_Click(object sender, EventArgs e)
        {
            base.btnAceptar_Click(sender, e);
        }
    }
}
