using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCs
{
	public class Imagen : Publicacion
	{
		public string File { get; private set; }
		public Imagen(DateTime fechaHora, string Texto, Usuario usuario) : base(fechaHora, Texto, usuario) { 
		}

		public bool SubirImagen(string fileName)
		{
			if (string.IsNullOrEmpty(fileName)) 
				throw new ArgumentNullException("No se especifico el nombre de archivo");
			File = fileName;
			return true;
		}
		public override string ToString()
		{
			return base.ToString() + $" <{File}>";
		}
	}
}
