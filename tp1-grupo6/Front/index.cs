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
    public partial class Index : Form
    {
        private RedSocial miRed;

        private Usuario usuario;
        public Index(RedSocial miRed, Usuario usuario)
        {
            this.miRed = miRed;
            this.usuario = usuario;
            InitializeComponent();

        }

        private void index_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            Dispose();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form perfil = new Perfil(this.miRed);
            this.Hide();
            perfil.ShowDialog();
            this.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (miRed.usuarioActual != null) {

                string contenido;

                contenido = textBox1.Text;

                Console.WriteLine(contenido);

                miRed.Postear(miRed.usuarioActual.ID, contenido);

                textBox4.Text = contenido;
                textBox1.Text = "";


            }




        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
    

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            if (miRed.usuarioActual != null)
            {
                string contenido;

                contenido = textBox4.Text;

                Console.WriteLine(contenido);

                miRed.modificarPost(miRed.posts.,miRed.usuarioActual.ID,contenido,now);

                textBox4.Text = contenido;
                textBox1.Text = "";
            }



            }
    }
}
