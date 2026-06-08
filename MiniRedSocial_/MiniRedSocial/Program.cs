using MiniRedSocial;

namespace MiniRedSocial
{
    internal class Program
    {
        static Persona[] lista = new Persona[100];
        static int cant = 0;

        static GrafoNPND redSocial = new GrafoNPND(100);

        static void Main(string[] args)
        {
            int op;

            do
            {
                Console.WriteLine("\n=====MINI RED SOCIAL=====");
                Console.WriteLine("1. Agregar Persona");
                Console.WriteLine("2. Conecta Personas");
                Console.WriteLine("3. ¿Son amigos?");
                Console.WriteLine("4. Salir");

                Console.Write("Digite el # de opción: ");
                op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1: AgregarPersona(); break;
                    case 2: ConectaPersonas(); break;
                    case 3: VerificarAmistad(); break;
                }
            } while (op != 4);
        }

        static void AgregarPersona()
        {
            Persona p = new Persona();

            Console.Write("Nombre: ");
            p.Nombre = Console.ReadLine();

            Console.Write("Género: ");
            p.Genero = Console.ReadLine();

            Console.Write("Edad: ");
            p.Edad = int.Parse(Console.ReadLine());

            lista[cant] = p;
            cant++;

            Console.WriteLine("\n---PERSONA REGISTRADA---");
            Console.WriteLine($"Nombre: {p.Nombre}");
            Console.WriteLine($"Género: {p.Genero}");
            Console.WriteLine($"Edad: {p.Edad} años");
        }

        static int Buscar(string nombre)
        {
            for (int i = 0; i < cant; i++)
            {
                if (lista[i].Nombre == nombre)
                    return i;
            }
            return -1;
        }

        static void ConectaPersonas()
        {
            Console.Write("Persona 1: ");
            string p1 = Console.ReadLine();

            Console.Write("Persona 2: ");
            string p2 = Console.ReadLine();

            int i = Buscar(p1);
            int j = Buscar(p2);

            if (i == -1 || j == -1)
            {
                Console.WriteLine("Persona no encontrada");
                return;
            }

            redSocial.Conectar(i, j);

            Console.WriteLine("Conexión creada");
        }

        static void VerificarAmistad()
        {
            Console.Write("Persona 1: ");
            string p1 = Console.ReadLine();

            Console.Write("Persona 2: ");
            string p2 = Console.ReadLine();

            int i = Buscar(p1);
            int j = Buscar(p2);

            if (i == -1 || j == -1)
            {
                Console.WriteLine("Persona no encontrada");
                return;
            }

            if (redSocial.SonAmigos(i, j, cant))
                Console.WriteLine("Sí están relacionados");
            else
                Console.WriteLine("No están relacionados");
        }
    }
}