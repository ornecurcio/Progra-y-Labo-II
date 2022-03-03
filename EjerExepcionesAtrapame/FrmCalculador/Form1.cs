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

namespace FrmCalculador
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtKilometros.Text) || string.IsNullOrWhiteSpace(txtLitros.Text))
                {
                    throw new ParametroVacioException("Alguno de los campos esta vacio");
                }
                rtbCalculador.Text = $"Km / hs: {Calculador.Calcular(int.Parse(txtKilometros.Text), int.Parse(txtLitros.Text))}"; 
            }
            catch (ParametroVacioException ex)
            {
                MessageBox.Show(ex.Message); 
            }
            catch (FormatException)
            {
                MessageBox.Show("El formato de entrada no es el correcto");
            }
            catch(DivideByZeroException)
            {
                MessageBox.Show("No se puede dividir por cero");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
