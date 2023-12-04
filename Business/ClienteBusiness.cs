namespace Juegos.Business;

using Juegos.Data;
using Juegos.Models;
public class ClienteBusiness
    {
        private ClienteData clienteData = new ClienteData();

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
    }



