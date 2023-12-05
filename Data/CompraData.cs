namespace Juegos.Data;

using Juegos.Models;
public class CompraData
{
private List<Compras> listaCompras = new List<Compras>();

        public void AgregarCompra(Compras compra)
        {
            listaCompras.Add(compra);
        }

        public List<Compras> ObtenerComprasPorCliente(int idCliente)
        {
            return listaCompras.Where(compra => compra.Cliente.Id == idCliente).ToList();
        }

}



