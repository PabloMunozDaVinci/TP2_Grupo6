using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tp1_grupo6.Logica;
using tp1_grupo6.Front;
using EasyEncryption;

namespace tp1_grupo6
{
    public partial class Login : Form
    {
        public RedSocial miRed;
        private Usuario usuario;
        public string usuarioIngresado;
        public string contraseniaIngresada;
        public bool loginOk;
        private string[] argumentos;

        public Login(string[] args)
        {
            miRed = new RedSocial();

            InitializeComponent();
            argumentos = args;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            labelIntentos.Text = "";
            usuarioIngresado = textUsuario.Text;
            contraseniaIngresada = textContrasenia.Text;
            if (miRed.ExisteUsuario(usuarioIngresado))
            {
                if (!miRed.EstaBloqueado(usuarioIngresado))
                {
                    loginOk = miRed.IniciarUsuario(usuarioIngresado, contraseniaIngresada);
                    if (loginOk)
                    {
                        argumentos[0] = "user";
                        Form formIndex = new Front.Index(this.miRed, this.usuario);
                        textUsuario.Text = "";
                        textContrasenia.Text = "";
                        miRed.loginHistory.Clear();
                        this.Hide();
                        formIndex.ShowDialog();
                        this.Show();
                    }
                    else
                    {
                        labelIntentos.Text = miRed.Intentos(usuarioIngresado);
                    }

                }
                else
                {
                    labelIntentos.Text = "Su usuario está bloqueado";
                }
            }
            else
            {
                labelIntentos.Text = "Usuario inexistente";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Registrar_Click(object sender, EventArgs e)
        {
            Form registrarse = new Registrar(this.miRed);
            textUsuario.Text = "";
            textContrasenia.Text = "";
            miRed.loginHistory.Clear();
            this.Hide();
            registrarse.ShowDialog();
            this.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

