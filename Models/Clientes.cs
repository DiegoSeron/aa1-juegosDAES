namespace Juegos.Models;
public class Clientes
{

    public int Id { get; set; }
    public string Nombre { get; set; }
    public string DNI { get; set; }
    public string Contraseña { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public decimal Saldo { get; set; }
    // Puedes agregar más propiedades según sea necesario
    public List<Compras> ComprasRealizadas { get; set; }

    public Clientes(int id, string nombre, string dni, string contraseña, DateTime fechaNacimiento, decimal saldo)
    {
        Id = id;
        Nombre = nombre;
        DNI = dni;
        Contraseña = contraseña;
        FechaNacimiento = fechaNacimiento;
        Saldo = saldo;

        ComprasRealizadas = new List<Compras>();

    }

public List<Juegos> CarritoCompras { get; set; } = new List<Juegos>();
    public decimal PrecioTotalCarrito { get; set; } = 0;

    public void AgregarJuegoAlCarrito(Juegos juego)
    {
        CarritoCompras.Add(juego);
    }

    public void ActualizarPrecioTotal(decimal precioJuego)
    {
        PrecioTotalCarrito += precioJuego;
    }




}
