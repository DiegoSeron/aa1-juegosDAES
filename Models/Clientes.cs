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

    public Clientes(int id, string nombre, string dni, string contraseña, DateTime fechaNacimiento, decimal saldo)
    {
        Id = id;
        Nombre = nombre;
        DNI = dni;
        Contraseña = contraseña;
        FechaNacimiento = fechaNacimiento;
        Saldo = saldo;
    }

}
