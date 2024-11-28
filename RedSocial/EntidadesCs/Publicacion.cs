using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCs
{
	public class Publicacion
	{
		private Usuario usuario;
		private List<Usuario> gustaron;
		public DateTime FechaHora { get; set; }
		public string Texto { get; set; }
		public Usuario Usuario
		{
			get => usuario; 
			private set
			{
				if (value == null)
					throw new ArgumentNullException("Usuario no puede ser nulo");
				value.Publicar(this);
				usuario = value;
			}
		}

		public Publicacion(DateTime fechaHora, string texto, Usuario usuario)
		{
			gustaron = new List<Usuario>();
			FechaHora = fechaHora;
			Texto = texto;
			Usuario = usuario;
		}

		internal void Gusto(Usuario usuario)
		{
			if (usuario == null) 
				throw new ArgumentNullException("Usuario no puede ser nulo");
			if (gustaron.Contains(usuario))
				throw new ArgumentException("Usuario ya gusto previamente");
			gustaron.Add(usuario);
		}
		internal void StopGusto(Usuario usuario)
		{
			if (usuario == null) 
				throw new ArgumentNullException("Usuario no puede ser nulo");
			if (!gustaron.Contains(usuario))
				throw new ArgumentException("Usuario no gusto previamente");
			gustaron.Remove(usuario);
		}
		public List<Usuario> GetGustaron()
		{
			return gustaron;
		}
		public override string ToString() {
			return FechaHora + " -> " + Texto;
		}

	}
}
