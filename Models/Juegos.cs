namespace Juegos.Models;
public class Juegos
{
    public int idJuego { get; set; }
    public string nombreJuego { get; set; }
    public string categoria { get; set; }
    public int cantidad { get; set; }
    public decimal precio { get; set; }
    public int pegi { get; set; }
    public List<Juegos> listaJuegos { get; set; } = new List<Juegos>();


    public Juegos(int idJuego, string nombreJuego, string categoria, int cantidad, decimal precio, int pegi)
    {
        this.nombreJuego = nombreJuego;
        this.categoria = categoria;
        this.cantidad = cantidad;
        this.precio = precio;
        this.pegi = pegi;
        this.idJuego = idJuego;


    }

}
