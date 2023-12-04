namespace Juegos.Models;
public class Clientes
{

public int Id { get; set; }
        public string Nombre { get; set; }
        public string DNI { get; set; }
        public string Contraseña { get; set; }
        // Puedes agregar más propiedades según sea necesario

        public Clientes(int id, string nombre, string dni, string contraseña)
        {
            Id = id;
            Nombre = nombre;
            DNI = dni;
            Contraseña = contraseña;
        }

}
