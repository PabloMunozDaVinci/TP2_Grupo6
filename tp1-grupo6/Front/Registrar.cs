using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using tp1_grupo6.Logica;



namespace tp1_grupo6.Front
{
    public partial class Registrar : Form
    {
        private RedSocial miRed;
        private string[] argumentos;
        static Regex validate_emailaddress = email_validation();

        public Registrar(RedSocial miRed)
        {
            InitializeComponent();
            this.miRed = miRed;
        }

        private void Confirmar_Click(object sender, EventArgs e)
        {
            int DNI = 0;
            string nombre = "";
            string apellido = "";
            string mail = "";
            string password = "";
            string passwordRepetida = "";

            bool todoOk = true;

            try
            {
                DNI = Int32.Parse(textBoxDNI.Text);
            }
            catch
            {
                MessageBox.Show("El DNI es un dato numérico.");
                todoOk = false;
            }

            nombre = textBoxNombre.Text;
            apellido = textBoxApellido.Text;
            mail = textBoxMail.Text;
            password = textBoxContrasenia.Text;
            passwordRepetida = textBoxContraseniaRepetida.Text;

            if (DNI <= 0)
            {
                MessageBox.Show("Ingrese DNI");
                todoOk = false;
            }


            if (nombre == "")
            {
                MessageBox.Show("Ingrese Nombre");
                todoOk = false;
            }


            if (mail == "")
            {
                MessageBox.Show("Ingrese Mail");
                todoOk = false;
            }
            else if (miRed.ExisteUsuario(mail))
            {
                MessageBox.Show("El Mail ingresado ya pertenece a un Usuario existente.");
                textBoxMail.Text = "";
                todoOk = false;
            }


            if (validate_emailaddress.IsMatch(mail) != true)
            {
                MessageBox.Show("Ingrese un Mail válido.");
                todoOk = false;
            }

  
            if (password == "")
            {
                MessageBox.Show("Ingrese Contraseña");
                todoOk = false;
            }
            else if (password != passwordRepetida)
            {
                MessageBox.Show("Las contraseñas deben coincidir");
                textBoxContrasenia.Text = "";
                textBoxContraseniaRepetida.Text = "";
                todoOk = false;
            }

            if (todoOk)
            {
                miRed.RegistrarUsuario(DNI, nombre, apellido, mail, password);
                MessageBox.Show("Su Usuario se registro exitosamente.");
                Dispose();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private static Regex email_validation()
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return new Regex(pattern, RegexOptions.IgnoreCase);
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void Registrar_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
