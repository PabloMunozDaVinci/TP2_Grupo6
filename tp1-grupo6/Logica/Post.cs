using System;
using System.Collections.Generic;
using System.Text;


namespace tp1_grupo6.Logica
{

	public class Post
	{

		public int ID { get; set; }
		public int usuarioID { get; set; }
	    public string Contenido { get; set; }
		public List<Comentario> misComentarios { get; set; }
		public List<Reaccion> misReacciones { get; set; }
		public List<Tag> misTags { get; set; }
		public DateTime Fecha { get; set; }

		/* Creeriamos no es necesario
		public Post(int ID, int usuarioID,  string Contenido, DateTime fecha)
		{
			this.ID = ID;
			this.usuarioID = usuarioID;
			this.Contenido = Contenido;
			this.Fecha = fecha;
		}*/

		//Constructor para traer datos de la DB con todos los datos
		public Post(int ID,int usuarioID, string Contenido, DateTime fecha)
		{
			this.ID = ID;
			this.usuarioID = usuarioID;
			this.Contenido = Contenido;
			this.Fecha = fecha;
			misComentarios = new List<Comentario>();
			misReacciones = new List<Reaccion>();
			misTags = new List<Tag>(); 
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

		public void agregarTag(Tag tag)
		{
			misTags.Add(tag);
		}
		public void quitarTag(Tag tag)
		{
			misTags.Remove(tag);
		}

	}
}
