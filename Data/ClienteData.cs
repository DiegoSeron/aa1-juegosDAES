namespace Juegos.Data;

using Juegos.Models;
public class ClienteData
{
    private Dictionary<int, Cliente> clientes = new Dictionary<int, Cliente>();
    private int idCount = 0;

    public Dictionary<int, Cliente> ObtenerClientes()
    {
        return clientes;
    }

    public void AgregarCliente(Cliente cliente)
    {
        clientes.Add(cliente.Id, cliente);
    }

    public Cliente ObtenerClientePId(int id)
    {
        if (clientes.ContainsKey(id))
        {
            return clientes[id];
        }
        return null;
    }

    public Cliente ObtenerClienteDNI(string dni)
    {
        foreach (KeyValuePair<int, Cliente> i in clientes)
        {
            if (i.Value.DNI == dni)
            {
                return i.Value;
            }
        }
        return null;
    }


}



