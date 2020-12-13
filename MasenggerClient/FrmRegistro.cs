using MasenggerModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MasenggerClient
{
    public partial class FrmRegistro : Form
    {
        #region "ATRIBUTOS"

        FrmLogin FrmLogin;
        ServerConnection conn = ServerConnection.GetConnection();

        #endregion

        public FrmRegistro(FrmLogin frmLogin)
        {
            InitializeComponent();
            FrmLogin = frmLogin;
        }

        private void FrmRegistro_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Fun.MsgErrorException(this, ex);
            }
        }

        #region "BOTONES"

        private async void btnRegistrarse_Click(object sender, EventArgs e)
        {
            try
            {
                btnRegistrarse.Enabled = false;

                if (!CamposValidos())
                {
                    btnRegistrarse.Enabled = true;
                    return;
                }

                string mensaje = string.Empty;

                if (!CamposValidos())
                {
                    btnRegistrarse.Enabled = true;
                    return;
                }

                bool conexionExitosa = conn.Connect(ref mensaje, Fun.SERVER_IP, Fun.SERVER_PUERTO);

                if (!conexionExitosa)
                {
                    while (!conexionExitosa && Fun.MsgWarningYesNo(this, "No se ha podido establecer una conexión, ¿reintentarlo?") == DialogResult.Yes)
                    {
                        conexionExitosa = conn.Connect(ref mensaje, Fun.SERVER_IP, Fun.SERVER_PUERTO);
                    }

                    btnRegistrarse.Enabled = true;
                    return;
                }

                Usuario usuario = new Usuario()
                {
                    Id = 0,
                    Nick = txtUsuario.Text,
                    Correo = txtCorreo.Text,
                    Password = txtContrasena.Text
                };

                Response res = await conn.SendWait("register_create", usuario);

                if (!Fun.IsValid(this, res))
                {
                    btnRegistrarse.Enabled = true;
                    return;
                }

                Fun.SendMail(txtCorreo.Text, $"Masengger - Bienvenid@ {usuario.Nick} ♥", "Te damos la bienvenida a Masengger! si recibiste este correo tu cuenta ha sido confirmada.");

                MessageBox.Show(this, $"Cuenta registrada con exito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Close();
            }
            catch (Exception ex)
            {
                Fun.MsgError(this, ex.Message);
                btnRegistrarse.Enabled = true;
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region "VALIDACIONES"

        private bool CamposValidos()
        {
            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                MessageBox.Show(this, "Ingrese su usuario", "Espere", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtCorreo.Text))
            {
                MessageBox.Show(this, "Ingrese su correo", "Espere", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

            if (!Regex.IsMatch(txtCorreo.Text, pattern))
            {
                MessageBox.Show(this, "Ingrese un correo valido", "Espere", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtContrasena.Text))
            {
                MessageBox.Show(this, "Ingrese su contraseña", "Espere", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtConfirmarContrasena.Text))
            {
                MessageBox.Show(this, "Confirme su contraseña", "Espere", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtContrasena.Text != txtConfirmarContrasena.Text)
            {
                MessageBox.Show(this, "Las contraseñas no coinciden", "Espere", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                FrmLogin.Show();
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
