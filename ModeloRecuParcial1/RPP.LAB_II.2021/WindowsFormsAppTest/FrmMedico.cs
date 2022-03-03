using EntidadesRPP;
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
    public partial class FrmMedico : FrmPersonal
    {
        private Medico medico;
        
        public override Personal PersonalDelForm => this.medico;

        public FrmMedico()
        {
            InitializeComponent();

            /// Cargar el cboEspecialidad a partir del enumerado Especialidad


            /// Establecer 'Pediatra' como valor predeterminado


            this.cboEspecialidad.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// Sobrescribir método virtual para crear un objeto de tipo Médico.


    }
}
