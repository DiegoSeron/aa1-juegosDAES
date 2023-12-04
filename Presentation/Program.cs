// See https://aka.ms/new-console-template for more information

using Juegos.Business;
using Juegos.Data;
using Juegos.Models;
using Juegos.Presentation;

ClienteBusiness clienteBusiness = new ClienteBusiness();
JuegoBusiness juegoBusiness = new JuegoBusiness();

bool running = true;

while (running)
{
    Console.Clear();
    Console.WriteLine("¡Hola! ¿Qué eres?");
    Console.WriteLine("1. Admin");
    Console.WriteLine("2. Cliente");
    Console.WriteLine("3. Salir");
    Console.Write("Selecciona una opción: ");

    string opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            // Código para el Submenú 1
            bool submenu1 = true;
            while (submenu1)
            {
                Console.Clear();
                Console.WriteLine("Menú de Admin");
                Console.WriteLine("1. Crear Juego");
                Console.WriteLine("2. Ver todos los juegos");
                Console.WriteLine("3. Volver al menú principal");
                Console.Write("Selecciona una opción: ");
                string opcionAdmin = Console.ReadLine();

                switch (opcionAdmin)
                {
                    case "1":
                        // Lógica para crear un nuevo juego
                        Console.Write("Nombre del juego: ");
                        string nombreJuego = Console.ReadLine();
                        Console.Write("Categoría: ");
                        string categoria = Console.ReadLine();
                        Console.Write("Cantidad: ");
                        int cantidad = int.Parse(Console.ReadLine());
                        Console.Write("Precio: ");
                        decimal precio = decimal.Parse(Console.ReadLine());
                        Console.Write("Pegi: ");
                        int pegi = int.Parse(Console.ReadLine());
/*                         Console.Write("Fecha de lanzamiento (YYYY-MM-DD): ");
                        DateTime fechaLanzamiento = DateTime.Parse(Console.ReadLine()); */


                        // Crear un nuevo juego utilizando el negocio de juegos
                        juegoBusiness.CrearJuego(nombreJuego, categoria, cantidad, precio, pegi/* , fechaLanzamiento */);
                        Console.WriteLine("Nuevo juego creado exitosamente.");
                        break;
                    case "2":
                                    juegoBusiness.MostrarTodosLosJuegos();
                        break;
                    case "3":
                        submenu1 = false; // Volver al menú principal
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Introduce una opción válida.");
                        break;
                }

                Console.WriteLine("\nPresiona cualquier tecla para volver al menú de Admin...");
                Console.ReadKey();
            }
            break;
        case "2":
            bool loggedIn = false;
            while (!loggedIn)
            {
                Console.Clear();
                Console.WriteLine("Menú de Cliente");
                Console.WriteLine("1. Iniciar Sesión");
                Console.WriteLine("2. Registrarse");
                Console.WriteLine("3. Volver");
                Console.Write("Selecciona una opción: ");

                string opcionCliente = Console.ReadLine();

                switch (opcionCliente)
                {
                    case "1":
                        Console.Write("DNI: ");
                        string dni = Console.ReadLine();
                        Console.Write("Contraseña: ");
                        string contraseña = Console.ReadLine();

                        Clientes clienteLogueado = clienteBusiness.IniciarSesion(dni, contraseña);

                        if (clienteLogueado != null)
                        {
                            Console.WriteLine($"Inicio de sesión exitoso. Bienvenido, {clienteLogueado.Nombre}!");
                            loggedIn = true;
                        }
                        else
                        {
                            Console.WriteLine("Credenciales inválidas. Inténtalo de nuevo.");
                        }
                        break;
                    case "2":
                        Console.Write("Nombre: ");
                        string nombre = Console.ReadLine();
                        Console.Write("DNI: ");
                        string nuevoDni = Console.ReadLine();
                        Console.Write("Contraseña: ");
                        string nuevaContraseña = Console.ReadLine();

                        clienteBusiness.RegistrarCliente(nombre, nuevoDni, nuevaContraseña);
                        Console.WriteLine("Registro exitoso. Ahora puedes iniciar sesión.");
                        break;
                    case "3":
                        loggedIn = true; // Volver al menú principal
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Introduce una opción válida.");
                        break;
                }

                Console.WriteLine("\nPresiona cualquier tecla para continuar...");
                Console.ReadKey();
            }
            break;
        case "3":
            Console.WriteLine("Saliendo del programa...");
            running = false;
            break;
        default:
            Console.WriteLine("Opción inválida. Introduce una opción válida.");
            break;
    }

    Console.WriteLine("\nPresiona cualquier tecla para continuar...");
    Console.ReadKey();
}










/*  ClienteBusiness clienteBusiness = new ClienteBusiness();
    bool running = true;

    while (running)
    {
        Console.Clear();
        Console.WriteLine("Menú Cliente");
        Console.WriteLine("1. Iniciar Sesión");
        Console.WriteLine("2. Registrarse");
        Console.WriteLine("3. Salir");
        Console.Write("Selecciona una opción: ");

        string opcion = Console.ReadLine();

        switch (opcion)
        {
            case "1":
                Console.Write("DNI: ");
                string dni = Console.ReadLine();
                Console.Write("Contraseña: ");
                string contraseña = Console.ReadLine();

                Cliente clienteLogueado = clienteBusiness.IniciarSesion(dni, contraseña);

                if (clienteLogueado != null)
                {
                    Console.WriteLine($"Inicio de sesión exitoso. Bienvenido, {clienteLogueado.Nombre}!");
                }
                else
                {
                    Console.WriteLine("Credenciales inválidas. Inténtalo de nuevo.");
                }
                break;
            case "2":
                Console.Write("Nombre: ");
                string nombre = Console.ReadLine();
                Console.Write("DNI: ");
                string nuevoDni = Console.ReadLine();
                Console.Write("Contraseña: ");
                string nuevaContraseña = Console.ReadLine();

                clienteBusiness.RegistrarCliente(nombre, nuevoDni, nuevaContraseña);
                Console.WriteLine("Registro exitoso. Ahora puedes iniciar sesión.");
                break;
            case "3":
                Console.WriteLine("Saliendo del programa...");
                running = false;
                break;
            default:
                Console.WriteLine("Opción inválida. Introduce una opción válida.");
                break;
        }

        Console.WriteLine("\nPresiona cualquier tecla para continuar...");
        Console.ReadKey();
    }
} */

/* ClienteBusiness clienteBusiness = new ClienteBusiness();

// Crear usuarios
clienteBusiness.CrearNuevoCliente(1, "Usuario1");
clienteBusiness.CrearNuevoCliente(2, "Usuario2");
// Puedes agregar más usuarios según necesites

// Mostrar usuarios por consola
Console.WriteLine("Lista de Usuarios:");
foreach (Clientes cliente in clienteBusiness.ObtenerTodosLosClientes())
{
    Console.WriteLine($"ID: {cliente.Id}, Nombre: {cliente.Nombre}");
}
Console.WriteLine("Hello, World!"); */
