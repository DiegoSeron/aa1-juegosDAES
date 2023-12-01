namespace Juegos.Models;

public class Compras 
{
    protected int idCompra {get;}
    protected DateTime fechaDeCompra {get;}
    protected string idComprador {get; private set;}
    protected int idJuegoComprado {get; private set;}
    protected List<Compras> cestaCompra {get; set;} = new List<Compras>();
    protected decimal precioTotal {get;}

    int idCompraSeed = 1;
    public Compras(Clientes clientes, Juegos juegos){
        idCompra = idCompraSeed++;
        fechaDeCompra = DateTime.Now;
        idComprador = clientes.Dni;
        idJuegoComprado = juegos.idJuego;
    }
}
