using System;
using System.Collections.Generic;
using System.Text;

namespace tp1_grupo6.Logica
{
     public class Usuario
    {

        //testttt

        //test2 
        public int ID { get; set; }

        public int DNI { get; set; }

        public string Nombre{ get; set; }

        public string Apellido  { get; set; }
        public string Mail { get; set; }

        public string Password { get; set; }

        public int IntentosFallidos { get; set; }
        public bool Bloqueado { get; set; }
        public List<Usuario> Amigos { get; set; }
        public List <Post> MisPosts { get; set; }
        public List<Comentario> MisComentarios { get; set; }
        public List<Reaccion> MisReacciones { get; set; }

        public Usuario(){ }
        public Usuario (int DNI, string Nombre, string Apellido, string Mail, string Password)
        {
            this.DNI = DNI;
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.Mail=Mail;
            this.Password = Password;
            this.Bloqueado = false;

        }

        public override string ToString()
        {
            return ID + "," + DNI + "," + Nombre + "," + Mail + "," + Password + ","  + Bloqueado;

        }
    }
}
