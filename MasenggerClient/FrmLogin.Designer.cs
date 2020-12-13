
namespace MasenggerClient
{
    partial class FrmLogin
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
            this.pnlControlBox = new System.Windows.Forms.Panel();
            this.lblCbTitulo = new System.Windows.Forms.Label();
            this.lblCbMinimizar = new System.Windows.Forms.Label();
            this.lblCbCerrar = new System.Windows.Forms.Label();
            this.lnkRegistrarse = new System.Windows.Forms.LinkLabel();
            this.pnlVista1 = new System.Windows.Forms.Panel();
            this.lblLoginTitulo = new System.Windows.Forms.Label();
            this.btnConectar = new System.Windows.Forms.Button();
            this.lbTitulo2 = new System.Windows.Forms.Label();
            this.lbTitulo3 = new System.Windows.Forms.Label();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.pnlControlBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlControlBox
            // 
            this.pnlControlBox.BackColor = System.Drawing.Color.DodgerBlue;
            this.pnlControlBox.Controls.Add(this.lblCbTitulo);
            this.pnlControlBox.Controls.Add(this.lblCbMinimizar);
            this.pnlControlBox.Controls.Add(this.lblCbCerrar);
            this.pnlControlBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlControlBox.Location = new System.Drawing.Point(0, 0);
            this.pnlControlBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlControlBox.Name = "pnlControlBox";
            this.pnlControlBox.Size = new System.Drawing.Size(334, 30);
            this.pnlControlBox.TabIndex = 18;
            this.pnlControlBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlControlBox_MouseDown);
            // 
            // lblCbTitulo
            // 
            this.lblCbTitulo.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblCbTitulo.ForeColor = System.Drawing.Color.White;
            this.lblCbTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblCbTitulo.Name = "lblCbTitulo";
            this.lblCbTitulo.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.lblCbTitulo.Size = new System.Drawing.Size(208, 30);
            this.lblCbTitulo.TabIndex = 2;
            this.lblCbTitulo.Text = "Masengger - Iniciar Sesión";
            this.lblCbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCbTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlControlBox_MouseDown);
            // 
            // lblCbMinimizar
            // 
            this.lblCbMinimizar.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblCbMinimizar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCbMinimizar.ForeColor = System.Drawing.Color.White;
            this.lblCbMinimizar.Location = new System.Drawing.Point(246, 0);
            this.lblCbMinimizar.Name = "lblCbMinimizar";
            this.lblCbMinimizar.Size = new System.Drawing.Size(44, 30);
            this.lblCbMinimizar.TabIndex = 1;
            this.lblCbMinimizar.Text = "__";
            this.lblCbMinimizar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCbMinimizar.Click += new System.EventHandler(this.lblCbMinimizar_Click);
            this.lblCbMinimizar.MouseEnter += new System.EventHandler(this.lblCb_MouseEnter);
            this.lblCbMinimizar.MouseLeave += new System.EventHandler(this.lblCb_MouseLeave);
            // 
            // lblCbCerrar
            // 
            this.lblCbCerrar.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblCbCerrar.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCbCerrar.ForeColor = System.Drawing.Color.White;
            this.lblCbCerrar.Location = new System.Drawing.Point(290, 0);
            this.lblCbCerrar.Name = "lblCbCerrar";
            this.lblCbCerrar.Size = new System.Drawing.Size(44, 30);
            this.lblCbCerrar.TabIndex = 0;
            this.lblCbCerrar.Text = "X";
            this.lblCbCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCbCerrar.Click += new System.EventHandler(this.lblCbCerrar_Click);
            this.lblCbCerrar.MouseEnter += new System.EventHandler(this.lblCb_MouseEnter);
            this.lblCbCerrar.MouseLeave += new System.EventHandler(this.lblCb_MouseLeave);
            // 
            // lnkRegistrarse
            // 
            this.lnkRegistrarse.ActiveLinkColor = System.Drawing.Color.White;
            this.lnkRegistrarse.AutoSize = true;
            this.lnkRegistrarse.DisabledLinkColor = System.Drawing.Color.White;
            this.lnkRegistrarse.ForeColor = System.Drawing.Color.White;
            this.lnkRegistrarse.LinkColor = System.Drawing.Color.White;
            this.lnkRegistrarse.Location = new System.Drawing.Point(66, 321);
            this.lnkRegistrarse.Name = "lnkRegistrarse";
            this.lnkRegistrarse.Size = new System.Drawing.Size(212, 18);
            this.lnkRegistrarse.TabIndex = 35;
            this.lnkRegistrarse.TabStop = true;
            this.lnkRegistrarse.Text = "Haz click aqui para registrarse";
            this.lnkRegistrarse.VisitedLinkColor = System.Drawing.Color.White;
            this.lnkRegistrarse.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRegistrarse_LinkClicked);
            // 
            // pnlVista1
            // 
            this.pnlVista1.BackColor = System.Drawing.Color.DodgerBlue;
            this.pnlVista1.Location = new System.Drawing.Point(22, 296);
            this.pnlVista1.Name = "pnlVista1";
            this.pnlVista1.Size = new System.Drawing.Size(297, 1);
            this.pnlVista1.TabIndex = 34;
            // 
            // lblLoginTitulo
            // 
            this.lblLoginTitulo.AutoSize = true;
            this.lblLoginTitulo.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginTitulo.ForeColor = System.Drawing.Color.White;
            this.lblLoginTitulo.Location = new System.Drawing.Point(15, 43);
            this.lblLoginTitulo.Name = "lblLoginTitulo";
            this.lblLoginTitulo.Size = new System.Drawing.Size(172, 37);
            this.lblLoginTitulo.TabIndex = 33;
            this.lblLoginTitulo.Text = "Iniciar Sesión";
            // 
            // btnConectar
            // 
            this.btnConectar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConectar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnConectar.FlatAppearance.BorderSize = 0;
            this.btnConectar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConectar.ForeColor = System.Drawing.Color.White;
            this.btnConectar.Location = new System.Drawing.Point(205, 234);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(114, 39);
            this.btnConectar.TabIndex = 30;
            this.btnConectar.Text = "Conectar";
            this.btnConectar.UseVisualStyleBackColor = false;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // lbTitulo2
            // 
            this.lbTitulo2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTitulo2.AutoSize = true;
            this.lbTitulo2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo2.ForeColor = System.Drawing.Color.Gainsboro;
            this.lbTitulo2.Location = new System.Drawing.Point(22, 156);
            this.lbTitulo2.Name = "lbTitulo2";
            this.lbTitulo2.Size = new System.Drawing.Size(85, 17);
            this.lbTitulo2.TabIndex = 31;
            this.lbTitulo2.Text = "Contraseña:";
            // 
            // lbTitulo3
            // 
            this.lbTitulo3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTitulo3.AutoSize = true;
            this.lbTitulo3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo3.ForeColor = System.Drawing.Color.Gainsboro;
            this.lbTitulo3.Location = new System.Drawing.Point(22, 92);
            this.lbTitulo3.Name = "lbTitulo3";
            this.lbTitulo3.Size = new System.Drawing.Size(55, 17);
            this.lbTitulo3.TabIndex = 32;
            this.lbTitulo3.Text = "Correo:";
            // 
            // txtCorreo
            // 
            this.txtCorreo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCorreo.BackColor = System.Drawing.Color.White;
            this.txtCorreo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCorreo.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorreo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCorreo.Location = new System.Drawing.Point(22, 115);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(297, 35);
            this.txtCorreo.TabIndex = 28;
            // 
            // txtContrasena
            // 
            this.txtContrasena.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContrasena.BackColor = System.Drawing.Color.White;
            this.txtContrasena.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContrasena.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContrasena.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtContrasena.Location = new System.Drawing.Point(22, 179);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.PasswordChar = '•';
            this.txtContrasena.Size = new System.Drawing.Size(297, 35);
            this.txtContrasena.TabIndex = 29;
            this.txtContrasena.UseSystemPasswordChar = true;
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(334, 383);
            this.Controls.Add(this.lnkRegistrarse);
            this.Controls.Add(this.pnlVista1);
            this.Controls.Add(this.lblLoginTitulo);
            this.Controls.Add(this.btnConectar);
            this.Controls.Add(this.lbTitulo2);
            this.Controls.Add(this.lbTitulo3);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.txtContrasena);
            this.Controls.Add(this.pnlControlBox);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Masengger - Iniciar Sesión";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmLogin_FormClosing);
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.pnlControlBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlControlBox;
        private System.Windows.Forms.Label lblCbTitulo;
        private System.Windows.Forms.Label lblCbMinimizar;
        private System.Windows.Forms.Label lblCbCerrar;
        private System.Windows.Forms.LinkLabel lnkRegistrarse;
        private System.Windows.Forms.Panel pnlVista1;
        private System.Windows.Forms.Label lblLoginTitulo;
        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.Label lbTitulo2;
        private System.Windows.Forms.Label lbTitulo3;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.TextBox txtContrasena;
    }
}