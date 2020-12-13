using MasenggerModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MasenggerClient
{
    public partial class FrmLogin : Form
    {
        ServerConnection conn = ServerConnection.GetConnection();

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            try
            {
#if DEBUG
                txtCorreo.Text = "ian@hotmail.com";
                txtContrasena.Text = "123";
#endif
            }
            catch (Exception ex)
            {
                Fun.MsgErrorException(this, ex);
            }
        }

        #region "BOTONES"

        private async void btnConectar_Click(object sender, EventArgs e)
        {
            try
            {
                btnConectar.Enabled = false;

                string mensaje = string.Empty;

                if (!CamposValidos())
                {
                    btnConectar.Enabled = true;
                    return;
                }

                bool conexionExitosa = conn.Connect(ref mensaje, Fun.SERVER_IP, Fun.SERVER_PUERTO);

                if (!conexionExitosa)
                {
                    while (!conexionExitosa && Fun.MsgWarningYesNo(this, "No se ha podido establecer una conexión, ¿reintentarlo?") == DialogResult.Yes)
                    {
                        conexionExitosa = conn.Connect(ref mensaje, Fun.SERVER_IP, Fun.SERVER_PUERTO);
                    }

                    btnConectar.Enabled = true;
                    return;
                }

                Usuario usuario = new Usuario()
                {
                    Id = 0,
                    Nick = string.Empty,
                    Correo = txtCorreo.Text,
                    Password = txtContrasena.Text
                };

                Response res = await conn.SendWait("login_validuser", usuario);

                if (!Fun.IsValid(this, res))
                {
                    btnConectar.Enabled = true;
                    return;
                }

                conn.Usuario = JsonConvert.DeserializeObject<Usuario>(Convert.ToString(res.Value));
                FrmMasengger frmMasengger = new FrmMasengger(this);
                frmMasengger.Show();
                Hide();
                btnConectar.Enabled = true;
            }
            catch (Exception ex)
            {
                Fun.MsgErrorException(this, ex);
                btnConectar.Enabled = true;
            }
        }

        private void lnkRegistrarse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmRegistro frmRegistro = new FrmRegistro(this);
            frmRegistro.Show();
            Hide();
        }

        #endregion

        #region "VALIDACIONES"

        /// <summary>
        /// Metodo para validar la información de los campos del Login
        /// </summary>
        /// <returns>retorna verdadero si todos los campos fueron validos</returns>
        private bool CamposValidos()
        {
            if (string.IsNullOrEmpty(txtCorreo.Text))
            {
                MessageBox.Show(this, "Ingrese su correo", "Espere", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtContrasena.Text))
            {
                MessageBox.Show(this, "Ingrese su contraseña", "Espere", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        #endregion

        #region "EVENTOS"

        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                conn.CloseAsync();
            }
            catch (Exception ex)
            {
                Fun.MsgErrorException(this, ex);
            }
        }

        private void lblCbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lblCbMinimizar_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Minimized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void lblCb_MouseEnter(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;

            if (lbl.Name == lblCbCerrar.Name)
            {
                lbl.BackColor = Color.IndianRed;
                lbl.ForeColor = Color.White;
            }
            else if (lbl.Name == lblCbMinimizar.Name)
            {
                lbl.BackColor = Color.Black;
                lbl.ForeColor = Color.White;
            }
        }

        private void lblCb_MouseLeave(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;

            if (lbl.Name == lblCbCerrar.Name)
            {
                lbl.BackColor = lbl.Parent.BackColor;
                lbl.ForeColor = Color.White;
            }
            else if (lbl.Name == lblCbMinimizar.Name)
            {
                lbl.BackColor = lbl.Parent.BackColor;
                lbl.ForeColor = Color.White;
            }
        }

        private void pnlControlBox_MouseDown(object sender, MouseEventArgs e)
        {
            Fun.ReleaseCapture();
            Fun.SendMessage(Handle, 0x112, 0xf012, 0);
        }

        #endregion
    }
}
