// See https://aka.ms/new-console-template for more information

using Juegos.Business;
using Juegos.Data;
using Juegos.Models;

ClienteBusiness clienteBusiness = new ClienteBusiness();
JuegoBusiness juegoBusiness = new JuegoBusiness();

bool running = true;

juegoBusiness.CrearJuego("The Witcher 3", "RPG", 10, 29.99m, 18);
juegoBusiness.CrearJuego("GTA", "RPG", 10, 29.99m, 18);
juegoBusiness.CrearJuego("The Witcher 3", "Aventura", 50, 29.99m, 18);
juegoBusiness.CrearJuego("FIFA 22", "Deportes", 100, 49.99m, 3);
juegoBusiness.CrearJuego("Cyberpunk 2077", "RPG", 30, 59.99m, 18);



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
            // MENU ADMIN
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
                        // CREAR JUEGO
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

                        juegoBusiness.CrearJuego(nombreJuego, categoria, cantidad, precio, pegi);
                        Console.WriteLine("\nNuevo juego creado exitosamente.");
                        break;
                    case "2":
                        juegoBusiness.MostrarJuegos();
                        break;

                    case "3":
                        Console.WriteLine("Ingrese el ID del juego al que desea añadir cantidad: ");
                        if (int.TryParse(Console.ReadLine(), out int juegoId))
                        {
                            Console.Write("Ingrese la cantidad que desea añadir: ");
                            if (int.TryParse(Console.ReadLine(), out int cantidadAAgregar))
                            {
                                juegoBusiness.AgregarCantidad(juegoId, cantidadAAgregar);
                            }
                            else
                            {
                                Console.WriteLine("\nCantidad inválida. Introduzca un número válido.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nID invalido. Introduzca un número de ID valido.");
                        }
                        break;

                    case "4":
                        submenu1 = false; // VOLVER MENU PRINCIPAL
                        break;
                    default:
                        Console.WriteLine("\nOpción invalida. Introduce una opcion valida.");
                        break;
                }


            }
            break;
        case "2":
            bool loggedIn = false;
            while (!loggedIn)
            {
                // MENU CLIENTE
                Console.WriteLine("\nMenú de Cliente");
                Console.WriteLine("1. Iniciar Sesión");
                Console.WriteLine("2. Registrarse");
                Console.WriteLine("3. Volver");
                Console.WriteLine("Selecciona una opción: ");

                string opcionCliente = Console.ReadLine();
                switch (opcionCliente)
                {
                    case "1":
                        // INICIAR SESION
                        Console.WriteLine("DNI: ");
                        string dni = Console.ReadLine();
                        Console.WriteLine("Contraseña: ");
                        string contraseña = Console.ReadLine();

                        Cliente clienteLogueado = clienteBusiness.IniciarSesion(dni, contraseña);

                        if (clienteLogueado != null)
                        {
                            loggedIn = true;
                            Console.WriteLine($"\nInicio de sesión exitoso. Bienvenido, {clienteLogueado.Nombre}!");
                            int idCliente = clienteLogueado.Id;
                            bool loggedInMenu = true;

                            while (loggedInMenu)
                            {
                                Console.WriteLine("\nMenú del cliente:");
                                Console.WriteLine("1. Explorar juegos disponibles");
                                Console.WriteLine("2. Buscar por categoria");
                                Console.WriteLine("3. Comprar");
                                Console.WriteLine("4. Añadir Saldo");
                                Console.WriteLine("5. Cerrar sesion");
                                Console.WriteLine("Selecciona una opción: ");

                                string opcionMenuCliente = Console.ReadLine();

                                switch (opcionMenuCliente)
                                {
                                    case "1":
                                        // VER JUEGOS
                                        juegoBusiness.MostrarJuegos();
                                        break;
                                    case "2":
                                        // BUSCAR POR CATEGORIA
                                        Console.WriteLine("\nIngrese la categoría de juego que desea buscar:");
                                        string categoriaBusqueda = Console.ReadLine();

                                        juegoBusiness.BuscarJuegosCategoria(categoriaBusqueda);
                                        break;
                                    case "3":
                                        // COMPRAR JUEGO
                                        Console.WriteLine("\nIngrese el ID del juego que desea comprar:");
                                        if (int.TryParse(Console.ReadLine(), out int juegoId))
                                        {
                                            Juegos.Models.Juego juegoSeleccionado = juegoBusiness.ObtenerJuegoId(juegoId);

                                            if (juegoSeleccionado != null)
                                            {
                                                int edadCliente = DateTime.Now.Year - clienteLogueado.FechaNacimiento.Year;

                                                if (edadCliente > juegoSeleccionado.pegi)
                                                {
                                                    if (clienteLogueado.Saldo >= juegoSeleccionado.precio)
                                                    {
                                                        if (juegoSeleccionado.cantidad > 0)
                                                        {
                                                            clienteLogueado.Saldo -= juegoSeleccionado.precio;

                                                            juegoSeleccionado.cantidad--;

                                                            clienteLogueado.ActualizarPrecioTotal(juegoSeleccionado.precio);

                                                            Console.WriteLine($"\nCompra exitosa. Has adquirido: {juegoSeleccionado.nombreJuego}");
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("\nNo hay stock de este juego");

                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("\nNo tienes saldo suficiente para comprar este juego");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("\nNo tienes la edad suficiente para comprar este juego.");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("\nID de juego no valido. Introduce un ID existente.");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nID invalido. Introduce un numero de ID valido.");
                                        }
                                        break;

                                    case "4":
                                        // INGRESAR DINERO
                                        Console.WriteLine("\nIngresar dinero");
                                        Console.WriteLine("Ingrese la cantidad a depositar: ");
                                        if (decimal.TryParse(Console.ReadLine(), out decimal cantidad))
                                        {
                                            clienteBusiness.IngresarDinero(idCliente, cantidad);
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nCantidad invalida. Introduzca un valor numerico valido.");
                                        }
                                        break;
                                    case "5":
                                        // VOLVER MENU CLIENTE
                                        Console.WriteLine("Cerrando sesion...");
                                        loggedInMenu = false;
                                        break;
                                    default:
                                        Console.WriteLine("Opción invalida. Introduce una opción valida.");
                                        break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Credenciales invalidas. Intentalo de nuevo.");
                        }
                        break;
                    case "2":
                        // REGISTRARSE
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
                                Console.WriteLine("\nFormato de fecha incorrecto. Introduce la fecha en el formato correcto (YYYY-MM-DD).");
                            }
                        }

                        decimal saldo = 0;
                        bool formatoCorrectoSaldo = false;
                        while (!formatoCorrectoSaldo)
                        {
                            Console.WriteLine("Saldo: ");
                            if (decimal.TryParse(Console.ReadLine(), out saldo))
                            {
                                formatoCorrectoSaldo = true;
                            }
                            else
                            {
                                Console.WriteLine("\nFormato de saldo incorrecto. Introduce un valor numérico valido");
                            }
                        }

                        clienteBusiness.RegistrarCliente(nombre, nuevoDni, nuevaContraseña, fechaNacimiento, saldo);
                        Console.WriteLine("\nRegistro exitoso. Ahora puedes iniciar sesion.");

                        break;
                    case "3":
                    // VOLVER MENU PRINCIPAL
                        loggedIn = true;
                        break;
                    default:
                        Console.WriteLine("Opcion invalida. Introduce una opcion valida.");
                        break;
                }

            }
            break;
        case "3":
        // SALIR PROGRAMA
            Console.WriteLine("Programa finalizado");
            running = false;
            break;
        default:
            Console.WriteLine("Opcion inválida. Introduce una opción valida.");
            break;
    }

}
