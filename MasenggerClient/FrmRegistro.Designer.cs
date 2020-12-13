
namespace MasenggerClient
{
    partial class FrmRegistro
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
            this.lblContrasena = new System.Windows.Forms.Label();
            this.txtConfirmarContrasena = new System.Windows.Forms.TextBox();
            this.lblLoginTitulo = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.lbTitulo1 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.btnRegistrarse = new System.Windows.Forms.Button();
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
            this.pnlControlBox.TabIndex = 19;
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
            this.lblCbTitulo.Text = "Masengger - Registro";
            this.lblCbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // lblContrasena
            // 
            this.lblContrasena.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblContrasena.AutoSize = true;
            this.lblContrasena.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContrasena.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblContrasena.Location = new System.Drawing.Point(20, 308);
            this.lblContrasena.Name = "lblContrasena";
            this.lblContrasena.Size = new System.Drawing.Size(150, 17);
            this.lblContrasena.TabIndex = 47;
            this.lblContrasena.Text = "Confirmar Contraseña:";
            // 
            // txtConfirmarContrasena
            // 
            this.txtConfirmarContrasena.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConfirmarContrasena.BackColor = System.Drawing.Color.White;
            this.txtConfirmarContrasena.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConfirmarContrasena.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmarContrasena.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtConfirmarContrasena.Location = new System.Drawing.Point(20, 331);
            this.txtConfirmarContrasena.Name = "txtConfirmarContrasena";
            this.txtConfirmarContrasena.PasswordChar = '•';
            this.txtConfirmarContrasena.Size = new System.Drawing.Size(295, 35);
            this.txtConfirmarContrasena.TabIndex = 46;
            this.txtConfirmarContrasena.UseSystemPasswordChar = true;
            // 
            // lblLoginTitulo
            // 
            this.lblLoginTitulo.AutoSize = true;
            this.lblLoginTitulo.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginTitulo.ForeColor = System.Drawing.Color.White;
            this.lblLoginTitulo.Location = new System.Drawing.Point(16, 44);
            this.lblLoginTitulo.Name = "lblLoginTitulo";
            this.lblLoginTitulo.Size = new System.Drawing.Size(135, 37);
            this.lblLoginTitulo.TabIndex = 45;
            this.lblLoginTitulo.Text = "Registrate";
            // 
            // btnVolver
            // 
            this.btnVolver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVolver.BackColor = System.Drawing.Color.Gray;
            this.btnVolver.FlatAppearance.BorderSize = 0;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.ForeColor = System.Drawing.Color.White;
            this.btnVolver.Location = new System.Drawing.Point(43, 406);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(133, 39);
            this.btnVolver.TabIndex = 44;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // lbTitulo1
            // 
            this.lbTitulo1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTitulo1.AutoSize = true;
            this.lbTitulo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo1.ForeColor = System.Drawing.Color.Gainsboro;
            this.lbTitulo1.Location = new System.Drawing.Point(20, 108);
            this.lbTitulo1.Name = "lbTitulo1";
            this.lbTitulo1.Size = new System.Drawing.Size(61, 17);
            this.lbTitulo1.TabIndex = 37;
            this.lbTitulo1.Text = "Usuario:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsuario.BackColor = System.Drawing.Color.White;
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuario.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtUsuario.Location = new System.Drawing.Point(20, 131);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(295, 35);
            this.txtUsuario.TabIndex = 38;
            // 
            // btnRegistrarse
            // 
            this.btnRegistrarse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegistrarse.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnRegistrarse.FlatAppearance.BorderSize = 0;
            this.btnRegistrarse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarse.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarse.Location = new System.Drawing.Point(182, 406);
            this.btnRegistrarse.Name = "btnRegistrarse";
            this.btnRegistrarse.Size = new System.Drawing.Size(133, 39);
            this.btnRegistrarse.TabIndex = 41;
            this.btnRegistrarse.Text = "Registrarse";
            this.btnRegistrarse.UseVisualStyleBackColor = false;
            this.btnRegistrarse.Click += new System.EventHandler(this.btnRegistrarse_Click);
            // 
            // lbTitulo2
            // 
            this.lbTitulo2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTitulo2.AutoSize = true;
            this.lbTitulo2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo2.ForeColor = System.Drawing.Color.Gainsboro;
            this.lbTitulo2.Location = new System.Drawing.Point(20, 236);
            this.lbTitulo2.Name = "lbTitulo2";
            this.lbTitulo2.Size = new System.Drawing.Size(85, 17);
            this.lbTitulo2.TabIndex = 42;
            this.lbTitulo2.Text = "Contraseña:";
            // 
            // lbTitulo3
            // 
            this.lbTitulo3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTitulo3.AutoSize = true;
            this.lbTitulo3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo3.ForeColor = System.Drawing.Color.Gainsboro;
            this.lbTitulo3.Location = new System.Drawing.Point(20, 172);
            this.lbTitulo3.Name = "lbTitulo3";
            this.lbTitulo3.Size = new System.Drawing.Size(55, 17);
            this.lbTitulo3.TabIndex = 43;
            this.lbTitulo3.Text = "Correo:";
            // 
            // txtCorreo
            // 
            this.txtCorreo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCorreo.BackColor = System.Drawing.Color.White;
            this.txtCorreo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCorreo.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorreo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCorreo.Location = new System.Drawing.Point(20, 195);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(295, 35);
            this.txtCorreo.TabIndex = 39;
            // 
            // txtContrasena
            // 
            this.txtContrasena.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContrasena.BackColor = System.Drawing.Color.White;
            this.txtContrasena.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContrasena.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContrasena.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtContrasena.Location = new System.Drawing.Point(20, 259);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.PasswordChar = '•';
            this.txtContrasena.Size = new System.Drawing.Size(295, 35);
            this.txtContrasena.TabIndex = 40;
            this.txtContrasena.UseSystemPasswordChar = true;
            // 
            // FrmRegistro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(334, 488);
            this.Controls.Add(this.lblContrasena);
            this.Controls.Add(this.txtConfirmarContrasena);
            this.Controls.Add(this.lblLoginTitulo);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.lbTitulo1);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.btnRegistrarse);
            this.Controls.Add(this.lbTitulo2);
            this.Controls.Add(this.lbTitulo3);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.txtContrasena);
            this.Controls.Add(this.pnlControlBox);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmRegistro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmRegistro";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmLogin_FormClosing);
            this.Load += new System.EventHandler(this.FrmRegistro_Load);
            this.pnlControlBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlControlBox;
        private System.Windows.Forms.Label lblCbTitulo;
        private System.Windows.Forms.Label lblCbMinimizar;
        private System.Windows.Forms.Label lblCbCerrar;
        private System.Windows.Forms.Label lblContrasena;
        private System.Windows.Forms.TextBox txtConfirmarContrasena;
        private System.Windows.Forms.Label lblLoginTitulo;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label lbTitulo1;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Button btnRegistrarse;
        private System.Windows.Forms.Label lbTitulo2;
        private System.Windows.Forms.Label lbTitulo3;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.TextBox txtContrasena;
    }
}