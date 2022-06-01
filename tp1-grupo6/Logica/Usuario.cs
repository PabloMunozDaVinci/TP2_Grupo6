using System;
using System.Collections.Generic;
using System.Text;

namespace tp1_grupo6.Logica
{
     public class Usuario
    {
        public int ID { get;}
        public int DNI { get; set; }
        public string Nombre{ get; set; }
        public string Apellido  { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public bool Bloqueado { get; set; }
        public bool EsAdmin { get; set; }
        public List<Usuario> Amigos { get; set; }
        public List <Post> MisPosts { get; set; }
        public List<Comentario> MisComentarios { get; set; }
        public List<Reaccion> MisReacciones { get; set; }
        
        //Constructor logico para registrar un usuario
        public Usuario(int DNI, string Nombre, string Apellido, string Mail, string Password)
        {            
            this.DNI = DNI;
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.Mail = Mail;
            this.Password = Password;
            Bloqueado = false;
            EsAdmin = false;            
            Amigos = new List<Usuario>();
            MisPosts = new List<Post>();
            MisComentarios = new List<Comentario>();
            MisReacciones = new List<Reaccion>();
        }
        //Constructor para traer datos de la DB con todos los datos
        public Usuario(int ID,int DNI, string Nombre, string Apellido, string Mail, string Password, bool Bloqueado, bool EsAdmin)
        {
            this.ID = ID;
            this.DNI = DNI;
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.Mail = Mail;
            this.Password = Password;
            this.Bloqueado = Bloqueado;
            this.EsAdmin = EsAdmin;            
            Amigos = new List<Usuario>();
            MisPosts = new List<Post>();
            MisComentarios = new List<Comentario>();
            MisReacciones = new List<Reaccion>();
        }
    }
}
