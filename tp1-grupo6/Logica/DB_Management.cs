using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace tp1_grupo6.Logica
{
    internal class DB_Management
    {
        private string connectionString;
        public DB_Management()
        {

            //Cargo la cadena de conexión desde el archivo de properties
            connectionString = Properties.Resources.connectionString;
        }

        //genero mi persistencia de usuarios en memoria
        public List<Usuario> inicializarUsuarios()
        {
            List<Usuario> misUsuarios = new List<Usuario>();

            //Defino el string con la consulta que quiero realizar
            string querySelectUsuarios = "SELECT * from dbo.Usuario";

            // Creo una conexión SQL con un Using, de modo que al finalizar, la conexión se cierra y se liberan recursos
            using (SqlConnection connectionDB =
                new SqlConnection(connectionString))
            {

                // Defino el comando a enviar al motor SQL con la consulta y la conexión
                SqlCommand command = new SqlCommand(querySelectUsuarios, connectionDB);

                try
                {
                    //Abro la conexión
                    connectionDB.Open();

                    //mi objeto DataReader va a obtener los resultados de la consulta, notar que a comando se le pide ExecuteReader()
                    SqlDataReader reader = command.ExecuteReader();
                    Usuario aux;


                    //mientras haya registros/filas en mi DataReader, sigo leyendo
                    while (reader.Read())
                    {
                        aux = new Usuario(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetBoolean(5), reader.GetBoolean(6));
                        misUsuarios.Add(aux);
                    }
                    //En este punto ya recorrí todas las filas del resultado de la query
                    reader.Close();



                    //YA cargué todos los usuarios, sólo me resta vincular
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return misUsuarios;
        }

        public List<Comentario> inicializarComentario()
        {
            List<Comentario> misComentarios = new List<Comentario>();


            string querySelectComentarios = "SELECT * from dbo.Comentario";

            using (SqlConnection connectionDB =
                new SqlConnection(connectionString))
            {
               
                SqlCommand command = new SqlCommand(querySelectComentarios, connectionDB);

                try
                {
                    
                    connectionDB.Open();

                   
                    SqlDataReader reader = command.ExecuteReader();
                    Comentario auxC;


                  
                    while (reader.Read())
                    {
                        // revisar como agregar un usuario ya que tenemos lista de usuario , como linkear eso
                        auxC = new Comentario(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetString(3), reader.GetString(4)) ;
                        misComentarios.Add(auxC);

                    }
                    
                    reader.Close();



                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return misComentarios;
        }

        public List<Post> inicializarPost()
        {
            List<Post> misPost = new List<Post>();


            string querySelectPost = "SELECT * from dbo.Post";

            using (SqlConnection connectionDB =
                new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(querySelectPost, connectionDB);

                try
                {

                    connectionDB.Open();


                    SqlDataReader reader = command.ExecuteReader();
                    Post auxP;



                    while (reader.Read())
                    {
                        // revisar como agregar un usuario ya que tenemos lista de usuario , como linkear eso
                        auxP = new Post(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetString(3), reader.GetString(4));
                        misPost.Add(auxP);

                    }

                    reader.Close();



                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return misPost;
        }











        public List<Tag> inicializarTag()
        {
            List<Tag> misTag = new List<Tag>();


            string querySelectTag = "SELECT * from dbo.Tag";

            using (SqlConnection connectionDB =
                new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(querySelectTag, connectionDB);

                try
                {

                    connectionDB.Open();


                    SqlDataReader reader = command.ExecuteReader();
                    Tag auxTg;



                    while (reader.Read())
                    {

                        auxTg = new Tag(reader.GetInt32(0), reader.GetString(1));
                        misTag.Add(auxTg);

                    }

                    reader.Close();



                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return misTag;
        }

        public List<Reaccion> inicializarReaccion()
        {
            List<Reaccion> misReacciones = new List<Reaccion>();


            string querySelectReaccion = "SELECT * from dbo.Reaccion";

            using (SqlConnection connectionDB =
                new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(querySelectReaccion, connectionDB);

                try
                {

                    connectionDB.Open();


                    SqlDataReader reader = command.ExecuteReader();
                    Reaccion auxReac;



                    while (reader.Read())
                    {

                        auxReac = new Reaccion(reader.GetInt32(0), reader.GetChar(1), reader.GetInt32(2), reader.GetInt32(3));
                        misReacciones.Add(auxReac);

                    }

                    reader.Close();



                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return misReacciones;
        }




    }
}
