
namespace Formulario
{
    partial class FrmEstadisticaHospital
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_titulo = new System.Windows.Forms.Label();
            this.rchInfoHospital = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // lbl_titulo
            // 
            this.lbl_titulo.AutoSize = true;
            this.lbl_titulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_titulo.Location = new System.Drawing.Point(37, 18);
            this.lbl_titulo.Name = "lbl_titulo";
            this.lbl_titulo.Size = new System.Drawing.Size(377, 32);
            this.lbl_titulo.TabIndex = 0;
            this.lbl_titulo.Text = "Estadisticas generales del Hospital";
            // 
            // rchInfoHospital
            // 
            this.rchInfoHospital.Location = new System.Drawing.Point(37, 72);
            this.rchInfoHospital.Name = "rchInfoHospital";
            this.rchInfoHospital.Size = new System.Drawing.Size(715, 366);
            this.rchInfoHospital.TabIndex = 1;
            this.rchInfoHospital.Text = "";
            // 
            // FrmEstadisticaHospital
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rchInfoHospital);
            this.Controls.Add(this.lbl_titulo);
            this.Name = "FrmEstadisticaHospital";
            this.Text = "FrmEstadisticaHospital";
            this.Load += new System.EventHandler(this.FrmEstadisticaHospital_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_titulo;
        private System.Windows.Forms.RichTextBox rchInfoHospital;
    }
}