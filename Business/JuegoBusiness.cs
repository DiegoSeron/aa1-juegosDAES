namespace Juegos.Business;

using Juegos.Data;
using Juegos.Models;
public class JuegoBusiness
{
    private JuegoData juegoData = new JuegoData();
    private Dictionary<int, Juegos> juegos = new Dictionary<int, Juegos>();

    public void CrearJuego(string nombreJuego, string categoria, int cantidad, decimal precio, int pegi/* , DateTime fechaLanzamiento */)
    {
        Juegos nuevoJuego = new Juegos(0, nombreJuego, categoria, cantidad, precio, pegi/* , fechaLanzamiento */);
        juegoData.AgregarJuego(nuevoJuego);
    }

    public Dictionary<int, Juegos> ObtenerTodosLosJuegos()
    {
        return juegoData.ObtenerTodosLosJuegos();
    }
    public void MostrarTodosLosJuegos()
    {
        Dictionary<int, Juegos> juegos = ObtenerTodosLosJuegos();

        Console.WriteLine("Lista de Juegos:");
        foreach (var juego in juegos)
        {
            Console.WriteLine($"ID: {juego.Key}, Nombre: {juego.Value.nombreJuego}, Categoría: {juego.Value.categoria}, Cantidad: {juego.Value.cantidad}");
            // Mostrar otros detalles si es necesario
        }
    }

    public void AgregarCantidadAJuego(int juegoId, int cantidadAAgregar)
        {
            juegoData.AgregarCantidadAJuego(juegoId, cantidadAAgregar);
        }




}



