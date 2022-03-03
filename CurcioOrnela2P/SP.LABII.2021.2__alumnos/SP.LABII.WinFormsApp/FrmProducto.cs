using System;
using System.Linq;
using System.Windows.Forms;
using Entidades; 

namespace SP.LABII.WinFormsApp
{
    public partial class FrmProducto : Form
    {
        private Entidades.Producto miProducto;

        public Entidades.Producto MiProducto
        {
            get { return this.miProducto; }
        }

        public FrmProducto()
        {
            InitializeComponent();
        }
        public FrmProducto(Producto miProducto) : this()
        { 
            this.txtMarca.Text = miProducto.Marca;
            this.txtTipo.Text = miProducto.Tipo;
            this.txtPrecio.Text = miProducto.Precio.ToString();
            this.txtCodigo.Text = miProducto.Codigo.ToString();
            this.txtCodigo.Enabled = false; 
        }
        /// Crar una instancia de tipo Producto
        /// Establecer, como valor de la propiedad, el atributo miProducto
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.txtMarca.Text) && !string.IsNullOrWhiteSpace(this.txtTipo.Text)
                   && this.txtCodigo.Text.All(char.IsDigit) && this.txtPrecio.Text.All(char.IsDigit))
            {
                this.miProducto = new Producto(this.txtMarca.Text, this.txtTipo.Text, double.Parse(this.txtPrecio.Text), int.Parse(this.txtCodigo.Text)); 
            }
                this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
