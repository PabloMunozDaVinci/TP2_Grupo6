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
        public List<Post> MisPost { get; set; }
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
            misAmigos = new List<Usuario>();
            misPost = new List<Post>();
            misComentarios = new List<Comentario>();
            misReacciones = new List<Reaccion>();
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
            misAmigos = new List<Usuario>();
            misPost = new List<Post>();
            misComentarios = new List<Comentario>();
            misReacciones = new List<Reaccion>();
        }

        public void agregarAmigos(Usuario usuario)
        {
            misAmigos.Add(post);
        }
        public void quitarDireccion(Post post)
        {
            misPosts.Remove(post);
        }

        public void agregarPosts(Post post)
        {
            misPost.Add(post);
        }
        public void quitarDireccion(Post post)
        {
            misPost.Remove(post);
        }

        public void agregarComentarios(Comentario comentario)
        {
            misComentarios.Add(comentario);
        }
        public void quitarComentario(Comentario comentario)
        {
            misComentarios.Remove(comentario);
        }

        public void agregarReaccion(Reaccion reaccion)
        {
            misReacciones.Add(reaccion);
        }
        public void quitarReaccion(Reaccion reaccion)
        {
            misReacciones.Remove(reaccion);
        }
    }
}
