﻿namespace Juegos.Data;

using Juegos.Models;
public class ClienteData
{
    private Dictionary<int, Clientes> clientes = new Dictionary<int, Clientes>();
    private int idCount = 0;

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
        foreach (KeyValuePair<int, Clientes> i in clientes)
        {
            if (i.Value.DNI == dni)
            {
                return i.Value;
            }
        }
        return null;
    }


}



