namespace EntidadesCs
{
	public class RedSocial
	{
		private static List<Usuario> usuarios = new List<Usuario>();
		public static void AddUsuario(Usuario usuario)
		{
			if (usuario == null)
				throw new ArgumentException("Debe especificar un usuario");
			if (usuarios.Contains(usuario))
				throw new ArgumentException($"{usuario.Nombre} ya fue agregado");
			usuarios.Add(usuario);
		}
		public static void RemoveUsuario(Usuario usuario)
		{
			if (usuario == null)
				throw new ArgumentException("Debe especificar un usuario");
			if (!usuarios.Contains(usuario))
				throw new ArgumentException("Usuario no fue agregado");
			usuarios.Remove(usuario);
		}
		public static List<Usuario> GetUsuarios()
		{
			return usuarios;
		}
	}
}
