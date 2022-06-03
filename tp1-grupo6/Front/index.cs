﻿using System;
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

        public Index(RedSocial miRed)
        {
            this.miRed = miRed;
            InitializeComponent();
            //textBox5.Text = miRed.usuarioActual.Nombre;
            label1.Text = miRed.usuarioActual.Nombre;

        }

        private void index_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            miRed.CerrarSesion();
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

                miRed.Postear(miRed.usuarioActual.ID, contenido);

                textBox4.Text = contenido;
            }




        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
    

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            if (miRed.usuarioActual != null)
            {
                string contenido;
                contenido = textBox4.Text;
                if (miRed.modificarPost(miRed.ObtenerPostID(), miRed.usuarioActual.ID, contenido, now))
                {
                    MessageBox.Show("Modificado con éxito");
                }
                else
                {
                    MessageBox.Show("No se pudo modificar el post");
                }
                textBox4.Text = contenido;
                textBox1.Text = "";
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (miRed.eliminarPost(miRed.ObtenerPostID()))
            {
                MessageBox.Show("Modificado con éxito");

            }
            else
            {
                MessageBox.Show("No se pudo eliminar el post");
            }
            textBox4.Text = "";
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button14_Click_1(object sender, EventArgs e)
        {



            if (miRed.usuarioActual != null)
            {

                string contenido;

                contenido = textBox6.Text;


                miRed.Comentar(miRed.ObtenerPostID(), miRed.usuarioActual.ID, contenido);

                    
                textBox5.Text = contenido;

                textBox6.Text = "";


            }


        }

        private void button11_Click(object sender, EventArgs e)
        {

            DateTime now = DateTime.Now;
            if (miRed.usuarioActual != null)
            {
                string contenido;
                contenido = textBox6.Text;
                if (miRed.ModificarComentario(miRed.ObtenerComentarioID(), miRed.usuarioActual.ID, miRed.ObtenerPostID(),contenido, now))
                {
                    MessageBox.Show("Modificado con éxito");
                }
                else
                {
                    MessageBox.Show("No se pudo modificar el comentario");
                }
                textBox5.Text = contenido;
                textBox6.Text = "";
            }



        }
    }
}
