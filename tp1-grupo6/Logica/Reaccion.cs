using System;
using System.Collections.Generic;
using System.Text;

namespace tp1_grupo6.Logica
{
    public class Reaccion
    {
        public int ID { get; set; }
        public char Tipo { get; set; }
        public int postID { get; set; }
        public int UsuarioID { get; set; }
        public Post Post { get; set; }
        public Usuario Usuario { get; set; }


        public Reaccion() { }



        public Reaccion(int ID, char Tipo,int postID,int UsuarioID) {
           
            this.ID = ID;
            this.Tipo = Tipo;
            this.postID = postID;
            this.UsuarioID = UsuarioID;
        
        }

        public Reaccion(int ID, char Tipo, Post Post, Usuario Usuario)
        {
            this.ID = ID;
            this.Tipo = Tipo;
            this.Post = Post;
            this.Usuario = Usuario;
        }
    }
}
