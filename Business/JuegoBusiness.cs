namespace Juegos.Business;

using Juegos.Data;
using Juegos.Models;
public class JuegoBusiness
{
    private JuegoData juegoData = new JuegoData();
    private Dictionary<int, Juego> juegos = new Dictionary<int, Juego>();

    public void CrearJuego(string nombreJuego, string categoria, int cantidad, decimal precio, int pegi)
    {
        Juego nuevoJuego = new Juego(0, nombreJuego, categoria, cantidad, precio, pegi);
        juegoData.AgregarJuego(nuevoJuego);
    }

    public Dictionary<int, Juego> ObtenerJuegos()
    {
        return juegoData.ObtenerJuegos();
    }
    public void MostrarJuegos()
    {
        Dictionary<int, Juego> juegos = ObtenerJuegos();

        Console.WriteLine("Lista de Juegos:");
        foreach (var juego in juegos)
        {
            Console.WriteLine($"ID: {juego.Key}, Nombre: {juego.Value.nombreJuego}, Categoría: {juego.Value.categoria}, Cantidad: {juego.Value.cantidad}, Precio: {juego.Value.precio}, Pegi: {juego.Value.pegi}");
        }
    }

    public void AgregarCantidad(int juegoId, int cantidadAAgregar)
    {
        juegoData.AgregarCantidad(juegoId, cantidadAAgregar);
    }

    public void BuscarJuegosCategoria(string categoriaBusqueda)
    {
        Dictionary<int, Juego> juegosPorCategoria = juegoData.ObtenerJuegos()
            .Where(juego => juego.Value.categoria.ToLower() == categoriaBusqueda.ToLower())
            .ToDictionary(pair => pair.Key, pair => pair.Value);

        if (juegosPorCategoria.Count > 0)
        {
            Console.WriteLine($"Juegos encontrados en la categoría '{categoriaBusqueda}':");
            foreach (var juego in juegosPorCategoria)
            {
            Console.WriteLine($"ID: {juego.Key}, Nombre: {juego.Value.nombreJuego}, Categoría: {juego.Value.categoria}, Cantidad: {juego.Value.cantidad}, Precio: {juego.Value.precio}, Pegi: {juego.Value.pegi}");
            }
        }
        else
        {
            Console.WriteLine($"No se encontraron juegos en la categoría '{categoriaBusqueda}'.");
        }
    }

    public Juego ObtenerJuegoId(int idJuego)
    {
        Dictionary<int, Juego> juegos = ObtenerJuegos();

        if (juegos.ContainsKey(idJuego))
        {
            return juegos[idJuego];
        }

        return null;
    }





}



