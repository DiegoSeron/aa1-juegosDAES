// See https://aka.ms/new-console-template for more information

using Juegos.Business;
using Juegos.Data;
using Juegos.Models;

ClienteBusiness clienteBusiness = new ClienteBusiness();
JuegoBusiness juegoBusiness = new JuegoBusiness();

bool running = true;

juegoBusiness.CrearJuego("The Witcher 3", "RPG", 10, 29.99m, 18);
juegoBusiness.CrearJuego("GTA", "RPG", 10, 29.99m, 18);
juegoBusiness.CrearJuego( "The Witcher 3", "Aventura", 50, 29.99m, 18);
juegoBusiness.CrearJuego( "FIFA 22", "Deportes", 100, 49.99m, 3);
juegoBusiness.CrearJuego( "Cyberpunk 2077", "RPG", 30, 59.99m, 18);



while (running)
{
    Console.WriteLine("\n¡Hola! ¿Qué eres?");
    Console.WriteLine("1. Admin");
    Console.WriteLine("2. Cliente");
    Console.WriteLine("3. Salir");
    Console.WriteLine("Selecciona una opción: ");

    string opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            // Código para el Submenú 1
            bool submenu1 = true;
            while (submenu1)
            {
                Console.WriteLine("\nMenú de Admin");
                Console.WriteLine("1. Crear Juego");
                Console.WriteLine("2. Ver todos los juegos");
                Console.WriteLine("3. Añadir stock en un juego");
                Console.WriteLine("4. Volver al menú principal");
                Console.WriteLine("Selecciona una opción: ");
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
                        Console.WriteLine("Pegi: ");
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
                        Console.WriteLine("Ingrese el ID del juego al que desea añadir cantidad: ");
                        if (int.TryParse(Console.ReadLine(), out int juegoId))
                        {
                            Console.Write("Ingrese la cantidad que desea añadir: ");
                            if (int.TryParse(Console.ReadLine(), out int cantidadAAgregar))
                            {
                                juegoBusiness.AgregarCantidadAJuego(juegoId, cantidadAAgregar);
                            }
                            else
                            {
                                Console.WriteLine("Cantidad inválida. Introduzca un número válido.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("ID inválido. Introduzca un número de ID válido.");
                        }
                        break;

                    case "4":
                        submenu1 = false; // Volver al menú principal
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Introduce una opción válida.");
                        break;
                }


            }
            break;
        case "2":
            bool loggedIn = false;
            while (!loggedIn)
            {
                Console.WriteLine("\nMenú de Cliente");
                Console.WriteLine("1. Iniciar Sesión");
                Console.WriteLine("2. Registrarse");
                Console.WriteLine("3. Volver");
                Console.WriteLine("Selecciona una opción: ");

                string opcionCliente = Console.ReadLine();
                switch (opcionCliente)
                {
                    case "1":
                        Console.WriteLine("DNI: ");
                        string dni = Console.ReadLine();
                        Console.WriteLine("Contraseña: ");
                        string contraseña = Console.ReadLine();

                        Clientes clienteLogueado = clienteBusiness.IniciarSesion(dni, contraseña);

                        if (clienteLogueado != null)
                        {
                            loggedIn = true;
                            Console.WriteLine($"Inicio de sesión exitoso. Bienvenido, {clienteLogueado.Nombre}!");
                            int idCliente = clienteLogueado.Id;
                            bool loggedInMenu = true;

                            while (loggedInMenu)
                            {
                                Console.WriteLine("\nMenú del cliente:");
                                Console.WriteLine("1. Explorar juegos disponibles");
                                Console.WriteLine("2. Buscar por categoria");
                                Console.WriteLine("3. Comprar");
                                Console.WriteLine("4. Añadir Saldo");
                                Console.WriteLine("5. Ver juegos coprados");
                                Console.WriteLine("6. Cerrar sesión");
                                Console.WriteLine("Selecciona una opción: ");

                                string opcionMenuCliente = Console.ReadLine();

                                switch (opcionMenuCliente)
                                {
                                    case "1":
                                        // Lógica para mostrar juegos disponibles
                                        juegoBusiness.MostrarTodosLosJuegos();
                                        break;
                                    case "2":
                                        Console.WriteLine("Ingrese la categoría de juego que desea buscar:");
                                        string categoriaBusqueda = Console.ReadLine();

                                        // Lógica para buscar juegos por categoría
                                        juegoBusiness.BuscarJuegosPorCategoria(categoriaBusqueda); // Implementa esta función según tu lógica
                                        break;
                                    case "3":
                                        Console.WriteLine("Ingrese el ID del juego que desea comprar:");
                                        if (int.TryParse(Console.ReadLine(), out int juegoId))
                                        {
                                            // Obtener el juego por su ID
                                            Juegos.Models.Juegos juegoSeleccionado = juegoBusiness.ObtenerJuegoPorId(juegoId);

                                            if (juegoSeleccionado != null)
                                            {
                                                // Verificar si el cliente tiene suficiente saldo para comprar el juego

                                                int edadCliente = DateTime.Now.Year - clienteLogueado.FechaNacimiento.Year;

                                                if (edadCliente > juegoSeleccionado.pegi)
                                                {
                                                    if (clienteLogueado.Saldo >= juegoSeleccionado.precio)
                                                    {
                                                        if (juegoSeleccionado.cantidad > 0)
                                                        {
                                                            // Restar el precio del juego del saldo del cliente
                                                            clienteLogueado.Saldo -= juegoSeleccionado.precio;

                                                            // Reducir la cantidad disponible del juego
                                                            juegoSeleccionado.cantidad--;

                                                            // Agregar el juego al carrito de compras del cliente
                                                            clienteLogueado.AgregarJuegoAlCarrito(juegoSeleccionado);

                                                            // Actualizar el precio total del carrito
                                                            clienteLogueado.ActualizarPrecioTotal(juegoSeleccionado.precio);

                                                            Console.WriteLine($"Compra exitosa. Has adquirido: {juegoSeleccionado.nombreJuego}");
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("No hay stock de este juego");

                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("No tienes saldo suficiente para comprar este juego");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("No tienes la edad suficiente para comprar este juego.");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("ID de juego no válido. Introduce un ID existente.");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("ID inválido. Introduce un número de ID válido.");
                                        }
                                        break;

                                    case "4":
                                        Console.WriteLine("Ingresar dinero");
                                        Console.WriteLine("Ingrese la cantidad a depositar: ");
                                        if (decimal.TryParse(Console.ReadLine(), out decimal cantidad))
                                        {
                                            clienteBusiness.IngresarDinero(idCliente, cantidad);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Cantidad inválida. Introduzca un valor numérico válido.");
                                        }
                                        break;
                                    case "5":
                                        clienteBusiness.MostrarJuegosComprados(idCliente); // Llama al método para mostrar los juegos comprados por el cliente
                                        break;

                                    case "6":
                                        Console.WriteLine("Cerrando sesión...");
                                        loggedInMenu = false; // Salir del menú del cliente
                                        break;
                                    default:
                                        Console.WriteLine("Opción inválida. Introduce una opción válida.");
                                        break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Credenciales inválidas. Inténtalo de nuevo.");
                        }
                        break;
                    case "2":
                        Console.WriteLine("Nombre: ");
                        string nombre = Console.ReadLine();
                        Console.WriteLine("DNI: ");
                        string nuevoDni = Console.ReadLine();
                        Console.WriteLine("Contraseña: ");
                        string nuevaContraseña = Console.ReadLine();



                        DateTime fechaNacimiento = DateTime.MinValue;
                        bool formatoCorrectoFecha = false;

                        while (!formatoCorrectoFecha)
                        {
                            Console.WriteLine("Fecha de nacimiento (YYYY-MM-DD): ");
                            if (DateTime.TryParse(Console.ReadLine(), out fechaNacimiento))
                            {
                                formatoCorrectoFecha = true;
                            }
                            else
                            {
                                Console.WriteLine("Formato de fecha incorrecto. Introduce la fecha en el formato correcto (YYYY-MM-DD).");
                            }
                        }

                        Console.WriteLine("Saldo: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal saldo))
                        {
                        }
                        else
                        {
                            Console.WriteLine("Formato de saldo incorrecto. Introduce un valor numérico válido.");
                        }

                        clienteBusiness.RegistrarCliente(nombre, nuevoDni, nuevaContraseña, fechaNacimiento, saldo);
                        Console.WriteLine("Registro exitoso. Ahora puedes iniciar sesión.");

                        break;
                    case "3":
                        loggedIn = true; // Volver al menú principal
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Introduce una opción válida.");
                        break;
                }

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

}
