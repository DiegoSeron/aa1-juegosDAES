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

        public void RegistrarCliente(string nombre, string dni, string contraseña)
        {
            int nuevoId = clienteData.ObtenerTodosLosClientes().Count + 1;
            Clientes nuevoCliente = new Clientes(nuevoId, nombre, dni, contraseña);
            clienteData.AgregarCliente(nuevoCliente);
        }

        public Clientes IniciarSesion(string dni, string contraseña)
        {
            return clienteData.ObtenerClientePorDNI(dni);
        }
    }



