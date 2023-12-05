namespace Juegos.Data;

using Juegos.Models;
public class CompraData
{
private List<Compra> listaCompras = new List<Compra>();

        public void AgregarCompra(Compra compra)
        {
            listaCompras.Add(compra);
        }


}



