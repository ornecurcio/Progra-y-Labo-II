
namespace Formulario
{
    partial class FrmCargarProcedimiento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCargarProcedimiento));
            this.lblPersona = new System.Windows.Forms.Label();
            this.lblPacientevsCirujano = new System.Windows.Forms.Label();
            this.lblProcedimiento = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.cmbApellidoNombre = new System.Windows.Forms.ComboBox();
            this.cmbPacientevsCirujano = new System.Windows.Forms.ComboBox();
            this.cmbProcedimiento = new System.Windows.Forms.ComboBox();
            this.lblPatologia = new System.Windows.Forms.Label();
            this.cmbPatologia = new System.Windows.Forms.ComboBox();
            this.lblAgregarNuevo = new System.Windows.Forms.Label();
            this.lblAgregarNuevo2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblPersona
            // 
            this.lblPersona.AutoSize = true;
            this.lblPersona.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPersona.Location = new System.Drawing.Point(12, 9);
            this.lblPersona.Name = "lblPersona";
            this.lblPersona.Size = new System.Drawing.Size(75, 18);
            this.lblPersona.TabIndex = 0;
            this.lblPersona.Text = "Persona";
            // 
            // lblPacientevsCirujano
            // 
            this.lblPacientevsCirujano.AutoSize = true;
            this.lblPacientevsCirujano.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPacientevsCirujano.Location = new System.Drawing.Point(12, 65);
            this.lblPacientevsCirujano.Name = "lblPacientevsCirujano";
            this.lblPacientevsCirujano.Size = new System.Drawing.Size(34, 18);
            this.lblPacientevsCirujano.TabIndex = 1;
            this.lblPacientevsCirujano.Text = "Rol";
            // 
            // lblProcedimiento
            // 
            this.lblProcedimiento.AutoSize = true;
            this.lblProcedimiento.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblProcedimiento.Location = new System.Drawing.Point(12, 192);
            this.lblProcedimiento.Name = "lblProcedimiento";
            this.lblProcedimiento.Size = new System.Drawing.Size(124, 18);
            this.lblProcedimiento.TabIndex = 4;
            this.lblProcedimiento.Text = "Procedimiento";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAceptar.Location = new System.Drawing.Point(160, 251);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(88, 32);
            this.btnAceptar.TabIndex = 5;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // cmbApellidoNombre
            // 
            this.cmbApellidoNombre.FormattingEnabled = true;
            this.cmbApellidoNombre.Location = new System.Drawing.Point(12, 27);
            this.cmbApellidoNombre.Name = "cmbApellidoNombre";
            this.cmbApellidoNombre.Size = new System.Drawing.Size(218, 23);
            this.cmbApellidoNombre.TabIndex = 6;
            this.cmbApellidoNombre.SelectedIndexChanged += new System.EventHandler(this.cmbApellidoNombre_SelectedIndexChanged);
            // 
            // cmbPacientevsCirujano
            // 
            this.cmbPacientevsCirujano.FormattingEnabled = true;
            this.cmbPacientevsCirujano.Location = new System.Drawing.Point(12, 83);
            this.cmbPacientevsCirujano.Name = "cmbPacientevsCirujano";
            this.cmbPacientevsCirujano.Size = new System.Drawing.Size(218, 23);
            this.cmbPacientevsCirujano.TabIndex = 7;
            this.cmbPacientevsCirujano.SelectedIndexChanged += new System.EventHandler(this.cmbPacientevsCirujano_SelectedIndexChanged);
            // 
            // cmbProcedimiento
            // 
            this.cmbProcedimiento.FormattingEnabled = true;
            this.cmbProcedimiento.Location = new System.Drawing.Point(12, 210);
            this.cmbProcedimiento.Name = "cmbProcedimiento";
            this.cmbProcedimiento.Size = new System.Drawing.Size(218, 23);
            this.cmbProcedimiento.TabIndex = 10;
            // 
            // lblPatologia
            // 
            this.lblPatologia.AutoSize = true;
            this.lblPatologia.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPatologia.Location = new System.Drawing.Point(12, 137);
            this.lblPatologia.Name = "lblPatologia";
            this.lblPatologia.Size = new System.Drawing.Size(83, 18);
            this.lblPatologia.TabIndex = 11;
            this.lblPatologia.Text = "Patologia";
            // 
            // cmbPatologia
            // 
            this.cmbPatologia.FormattingEnabled = true;
            this.cmbPatologia.Location = new System.Drawing.Point(12, 155);
            this.cmbPatologia.Name = "cmbPatologia";
            this.cmbPatologia.Size = new System.Drawing.Size(218, 23);
            this.cmbPatologia.TabIndex = 12;
            this.cmbPatologia.SelectedIndexChanged += new System.EventHandler(this.cmbPatologia_SelectedIndexChanged);
            // 
            // lblAgregarNuevo
            // 
            this.lblAgregarNuevo.AutoSize = true;
            this.lblAgregarNuevo.Location = new System.Drawing.Point(143, 53);
            this.lblAgregarNuevo.Name = "lblAgregarNuevo";
            this.lblAgregarNuevo.Size = new System.Drawing.Size(87, 15);
            this.lblAgregarNuevo.TabIndex = 13;
            this.lblAgregarNuevo.Text = "Agregar Nuevo";
            this.lblAgregarNuevo.Click += new System.EventHandler(this.lblAgregarNuevo_Click);
            // 
            // lblAgregarNuevo2
            // 
            this.lblAgregarNuevo2.AutoSize = true;
            this.lblAgregarNuevo2.Location = new System.Drawing.Point(143, 109);
            this.lblAgregarNuevo2.Name = "lblAgregarNuevo2";
            this.lblAgregarNuevo2.Size = new System.Drawing.Size(87, 15);
            this.lblAgregarNuevo2.TabIndex = 14;
            this.lblAgregarNuevo2.Text = "Agregar Nuevo";
            this.lblAgregarNuevo2.Click += new System.EventHandler(this.lblAgregarNuevo2_Click);
            // 
            // FrmCargarProcedimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(257, 287);
            this.Controls.Add(this.lblAgregarNuevo2);
            this.Controls.Add(this.lblAgregarNuevo);
            this.Controls.Add(this.cmbPatologia);
            this.Controls.Add(this.lblPatologia);
            this.Controls.Add(this.cmbProcedimiento);
            this.Controls.Add(this.cmbPacientevsCirujano);
            this.Controls.Add(this.cmbApellidoNombre);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblProcedimiento);
            this.Controls.Add(this.lblPacientevsCirujano);
            this.Controls.Add(this.lblPersona);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCargarProcedimiento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmCargarProcedimiento_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPersona;
        private System.Windows.Forms.Label lblPacientevsCirujano;
        private System.Windows.Forms.Label lblProcedimiento;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.ComboBox cmbApellidoNombre;
        private System.Windows.Forms.ComboBox cmbPacientevsCirujano;
        private System.Windows.Forms.ComboBox cmbProcedimiento;
        private System.Windows.Forms.Label lblPatologia;
        private System.Windows.Forms.ComboBox cmbPatologia;
        private System.Windows.Forms.Label lblAgregarNuevo;
        private System.Windows.Forms.Label lblAgregarNuevo2;
    }
}