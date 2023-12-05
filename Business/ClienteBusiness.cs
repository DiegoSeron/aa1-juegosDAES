namespace Juegos.Business;

using Juegos.Data;
using Juegos.Models;
public class ClienteBusiness
{
    private ClienteData clienteData = new ClienteData();
    private CompraData compraData = new CompraData();


    public Dictionary<int, Clientes> ObtenerTodosLosClientes()
    {
        return clienteData.ObtenerTodosLosClientes();
    }

    public void RegistrarCliente(string nombre, string dni, string contraseña, DateTime fechaNacimiento, decimal saldo)
    {
        int nuevoId = clienteData.ObtenerTodosLosClientes().Count + 1;
        Clientes nuevoCliente = new Clientes(nuevoId, nombre, dni, contraseña, fechaNacimiento, saldo);
        clienteData.AgregarCliente(nuevoCliente);
    }

    public Clientes IniciarSesion(string dni, string contraseña)
    {
        return clienteData.ObtenerClientePorDNI(dni);
    }

    public void IngresarDinero(int idCliente, decimal cantidad)
    {
        Clientes cliente = clienteData.ObtenerClientePorId(idCliente);
        if (cliente != null)
        {
            cliente.Saldo += cantidad;
            // Lógica adicional si es necesaria
            Console.WriteLine($"Se agregó {cantidad} al saldo del cliente {cliente.Nombre}. Nuevo saldo: {cliente.Saldo}");
        }
        else
        {
            Console.WriteLine("Cliente no encontrado.");
        }
    }


       public void ComprarJuego(Clientes cliente, Juegos juegoComprado, decimal precioTotal)
        {
            DateTime fechaCompra = DateTime.Now; // Fecha actual de la compra
            Console.WriteLine($"Juego comprado: {juegoComprado.nombreJuego}");
            Console.WriteLine($"Precio total: {precioTotal}");
            Console.WriteLine($"Fecha de compra: {fechaCompra}");

            // Aquí puedes restar el precio del juego al saldo del cliente si es necesario
        }


    public void MostrarJuegosComprados(int idCliente)
    {
        List<Compras> comprasCliente = compraData.ObtenerComprasPorCliente(idCliente);

        if (comprasCliente.Count > 0)
        {
            Console.WriteLine($"Juegos comprados por el cliente con ID {idCliente}:");
            foreach (Compras compra in comprasCliente)
            {
                Console.WriteLine($"ID de compra: {compra.Id}");
                Console.WriteLine($"Fecha de compra: {compra.FechaCompra}");
                Console.WriteLine($"Juego comprado: {compra.JuegoComprado.nombreJuego}"); // Mostrar el nombre del juego comprado
                Console.WriteLine($"Precio del juego: {compra.PrecioTotal}");
                // Otros detalles de la compra si es necesario
                Console.WriteLine("---------------------------------------");
            }
        }
        else
        {
            Console.WriteLine("El cliente no ha realizado ninguna compra.");
        }

    }
}



