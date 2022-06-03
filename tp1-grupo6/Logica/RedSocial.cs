﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasyEncryption;
using System.Data.SqlClient;

namespace tp1_grupo6.Logica
{
    public class RedSocial
    {
        public int idNuevoPost { get; set; }
    private List<Usuario> usuarios;
        private List<Post> posts;
        private List<Tag> tags;
        public Usuario usuarioActual { get; set; }
        public IDictionary<string, int> loginHistory;
        private const int cantMaxIntentos = 3;
        private DB_Management DB;

        public RedSocial()
        {
            usuarios = new List<Usuario>();
            posts = new List<Post>();
            tags = new List<Tag>();
            this.usuarioActual = usuarioActual;
            this.loginHistory = new Dictionary<string, int>();
            DB = new DB_Management();
            inicializarAtributos();
        }

        //Inicializo mis listas con los datos de la DB
        private void inicializarAtributos()
        {
            usuarios = DB.inicializarUsuarios();
            posts = DB.inicializarPost();
        }

        //Metodo para hacer el hashing de la contraseña
        private string Hashear(string contraseñaSinHashear)
        {
            try
            {
                string passwordHash = SHA.ComputeSHA256Hash(contraseñaSinHashear);
                return passwordHash;
            }
            catch (Exception)
            {
                return "error";
            }
        }

        //Metodo para cargar los intentos fallidos de login de un usuario
        public string Intentos(string usuarioIngresado)
        {
            string mensaje = null;
            if (loginHistory.TryGetValue(usuarioIngresado, out int value))
            {
                loginHistory[usuarioIngresado] = loginHistory[usuarioIngresado] + 1;
                mensaje = "Datos incorrectos, intento " + loginHistory[usuarioIngresado] + "/3";
                if (loginHistory[usuarioIngresado] == cantMaxIntentos)
                {
                    this.bloquearDesbloquearUsuario(usuarioIngresado, true);
                    mensaje = "Intento 3/3, usuario bloqueado.";
                }
            }
            else
            {
                mensaje = "Datos incorrectos, intento 1/3";
                loginHistory.Add(usuarioIngresado, 1);
            }
            return mensaje;
        }

        //Metodo para validar si esta bloqueado el usuario
        public bool EstaBloqueado(string Mail)
        {
            return DevolverUsuario(Mail).Bloqueado;
        }

        //Modifica el usuario en la BD y en la lista de usuarios
        public bool ModificarUsuario(int UsuarioID, string Nombre, string Apellido, string Mail, string Password)
        {
            //primero me aseguro que lo pueda agregar a la base
            if (DB.modificarUsuario(UsuarioID, Nombre, Apellido, Mail, Password) == 1)
            {
                try
                {
                    //Ahora sí lo MODIFICO en la lista
                    for (int i = 0; i <= usuarios.Count - 1; i++)
                        if (usuarios[i].ID == UsuarioID)
                        {
                            usuarios[i].Nombre = Nombre;
                            usuarios[i].Apellido = Apellido;
                            usuarios[i].Mail = Mail;
                            usuarios[i].Password = Password;
                        }
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                //algo salió mal con la query porque no generó 1 registro
                return false;
            }
        }

        //Elimina el usuario de la BD y de la lista
        public bool EliminarUsuario(int id)
        {
            //primero me aseguro que lo pueda agregar a la base
            if (DB.eliminarUsuario(id) == 1)
            {
                try
                {
                    //Ahora sí lo elimino en la lista
                    for (int i = 0; i < usuarios.Count; i++)
                        if (usuarios[i].ID == id)
                            usuarios.RemoveAt(i);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                //algo salió mal con la query porque no generó 1 registro
                return false;
            }
        }

        //Devuelve el Usuario correspondiente al Mail recibido.
        private Usuario DevolverUsuario(string Mail)
        {
            Usuario usuarioEncontrado = null;

            for (int i = 0; i <= usuarios.Count -1; i++)
            {
                if (usuarios[i].Mail == Mail)
                {
                    usuarioEncontrado = usuarios[i];
                    Console.WriteLine(usuarioEncontrado);
                }
            }
            return usuarioEncontrado;
        }

        //Metodo para crear el usuario y persistirlo en la BD y agregarlo a la lista de usuarios
        public bool RegistrarUsuario(int DNI, string Nombre, string Apellido, string Mail, string Password, bool EsADMIN, bool Bloqueado)
        {
            if (!ExisteUsuario(Mail))
            {
    
                    int idNuevoUsuario;
                    idNuevoUsuario = DB.agregarUsuario(DNI, Nombre, Apellido, Mail, Password, EsADMIN, Bloqueado);
                    if (idNuevoUsuario != -1)
                    {
                        //Ahora sí lo agrego en la lista
                        Usuario nuevo = new Usuario(idNuevoUsuario, DNI, Nombre, Apellido, Mail, this.Hashear(Password), EsADMIN, Bloqueado);
                        usuarios.Add(nuevo);
                        return true;
                    }
                    else
                    {
                        //algo salió mal con la query porque no generó un id válido
                        return false;
                    }
                
            }
            return false;
        }


        // Se autentica al Usuario.
        public bool IniciarUsuario(string Mail, string Password)
        {
            bool ok = false;
            Usuario usuario = this.DevolverUsuario(Mail);
            if (usuario.Password == Password)
            {
                usuarioActual = usuario;
                ok = true;
            }
            return ok;
        }
        // Se valida si el usuario existe y devuelve true o false
        public bool ExisteUsuario(string Mail)
        {
            if (DevolverUsuario(Mail) != null)
            {
                return true;
            }
            return false;
        }
        // se obtiene el ID del usuario
        public int obtenerUsuarioId(string Mail)
        {
            foreach (Usuario u in usuarios)
            {
                if (u.Mail == Mail)
                {
                    return u.ID;
                }
            }
            return 0;
        }

        // Bloquea/Desbloquea el Usuario que se corresponde con el DNI recibido.
        public bool bloquearDesbloquearUsuario(string Mail, bool Bloqueado)
        {
            bool todoOk = false;
            foreach (Usuario u in usuarios)
            {
                if (u.Mail == Mail)
                {
                    u.Bloqueado = Bloqueado;
                    todoOk = true;
                }
            }
            return todoOk;
        }
        
        //seteo el usuario actual en null para cerrar la sesion
        public bool CerrarSesion()
        {
            //Pregunto si existe usuario Actual
            if (usuarioActual != null)
            {
                //seteo el usuario actual a null
                usuarioActual = null;
            }
            return true;
        }



        /* no se si funciona
        public void AgregarAmigo(Usuario amigo)
        {
            if (usuarioActual != null)
            {

                usuarioActual.Amigos.Add(amigo);

            }

        }*/









        /* no funciona
        public void QuitarAmigo(Usuario exAmigo)
        {
            if (usuarioActual != null)
            {
                //usuarioActual.Amigos.Remove(amigo);
                exAmigo.Amigos.Remove(usuarioActual);
            }
        }*/







        public string Postear(int ID, string contenido)
         {
            DateTime now = DateTime.Now;

            if (usuarioActual != null )
            {
                int idNuevoPost;
                idNuevoPost = DB.agregarPost( usuarioActual.ID,  contenido );
                if (idNuevoPost != -1)
                {
                    //Ahora sí lo agrego en la lista
                    Post nuevoPost = new Post(idNuevoPost, usuarioActual.ID, contenido, now);
                    posts.Add(nuevoPost);
                    usuarioActual.misPosts.Add(nuevoPost);
                   this.idNuevoPost = idNuevoPost;
                }
                else
                {
                    //algo salió mal con la query porque no generó un id válido
                    Console.WriteLine("error en query");
                }

            }
             return contenido;
        }
        // no funciona
        public int obtenerPostID(int usuarioID)
        {
            foreach (Post p in posts)
            {
                if (p.ID == usuarioActual.misPosts.Count)
                {
                    return 8;
                }
            }
            return 0;
        }

        public bool modificarPost(int ID, int usuarioID, string newContenido, DateTime newFecha)
        {


            if (DB.modificarPost(ID, usuarioID, newContenido, newFecha) == 1)
            {
                try
                {
                    //Ahora sí lo MODIFICO en la lista
                    for (int i = 0; i <= usuarios.Count - 1; i++)
                        if (posts[i].ID == ID)
                        {
                            posts[i].Contenido = newContenido;
                            posts[i].Fecha = newFecha;
                        }
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                //algo salió mal con la query porque no generó 1 registro
                return false;
            }

        }

        public bool eliminarPost(int Id)
        {
            //primero me aseguro que lo pueda agregar a la base
            if (DB.eliminarPost(Id) == 1)
            {
                try
                {
                    //Ahora sí lo elimino en la lista
                    for (int i = 0; i < posts.Count; i++)
                    {
                        if (posts[i].ID == Id)
                            posts.RemoveAt(i);
                    }

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                //algo salió mal con la query porque no generó 1 registro
                return false;
            }
        }

        // no se si funcionan
        /*
        public void Postear(Post p, List<Tag> t)
        {
            bool encontre = false;

            posts.Add(p);
            usuarioActual.MisPosts.Add(p);
            foreach (Tag tagP in t)
            {
                encontre = false;

                foreach (Tag tag in tags)
                {
                    if (tag == tagP)
                    {
                        encontre = true;
                    }
                }

                if (encontre == false)
                {
                    tags.Add(tagP);
                }

                tagP.Posts.Add(p);
                p.Tags.Add(tagP);

            }
        }

        */















        /* no funciona
        public void ModificarPost(int pID, Usuario pUsuario, string pContenido, List<Comentario> pComentarios, List<Reaccion> pReacciones, List<Tag> pTags, DateTime pFecha)
        {
            foreach (Post post in posts)
            {
                if (post.ID == pID)
                {
                    //post.Usuario = pUsuario;
                    post.Contenido = pContenido;
                    post.Comentarios = pComentarios;
                    post.Reacciones = pReacciones;
                    post.Tags = pTags;
                    //post.Fecha = pFecha;

                }
            }
        }*/










        // no hecho
        public void EliminarPost(Post p)
        {

        }














        /* no funciona
        public void Comentar(Post p, Comentario c)
        {
            //pregunto si el conteo de post es mayor a 0 para determinar si existen posts
            if (posts.Count > 0)
            {
                bool encontre = false;
                //registro el ID del post a guardar
                int id = 0;
                id = p.ID;
                foreach (Post postAux in posts)
                {
                    if (postAux.ID == id)
                    {
                        encontre = true;
                        //Agrego al Post actual el comentario
                        postAux.Comentarios.Add(c);
                        //al usuario actual le agrego a su lista el comentario que realizó
                        usuarioActual.MisComentarios.Add(c);
                        //si realiza mas comentarios deben tener ID  diferente
                        //usuarioActual.MisComentarios.
                    }
                }
            }
        }*/

















        /*
        public void ModificarComentario(Post p, Comentario c)
        {
            if (posts.Count > 0)
            {
                bool encontre = false;
                //registro el ID del post a guardar
                int id = 0;
                id = p.ID;
                foreach (Post postAux in posts)
                {
                    if (postAux.ID == id)
                    {
                        encontre = true;
                        //remuevo el ultimo comentario dentro del pool de comentarios del usuario actual
                        //usuarioActual.MisComentarios.Remove(usuarioActual.MisComentarios.Last());
                        //remuevo el ultimo Post dentro del pool de Posts 
                        //postAux.Comentarios.Remove(postAux.Comentarios.Last());
                        //al usuario actual le agrego a su lista el comentario que realizó
                        postAux.Comentarios.Add(c);
                    }
                }
            }
        }*/




















        public void QuitarComentario(Post p, Comentario c)
        {
            {
                if (posts.Count > 0)
                {

                    bool encontre = false;


                    //registro el ID del post a guardar
                    int id = 0;

                    id = p.ID;



                    foreach (Post postAux in posts)
                    {

                        if (postAux.ID == id)
                        {
                            encontre = true;


                            //remuevo el ultimo Post dentro del pool de Posts 
                            // postAux.Comentarios.Remove(postAux.Comentarios.Last());
                        }

                    }
                }
            }
        }















        public void Reaccionar(Post p, Reaccion r)
        {

        }

        public void ModificarReaccion(Post p, Reaccion r)
        {

        }

        public void QuitarReaccion(Post p, Reaccion r)
        {

        }

        public void MostrarDatos()
        {

        }

        public void MostrarPosts()
        {

        }

        public void MostrarPostsAmigos()
        {

        }

        public void BuscarPosts(string Contenido, DateTime Fecha, Tag t)
        {

        }

    }
}
