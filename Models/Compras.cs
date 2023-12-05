namespace Juegos.Models;

public class Compras
{
    private static int contadorCompras = 1;

    public int Id { get; private set; }
    public Clientes Cliente { get; set; }
    public Juegos JuegoComprado { get; set; }
    public decimal PrecioTotal { get; set; }
    public DateTime FechaCompra { get; set; }

    public Compras(Clientes cliente, Juegos juegoComprado, decimal precioTotal, DateTime fechaCompra)
    {
        Id = contadorCompras++;
        Cliente = cliente;
        JuegoComprado = juegoComprado;
        PrecioTotal = precioTotal;
        FechaCompra = fechaCompra;
    }


}
