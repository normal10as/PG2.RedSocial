using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCs
{
	public class Usuario
	{
		private List<Publicacion> publicaciones;
		private List<Usuario> seguidores;
		private List<Usuario> seguidos;
		private List<Publicacion> gustados;

		public string Nombre { get; set; }
		public DateTime Nacimiento { get; set; }
		public string Ubicacion { get; set; }

		public Usuario(string nombre, DateTime nacimiento)
		{
			publicaciones = new List<Publicacion>();
			seguidores = new List<Usuario>();
			seguidos = new List<Usuario>();
			gustados = new List<Publicacion>();
			Nombre = nombre;
			Nacimiento = nacimiento;
		}

		public Usuario(string nombre, DateTime nacimiento, string ubicacion) : this(nombre, nacimiento)
		{
			Ubicacion = ubicacion;
		}
		internal void Publicar(Publicacion publicacion)
		{
			if (publicacion == null)
				throw new ArgumentNullException("Publicacion no puede ser nula");
			publicaciones.Add(publicacion);
		}
		public List<Publicacion> GetPublicaciones()
		{
			return publicaciones;
		}
		public void BorrarPublicacion(Publicacion publicacion)
		{
			if (!publicaciones.Contains(publicacion))
				throw new ArgumentException("Publicación no existe");
			publicaciones.Remove(publicacion);
		}

		public void Seguir(Usuario usuario)
		{
			if (usuario == null) 
				throw new ArgumentNullException("Usuario no puede ser nulo");
			if (usuario == this)
				throw new ArgumentException("Usuario no se puede seguir a si mismo");
			usuario.AddSeguidor(this);
			seguidos.Add(usuario);
		}
		public List<Usuario> GetSeguidos()
		{
			return seguidos;
		}
		public void StopSeguir(Usuario usuario)
		{
			if (usuario == null) 
				throw new ArgumentNullException("Usuario no puede ser nulo");
			if (!seguidos.Contains(usuario))
				throw new ArgumentException($"{usuario} no esta siendo seguido");
			usuario.StopSeguidor(this);
			seguidos.Remove(usuario);
		}
		private void AddSeguidor(Usuario usuario)
		{
			seguidores.Add(usuario);
		}
		public List<Usuario> GetSeguidores()
		{
			return seguidores;
		}
		private void StopSeguidor(Usuario usuario)
		{
			seguidores.Remove(usuario);
		}

		public bool MeGusta(Publicacion publicacion)
		{
			if (publicacion == null)
				throw new ArgumentNullException("Publicación no puede ser nula");

			if (gustados.Contains(publicacion))
			{
				publicacion.StopGusto(this);
				gustados.Remove(publicacion);
				return false;
			}
			else
			{
				publicacion.Gusto(this);
				gustados.Add(publicacion);
				return true;
			}
		}
		public List<Publicacion> GetGustados()
		{
			return gustados;
		}
		public override string ToString()
		{
			return Nombre + (String.IsNullOrEmpty(Ubicacion) ? "" : " de "+ Ubicacion);
		}
	}
}
