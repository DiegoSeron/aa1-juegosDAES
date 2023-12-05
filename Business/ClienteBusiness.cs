namespace Juegos.Business;

using Juegos.Data;
using Juegos.Models;
public class ClienteBusiness
{
    private ClienteData clienteData = new ClienteData();
    private CompraData compraData = new CompraData();


    public Dictionary<int, Cliente> ObtenerClientes()
    {
        return clienteData.ObtenerClientes();
    }

    public void RegistrarCliente(string nombre, string dni, string contraseña, DateTime fechaNacimiento, decimal saldo)
    {
        int nuevoId = clienteData.ObtenerClientes().Count + 1;
        Cliente nuevoCliente = new Cliente(nuevoId, nombre, dni, contraseña, fechaNacimiento, saldo);
        clienteData.AgregarCliente(nuevoCliente);
    }

    public Cliente IniciarSesion(string dni, string contraseña)
    {
        return clienteData.ObtenerClienteDNI(dni);
    }

    public void IngresarDinero(int idCliente, decimal cantidad)
    {
        Cliente cliente = clienteData.ObtenerClientePId(idCliente);
        if (cliente != null)
        {
            cliente.Saldo += cantidad;
            Console.WriteLine($"Se agregó {cantidad} al saldo del cliente {cliente.Nombre}. Nuevo saldo: {cliente.Saldo}");
        }
        else
        {
            Console.WriteLine("Cliente no encontrado.");
        }
    }


       public void ComprarJuego(Cliente cliente, Juego juegoComprado, decimal precioTotal)
        {
            DateTime fechaCompra = DateTime.Now; 
            Console.WriteLine($"Juego comprado: {juegoComprado.nombreJuego}");
            Console.WriteLine($"Precio total: {precioTotal}");
            Console.WriteLine($"Fecha de compra: {fechaCompra}");

        }

}



