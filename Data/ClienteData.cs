namespace Juegos.Data;

using Juegos.Models;
public class ClienteData
    {
        private Dictionary<int, Clientes> clientes = new Dictionary<int, Clientes>();
        private int idCount = 0;

        public ClienteData()
        {
            // Ejemplo: Agregar algunos clientes al iniciar la aplicación
            AgregarCliente(new Clientes(++idCount, "Cliente1", "12345678A", "contraseña1"));
            AgregarCliente(new Clientes(++idCount, "Cliente2", "87654321B", "contraseña2"));
        }

        public Dictionary<int, Clientes> ObtenerTodosLosClientes()
        {
            return clientes;
        }

        public void AgregarCliente(Clientes cliente)
        {
            clientes.Add(cliente.Id, cliente);
        }

        public Clientes ObtenerClientePorId(int id)
        {
            if (clientes.ContainsKey(id))
            {
                return clientes[id];
            }
            return null;
        }

        public Clientes ObtenerClientePorDNI(string dni)
        {
            foreach (KeyValuePair<int, Clientes> kvp in clientes)
            {
                if (kvp.Value.DNI == dni)
                {
                    return kvp.Value;
                }
            }
            return null;
        }
    }



