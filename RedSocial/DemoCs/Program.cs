using EntidadesCs;

namespace DemoCs
{
	internal class Program
	{
		static void Main(string[] args)
		{
			// Crear usuarios
			Usuario usuario1 = new Usuario("Alice", new DateTime(1990, 5, 20), "Ciudad A");
			Usuario usuario2 = new Usuario("Bobi", new DateTime(1985, 11, 15), "Ciudad B");
			Usuario usuario3 = new Usuario("Charlie", new DateTime(1992, 8, 10));
			Usuario usuario4 = new Usuario("Diana", new DateTime(1998, 2, 25));

			// Crear publicaciones
			Publicacion publicacion1 = new Publicacion(DateTime.Now, "Hola desde Ciudad A", usuario1);
			Publicacion publicacion2 = new Publicacion(DateTime.Now.AddHours(-1), "¡Qué buen día!", usuario2);
			Publicacion publicacion3 = new Publicacion(DateTime.Now.AddHours(-2), "Sin imágenes por ahora", usuario3);
			try
			{
				new Publicacion(DateTime.Now, "", null);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			Imagen imagen1 = new Imagen(DateTime.Now.AddMinutes(-20), "Paisaje", usuario1);
			imagen1.SubirImagen("paisaje.jpg");

			Imagen imagen2 = new Imagen(DateTime.Now.AddMinutes(-10), "Selfie", usuario2);
			imagen2.SubirImagen("selfie.png");

			Imagen imagen3 = new Imagen(DateTime.Now.AddMinutes(-5), "Atardecer", usuario2);
			imagen3.SubirImagen("atardecer.jpeg");

			Console.WriteLine(publicacion1);
			Console.WriteLine(imagen1);

			// Agregar usuarios a la clase controladora
			RedSocial.AddUsuario(usuario1);
			RedSocial.AddUsuario(usuario2);
			RedSocial.AddUsuario(usuario3);
			RedSocial.AddUsuario(usuario4);
			try
			{
				RedSocial.AddUsuario(null);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			try
			{
				RedSocial.AddUsuario(usuario3);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}

			MostrarPublicaciones();

			try
			{
				usuario4.BorrarPublicacion(publicacion3);
			}
			catch (Exception e)
			{
                Console.WriteLine(e.Message );
			}
			usuario3.BorrarPublicacion(publicacion3);
			MostrarPublicaciones();

			try
			{
				usuario1.Seguir(usuario1);
			}
			catch (Exception e)
			{
                Console.WriteLine(e.Message);
            }
			// Configurar seguidores
			usuario1.Seguir(usuario2);
			usuario1.Seguir(usuario3);
			usuario1.Seguir(usuario4);
			usuario2.Seguir(usuario1);
			usuario3.Seguir(usuario1);
			usuario3.Seguir(usuario4);
			usuario4.Seguir(usuario2);
			usuario4.Seguir(usuario3);

			MostrarSeguimientos();

			try
			{
				usuario4.StopSeguir(usuario1);
			}
			catch (Exception e)
			{
                Console.WriteLine(e.Message);
			}
			usuario4.StopSeguir(usuario3);
			MostrarSeguimientos();

			usuario1.MeGusta(publicacion2);
			usuario1.MeGusta(imagen3);
			usuario4.MeGusta(imagen3);

            Console.WriteLine("Gustados de " + usuario1);
            foreach (var publicacion in usuario1.GetGustados())
			{
                Console.WriteLine(publicacion);
            }
            Console.WriteLine("Gustaron de " + imagen3);
            foreach (var usuario in imagen3.GetGustaron())
			{
                Console.WriteLine(usuario);
            }
		}

		private static void MostrarPublicaciones()
		{
			// mostrar los usuario de la clase controladora
			Console.WriteLine("Lista de usuarios: ");
			foreach (var usuario in RedSocial.GetUsuarios())
			{
				Console.WriteLine("Publicaciones de " + usuario + ": ");
				foreach (var publicacion in usuario.GetPublicaciones())
				{
					Console.WriteLine(publicacion);
				}
			}
		}
		private static void MostrarSeguimientos()
		{
			// mostrar los usuario de la clase controladora
			Console.WriteLine("Lista de usuarios: ");
			foreach (var usuario in RedSocial.GetUsuarios())
			{
				Console.WriteLine("Seguimientos de " + usuario + ": ");
                Console.WriteLine("Seguidos: ");
                foreach (var seguido in usuario.GetSeguidos())
				{
                    Console.WriteLine(seguido);
                }
                Console.WriteLine("Seguidores: ");
                foreach (var seguidores in usuario.GetSeguidores())
				{
                    Console.WriteLine(seguidores);
                }
			}
		}
	}
}
