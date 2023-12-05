namespace Juegos.Models;
public class Cliente
{

    public int Id { get; set; }
    public string Nombre { get; set; }
    public string DNI { get; set; }
    public string Contraseña { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public decimal Saldo { get; set; }
    public List<Compra> ComprasRealizadas { get; set; }

    public Cliente(int id, string nombre, string dni, string contraseña, DateTime fechaNacimiento, decimal saldo)
    {
        Id = id;
        Nombre = nombre;
        DNI = dni;
        Contraseña = contraseña;
        FechaNacimiento = fechaNacimiento;
        Saldo = saldo;

        ComprasRealizadas = new List<Compra>();

    }

public List<Juego> CarritoCompras { get; set; } = new List<Juego>();
    public decimal PrecioTotalCarrito { get; set; } = 0;

    public void ActualizarPrecioTotal(decimal precioJuego)
    {
        PrecioTotalCarrito += precioJuego;
    }




}
