namespace Juegos.Models;

public class Compra
{
    private static int contadorCompras = 1;

    public int Id { get; private set; }
    public Cliente Cliente { get; set; }
    public Juego JuegoComprado { get; set; }
    public decimal PrecioTotal { get; set; }
    public DateTime FechaCompra { get; set; }

    public Compra(Cliente cliente, Juego juegoComprado, decimal precioTotal, DateTime fechaCompra)
    {
        Id = contadorCompras++;
        Cliente = cliente;
        JuegoComprado = juegoComprado;
        PrecioTotal = precioTotal;
        FechaCompra = fechaCompra;
    }


}
