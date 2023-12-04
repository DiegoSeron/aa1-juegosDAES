namespace Juegos.Models;
public class Juegos
{
    public int idJuego {get; set;}
    public string nombreJuego {get; set;}
    public string categoria {get; set;}
    public int cantidad {get; set;}
    public Boolean stock {get; set;}
    public decimal precio {get; set;}
    public int pegi {get; set;}
    public DateTime fechaLanzamiento{get; set;}

    private static int juegosSeed = 1;

    public List<Juegos> listaJuegos { get; set; } = new List<Juegos>();


    public Juegos(int idJuego, string nombreJuego, string categoria, int cantidad, decimal precio, int pegi/* , DateTime fechaLanzamiento */){
        this.nombreJuego = nombreJuego;
        this.categoria = categoria;
        this.cantidad = cantidad;
        this.precio = precio;
        this.pegi = pegi;
/*         this.fechaLanzamiento = fechaLanzamiento;
 */        idJuego = juegosSeed++;

/*         var juego = new Juegos(idJuego, nombreJuego, categoria, cantidad, precio, pegi/* , fechaLanzamiento );
        listaJuegos.Add(juego); */
    }

    public void addStock(int idJuego, int addCantidad){
        if (cantidad <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(cantidad), "La cantidad depositada debe ser positiva");
        }
        cantidad = cantidad + addCantidad;
    }
}
