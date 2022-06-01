using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using tp1_grupo6.Logica;

namespace tp1_grupo6.Front
{
    public partial class Perfil : Form
    {
        private RedSocial miRed;

        public Perfil(RedSocial miRed)
        {
            this.miRed = miRed;

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {






        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (miRed.EliminarUsuario(miRed.usuarioActual.ID))
            {
                MessageBox.Show("Eliminado con éxito");
            }
            else
            {
                MessageBox.Show("No se pudo eliminar el usuario");
            }    
        }

        private void textBoxNombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
