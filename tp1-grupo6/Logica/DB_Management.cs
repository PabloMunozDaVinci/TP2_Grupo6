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
                        aux = new Usuario(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetBoolean(6), reader.GetBoolean(7));
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
        //------------------Termina querys de SELECT---------------------------------------------------------//


        //------------------Inicia querys de insert---------------------------------------------------------//
        //devuelve el ID del usuario agregado a la base, si algo falla devuelve -1
        public int agregarUsuario(int Dni, string Nombre, string Apellido, string Mail, string Password, bool EsADMIN ,bool Bloqueado)
        {
            //primero me aseguro que lo pueda agregar a la base
            int resultadoQuery;
            int idNuevoUsuario = -1;
            string connectionString = Properties.Resources.connectionString;
            string queryInsertUsuarios = "INSERT INTO [dbo].[Usuario] ([DNI],[Nombre],[Apellido],[Mail],[Password],[EsADMIN],[Bloqueado]) VALUES (@dni,@nombre,@apellido,@mail,@password,@esadmin,@bloqueado);";
            using (SqlConnection connectionDB =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryInsertUsuarios, connectionDB);

                command.Parameters.Add(new SqlParameter("@DNI", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar));
                command.Parameters.Add(new SqlParameter("@Apellido", SqlDbType.VarChar));
                command.Parameters.Add(new SqlParameter("@Mail", SqlDbType.VarChar));
                command.Parameters.Add(new SqlParameter("@Password", SqlDbType.VarChar));
                command.Parameters.Add(new SqlParameter("@esADMIN", SqlDbType.Bit));
                command.Parameters.Add(new SqlParameter("@Bloqueado", SqlDbType.Bit));
                command.Parameters["@dni"].Value = Dni;
                command.Parameters["@nombre"].Value = Nombre;
                command.Parameters["@apellido"].Value = Apellido;
                command.Parameters["@mail"].Value = Mail;
                command.Parameters["@password"].Value = Password;
                command.Parameters["@esadmin"].Value = EsADMIN;
                command.Parameters["@bloqueado"].Value = Bloqueado;
                try
                {
                    connectionDB.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    resultadoQuery = command.ExecuteNonQuery();

                    //*******************************************
                    //Ahora hago esta query para obtener el ID
                    string ConsultaID = "SELECT MAX([ID]) FROM [dbo].[Usuario]";
                    command = new SqlCommand(ConsultaID, connectionDB);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    idNuevoUsuario = reader.GetInt32(0);
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return -1;
                }
                return idNuevoUsuario;
            }
        }










        //------------------Termina querys de insert---------------------------------------------------------//



        //------------------inicia querys de DELETE---------------------------------------------------------//


        //devuelve la cantidad de elementos modificados en la base (debería ser 1 si anduvo bien)
        public int eliminarUsuario(int id)
        {
            string connectionString = Properties.Resources.connectionString;
            string queryDelete = "DELETE FROM [dbo].[Usuario] WHERE UsuarioID=@id";
            using (SqlConnection connectionDB =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryDelete, connectionDB);
                command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                command.Parameters["@id"].Value = id;
                try
                {
                    connectionDB.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }









        //------------------inicia querys de UPDATE---------------------------------------------------------//



        //devuelve la cantidad de elementos modificados en la base (debería ser 1 si anduvo bien)
        public int modificarUsuario(int Id, int Dni, string Nombre,string Apellido, string Mail, string Password, bool EsADMIN, bool Bloqueado)
        {
            string connectionString = Properties.Resources.connectionString;
            string queryUpdateUsuario = "UPDATE [dbo].[Usuario] SET Nombre=@nombre,Apellido=@apellido, Mail=@mail,Password=@password, EsADMIN=@esadm ,Bloqueado=@bloqueado WHERE ID=@id;";
            using (SqlConnection connectionDB =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryUpdateUsuario, connectionDB);
                command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@dni", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar));
                command.Parameters.Add(new SqlParameter("@apellido", SqlDbType.VarChar));
                command.Parameters.Add(new SqlParameter("@mail", SqlDbType.VarChar));
                command.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar));
                command.Parameters.Add(new SqlParameter("@esadm", SqlDbType.Bit));
                command.Parameters.Add(new SqlParameter("@bloqueado", SqlDbType.Bit));
                command.Parameters["@id"].Value = Id;
                command.Parameters["@dni"].Value = Dni;
                command.Parameters["@nombre"].Value = Nombre;
                command.Parameters["@apellido"].Value = Apellido;
                command.Parameters["@mail"].Value = Mail;
                command.Parameters["@password"].Value = Password;
                command.Parameters["@esadm"].Value = EsADMIN;
                command.Parameters["@bloqueado"].Value = Bloqueado;
                try
                {
                    connectionDB.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }

    }
}
