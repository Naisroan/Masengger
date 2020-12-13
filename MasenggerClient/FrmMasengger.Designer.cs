
namespace MasenggerClient
{
    partial class FrmMasengger
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
            this.lbUsuarios = new System.Windows.Forms.ListBox();
            this.pbVideoFrame = new System.Windows.Forms.PictureBox();
            this.ucChat = new MasenggerClient.NDEV.Controls.UcChat();
            this.pnlVista1 = new System.Windows.Forms.Panel();
            this.pnlControlBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbVideoFrame)).BeginInit();
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
            this.pnlControlBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlControlBox.Name = "pnlControlBox";
            this.pnlControlBox.Size = new System.Drawing.Size(1066, 30);
            this.pnlControlBox.TabIndex = 19;
            this.pnlControlBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlControlBox_MouseDown);
            // 
            // lblCbTitulo
            // 
            this.lblCbTitulo.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblCbTitulo.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCbTitulo.ForeColor = System.Drawing.Color.White;
            this.lblCbTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblCbTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCbTitulo.Name = "lblCbTitulo";
            this.lblCbTitulo.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.lblCbTitulo.Size = new System.Drawing.Size(513, 30);
            this.lblCbTitulo.TabIndex = 2;
            this.lblCbTitulo.Text = "Masengger";
            this.lblCbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCbTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlControlBox_MouseDown);
            // 
            // lblCbMinimizar
            // 
            this.lblCbMinimizar.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblCbMinimizar.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCbMinimizar.ForeColor = System.Drawing.Color.White;
            this.lblCbMinimizar.Location = new System.Drawing.Point(1000, 0);
            this.lblCbMinimizar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCbMinimizar.Name = "lblCbMinimizar";
            this.lblCbMinimizar.Size = new System.Drawing.Size(33, 30);
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
            this.lblCbCerrar.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCbCerrar.ForeColor = System.Drawing.Color.White;
            this.lblCbCerrar.Location = new System.Drawing.Point(1033, 0);
            this.lblCbCerrar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCbCerrar.Name = "lblCbCerrar";
            this.lblCbCerrar.Size = new System.Drawing.Size(33, 30);
            this.lblCbCerrar.TabIndex = 0;
            this.lblCbCerrar.Text = "X";
            this.lblCbCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCbCerrar.Click += new System.EventHandler(this.lblCbCerrar_Click);
            this.lblCbCerrar.MouseEnter += new System.EventHandler(this.lblCb_MouseEnter);
            this.lblCbCerrar.MouseLeave += new System.EventHandler(this.lblCb_MouseLeave);
            // 
            // lbUsuarios
            // 
            this.lbUsuarios.BackColor = System.Drawing.Color.Black;
            this.lbUsuarios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbUsuarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbUsuarios.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbUsuarios.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUsuarios.ForeColor = System.Drawing.Color.Silver;
            this.lbUsuarios.FormattingEnabled = true;
            this.lbUsuarios.ItemHeight = 23;
            this.lbUsuarios.Location = new System.Drawing.Point(0, 30);
            this.lbUsuarios.Name = "lbUsuarios";
            this.lbUsuarios.Size = new System.Drawing.Size(228, 570);
            this.lbUsuarios.TabIndex = 22;
            this.lbUsuarios.TabStop = false;
            this.lbUsuarios.SelectedIndexChanged += new System.EventHandler(this.lbUsuarios_SelectedIndexChanged);
            // 
            // pbVideoFrame
            // 
            this.pbVideoFrame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbVideoFrame.Location = new System.Drawing.Point(229, 30);
            this.pbVideoFrame.Name = "pbVideoFrame";
            this.pbVideoFrame.Size = new System.Drawing.Size(554, 570);
            this.pbVideoFrame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbVideoFrame.TabIndex = 23;
            this.pbVideoFrame.TabStop = false;
            // 
            // ucChat
            // 
            this.ucChat.BackColor = System.Drawing.Color.Black;
            this.ucChat.Dock = System.Windows.Forms.DockStyle.Right;
            this.ucChat.Location = new System.Drawing.Point(783, 30);
            this.ucChat.Name = "ucChat";
            this.ucChat.Padding = new System.Windows.Forms.Padding(15);
            this.ucChat.Size = new System.Drawing.Size(283, 570);
            this.ucChat.TabIndex = 21;
            // 
            // pnlVista1
            // 
            this.pnlVista1.BackColor = System.Drawing.Color.DodgerBlue;
            this.pnlVista1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlVista1.Location = new System.Drawing.Point(228, 30);
            this.pnlVista1.Name = "pnlVista1";
            this.pnlVista1.Size = new System.Drawing.Size(1, 570);
            this.pnlVista1.TabIndex = 24;
            // 
            // FrmMasengger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1066, 600);
            this.Controls.Add(this.pbVideoFrame);
            this.Controls.Add(this.pnlVista1);
            this.Controls.Add(this.lbUsuarios);
            this.Controls.Add(this.ucChat);
            this.Controls.Add(this.pnlControlBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmMasengger";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Masengger";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmLogin_FormClosing);
            this.Load += new System.EventHandler(this.FrmMasengger_Load);
            this.pnlControlBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbVideoFrame)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlControlBox;
        private System.Windows.Forms.Label lblCbTitulo;
        private System.Windows.Forms.Label lblCbMinimizar;
        private System.Windows.Forms.Label lblCbCerrar;
        private NDEV.Controls.UcChat ucChat;
        private System.Windows.Forms.ListBox lbUsuarios;
        private System.Windows.Forms.PictureBox pbVideoFrame;
        private System.Windows.Forms.Panel pnlVista1;
    }
}