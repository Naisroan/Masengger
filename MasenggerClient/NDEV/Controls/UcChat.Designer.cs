
namespace MasenggerClient.NDEV.Controls
{
    partial class UcChat
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlChatGrupo = new System.Windows.Forms.Panel();
            this.rTxtMensajes = new System.Windows.Forms.RichTextBox();
            this.pnlMargen5 = new System.Windows.Forms.Panel();
            this.pnlMargen4 = new System.Windows.Forms.Panel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblMensajeTitulo = new System.Windows.Forms.Label();
            this.pnlMargen3 = new System.Windows.Forms.Panel();
            this.pnlEmojis = new System.Windows.Forms.Panel();
            this.pbEmoji6 = new System.Windows.Forms.PictureBox();
            this.pbEmoji5 = new System.Windows.Forms.PictureBox();
            this.pbEmoji4 = new System.Windows.Forms.PictureBox();
            this.pbEmoji3 = new System.Windows.Forms.PictureBox();
            this.pbEmoji2 = new System.Windows.Forms.PictureBox();
            this.pbEmoji1 = new System.Windows.Forms.PictureBox();
            this.pnlMargen2 = new System.Windows.Forms.Panel();
            this.pnlMensaje = new System.Windows.Forms.Panel();
            this.txtMensaje = new System.Windows.Forms.TextBox();
            this.pnlMargen1 = new System.Windows.Forms.Panel();
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.btnEnviarArchivo = new System.Windows.Forms.Button();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.lblChatTitulo = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.pnlChatGrupo.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlEmojis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbEmoji6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEmoji5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEmoji4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEmoji3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEmoji2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEmoji1)).BeginInit();
            this.pnlMensaje.SuspendLayout();
            this.pnlBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlChatGrupo
            // 
            this.pnlChatGrupo.BackColor = System.Drawing.Color.Black;
            this.pnlChatGrupo.Controls.Add(this.rTxtMensajes);
            this.pnlChatGrupo.Controls.Add(this.pnlMargen5);
            this.pnlChatGrupo.Controls.Add(this.pnlMargen4);
            this.pnlChatGrupo.Controls.Add(this.pnlBottom);
            this.pnlChatGrupo.Controls.Add(this.lblChatTitulo);
            this.pnlChatGrupo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChatGrupo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlChatGrupo.Location = new System.Drawing.Point(15, 15);
            this.pnlChatGrupo.Name = "pnlChatGrupo";
            this.pnlChatGrupo.Size = new System.Drawing.Size(253, 632);
            this.pnlChatGrupo.TabIndex = 23;
            // 
            // rTxtMensajes
            // 
            this.rTxtMensajes.BackColor = System.Drawing.Color.Black;
            this.rTxtMensajes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rTxtMensajes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rTxtMensajes.ForeColor = System.Drawing.Color.White;
            this.rTxtMensajes.Location = new System.Drawing.Point(0, 25);
            this.rTxtMensajes.Name = "rTxtMensajes";
            this.rTxtMensajes.ReadOnly = true;
            this.rTxtMensajes.Size = new System.Drawing.Size(253, 453);
            this.rTxtMensajes.TabIndex = 32;
            this.rTxtMensajes.Text = "";
            this.rTxtMensajes.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rTxtMensajes_LinkClickedAsync);
            // 
            // pnlMargen5
            // 
            this.pnlMargen5.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMargen5.Location = new System.Drawing.Point(0, 15);
            this.pnlMargen5.Name = "pnlMargen5";
            this.pnlMargen5.Size = new System.Drawing.Size(253, 10);
            this.pnlMargen5.TabIndex = 31;
            // 
            // pnlMargen4
            // 
            this.pnlMargen4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlMargen4.Location = new System.Drawing.Point(0, 478);
            this.pnlMargen4.Name = "pnlMargen4";
            this.pnlMargen4.Size = new System.Drawing.Size(253, 10);
            this.pnlMargen4.TabIndex = 30;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.lblMensajeTitulo);
            this.pnlBottom.Controls.Add(this.pnlMargen3);
            this.pnlBottom.Controls.Add(this.pnlEmojis);
            this.pnlBottom.Controls.Add(this.pnlMargen2);
            this.pnlBottom.Controls.Add(this.pnlMensaje);
            this.pnlBottom.Controls.Add(this.pnlMargen1);
            this.pnlBottom.Controls.Add(this.pnlBotones);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 488);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(253, 144);
            this.pnlBottom.TabIndex = 26;
            // 
            // lblMensajeTitulo
            // 
            this.lblMensajeTitulo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblMensajeTitulo.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensajeTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblMensajeTitulo.Location = new System.Drawing.Point(0, 3);
            this.lblMensajeTitulo.Name = "lblMensajeTitulo";
            this.lblMensajeTitulo.Size = new System.Drawing.Size(253, 25);
            this.lblMensajeTitulo.TabIndex = 19;
            this.lblMensajeTitulo.Text = "Ingresa algún mensaje:";
            // 
            // pnlMargen3
            // 
            this.pnlMargen3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlMargen3.Location = new System.Drawing.Point(0, 28);
            this.pnlMargen3.Name = "pnlMargen3";
            this.pnlMargen3.Size = new System.Drawing.Size(253, 10);
            this.pnlMargen3.TabIndex = 29;
            // 
            // pnlEmojis
            // 
            this.pnlEmojis.Controls.Add(this.pbEmoji6);
            this.pnlEmojis.Controls.Add(this.pbEmoji5);
            this.pnlEmojis.Controls.Add(this.pbEmoji4);
            this.pnlEmojis.Controls.Add(this.pbEmoji3);
            this.pnlEmojis.Controls.Add(this.pbEmoji2);
            this.pnlEmojis.Controls.Add(this.pbEmoji1);
            this.pnlEmojis.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlEmojis.Location = new System.Drawing.Point(0, 38);
            this.pnlEmojis.Name = "pnlEmojis";
            this.pnlEmojis.Size = new System.Drawing.Size(253, 24);
            this.pnlEmojis.TabIndex = 22;
            // 
            // pbEmoji6
            // 
            this.pbEmoji6.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbEmoji6.Image = global::MasenggerClient.Properties.Resources.victory_hand_emoji_modifier_fitzpatrick_type_3_270c_1f3fc_1f3fc;
            this.pbEmoji6.Location = new System.Drawing.Point(210, 0);
            this.pbEmoji6.Name = "pbEmoji6";
            this.pbEmoji6.Size = new System.Drawing.Size(42, 24);
            this.pbEmoji6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbEmoji6.TabIndex = 5;
            this.pbEmoji6.TabStop = false;
            this.pbEmoji6.Tag = "(y)";
            this.pbEmoji6.Click += new System.EventHandler(this.InsertarEmoji);
            // 
            // pbEmoji5
            // 
            this.pbEmoji5.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbEmoji5.Image = global::MasenggerClient.Properties.Resources.smiling_face_with_open_mouth_and_smiling_eyes_1f604;
            this.pbEmoji5.Location = new System.Drawing.Point(168, 0);
            this.pbEmoji5.Name = "pbEmoji5";
            this.pbEmoji5.Size = new System.Drawing.Size(42, 24);
            this.pbEmoji5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbEmoji5.TabIndex = 4;
            this.pbEmoji5.TabStop = false;
            this.pbEmoji5.Tag = "n.n";
            this.pbEmoji5.Click += new System.EventHandler(this.InsertarEmoji);
            // 
            // pbEmoji4
            // 
            this.pbEmoji4.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbEmoji4.Image = global::MasenggerClient.Properties.Resources.smiling_face_with_heart_shaped_eyes_1f60d;
            this.pbEmoji4.Location = new System.Drawing.Point(126, 0);
            this.pbEmoji4.Name = "pbEmoji4";
            this.pbEmoji4.Size = new System.Drawing.Size(42, 24);
            this.pbEmoji4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbEmoji4.TabIndex = 3;
            this.pbEmoji4.TabStop = false;
            this.pbEmoji4.Tag = "<3.<3";
            this.pbEmoji4.Click += new System.EventHandler(this.InsertarEmoji);
            // 
            // pbEmoji3
            // 
            this.pbEmoji3.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbEmoji3.Image = global::MasenggerClient.Properties.Resources.pouting_face_1f621;
            this.pbEmoji3.Location = new System.Drawing.Point(84, 0);
            this.pbEmoji3.Name = "pbEmoji3";
            this.pbEmoji3.Size = new System.Drawing.Size(42, 24);
            this.pbEmoji3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbEmoji3.TabIndex = 2;
            this.pbEmoji3.TabStop = false;
            this.pbEmoji3.Tag = ">:c";
            this.pbEmoji3.Click += new System.EventHandler(this.InsertarEmoji);
            // 
            // pbEmoji2
            // 
            this.pbEmoji2.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbEmoji2.Image = global::MasenggerClient.Properties.Resources.grinning_face_1f600;
            this.pbEmoji2.Location = new System.Drawing.Point(42, 0);
            this.pbEmoji2.Name = "pbEmoji2";
            this.pbEmoji2.Size = new System.Drawing.Size(42, 24);
            this.pbEmoji2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbEmoji2.TabIndex = 1;
            this.pbEmoji2.TabStop = false;
            this.pbEmoji2.Tag = ":D";
            this.pbEmoji2.Click += new System.EventHandler(this.InsertarEmoji);
            // 
            // pbEmoji1
            // 
            this.pbEmoji1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbEmoji1.Image = global::MasenggerClient.Properties.Resources.face_with_tears_of_joy_1f602;
            this.pbEmoji1.Location = new System.Drawing.Point(0, 0);
            this.pbEmoji1.Name = "pbEmoji1";
            this.pbEmoji1.Size = new System.Drawing.Size(42, 24);
            this.pbEmoji1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbEmoji1.TabIndex = 0;
            this.pbEmoji1.TabStop = false;
            this.pbEmoji1.Tag = "xD";
            this.pbEmoji1.Click += new System.EventHandler(this.InsertarEmoji);
            // 
            // pnlMargen2
            // 
            this.pnlMargen2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlMargen2.Location = new System.Drawing.Point(0, 62);
            this.pnlMargen2.Name = "pnlMargen2";
            this.pnlMargen2.Size = new System.Drawing.Size(253, 10);
            this.pnlMargen2.TabIndex = 28;
            // 
            // pnlMensaje
            // 
            this.pnlMensaje.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlMensaje.Controls.Add(this.txtMensaje);
            this.pnlMensaje.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlMensaje.Location = new System.Drawing.Point(0, 72);
            this.pnlMensaje.Name = "pnlMensaje";
            this.pnlMensaje.Size = new System.Drawing.Size(253, 31);
            this.pnlMensaje.TabIndex = 24;
            // 
            // txtMensaje
            // 
            this.txtMensaje.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMensaje.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtMensaje.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMensaje.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMensaje.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtMensaje.Location = new System.Drawing.Point(3, 6);
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.Size = new System.Drawing.Size(247, 20);
            this.txtMensaje.TabIndex = 23;
            // 
            // pnlMargen1
            // 
            this.pnlMargen1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlMargen1.Location = new System.Drawing.Point(0, 103);
            this.pnlMargen1.Name = "pnlMargen1";
            this.pnlMargen1.Size = new System.Drawing.Size(253, 10);
            this.pnlMargen1.TabIndex = 27;
            // 
            // pnlBotones
            // 
            this.pnlBotones.Controls.Add(this.btnEnviarArchivo);
            this.pnlBotones.Controls.Add(this.btnEnviar);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotones.Location = new System.Drawing.Point(0, 113);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(253, 31);
            this.pnlBotones.TabIndex = 26;
            // 
            // btnEnviarArchivo
            // 
            this.btnEnviarArchivo.BackColor = System.Drawing.Color.Gray;
            this.btnEnviarArchivo.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnEnviarArchivo.FlatAppearance.BorderSize = 0;
            this.btnEnviarArchivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviarArchivo.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviarArchivo.ForeColor = System.Drawing.Color.White;
            this.btnEnviarArchivo.Image = global::MasenggerClient.Properties.Resources.attach_file_white_192x192;
            this.btnEnviarArchivo.Location = new System.Drawing.Point(53, 0);
            this.btnEnviarArchivo.Name = "btnEnviarArchivo";
            this.btnEnviarArchivo.Size = new System.Drawing.Size(100, 31);
            this.btnEnviarArchivo.TabIndex = 25;
            this.btnEnviarArchivo.Text = "Adjuntar";
            this.btnEnviarArchivo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEnviarArchivo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEnviarArchivo.UseVisualStyleBackColor = false;
            this.btnEnviarArchivo.Click += new System.EventHandler(this.btnEnviarArchivo_Click);
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnEnviar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnEnviar.FlatAppearance.BorderSize = 0;
            this.btnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviar.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviar.ForeColor = System.Drawing.Color.White;
            this.btnEnviar.Location = new System.Drawing.Point(153, 0);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(100, 31);
            this.btnEnviar.TabIndex = 5;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEnviar.UseVisualStyleBackColor = false;
            this.btnEnviar.Click += new System.EventHandler(this.BtnEnviar_Click);
            // 
            // lblChatTitulo
            // 
            this.lblChatTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChatTitulo.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChatTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblChatTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblChatTitulo.Name = "lblChatTitulo";
            this.lblChatTitulo.Size = new System.Drawing.Size(253, 15);
            this.lblChatTitulo.TabIndex = 17;
            this.lblChatTitulo.Text = "Mensajes recientes:";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Title = "Seleccione el archivo a enviar";
            // 
            // UcChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.pnlChatGrupo);
            this.Name = "UcChat";
            this.Padding = new System.Windows.Forms.Padding(15);
            this.Size = new System.Drawing.Size(283, 662);
            this.Load += new System.EventHandler(this.UcChat_Load);
            this.pnlChatGrupo.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlEmojis.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbEmoji6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEmoji5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEmoji4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEmoji3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEmoji2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEmoji1)).EndInit();
            this.pnlMensaje.ResumeLayout(false);
            this.pnlMensaje.PerformLayout();
            this.pnlBotones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlChatGrupo;
        private System.Windows.Forms.Panel pnlMargen5;
        private System.Windows.Forms.Panel pnlMargen4;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label lblMensajeTitulo;
        private System.Windows.Forms.Panel pnlMargen3;
        private System.Windows.Forms.Panel pnlEmojis;
        private System.Windows.Forms.PictureBox pbEmoji6;
        private System.Windows.Forms.PictureBox pbEmoji5;
        private System.Windows.Forms.PictureBox pbEmoji4;
        private System.Windows.Forms.PictureBox pbEmoji3;
        private System.Windows.Forms.PictureBox pbEmoji2;
        private System.Windows.Forms.PictureBox pbEmoji1;
        private System.Windows.Forms.Panel pnlMargen2;
        private System.Windows.Forms.Panel pnlMensaje;
        private System.Windows.Forms.TextBox txtMensaje;
        private System.Windows.Forms.Panel pnlMargen1;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Button btnEnviarArchivo;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Label lblChatTitulo;
        private System.Windows.Forms.RichTextBox rTxtMensajes;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}
