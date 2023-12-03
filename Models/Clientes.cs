namespace Juegos.Models;
public class Clientes
{
    public string Dni { get; protected set; }
    protected string Nombre { get; set; }
    protected string Apellido { get; set; }
    protected int Telefono { get; set; }
    protected DateTime FechaNacimiento { get; set; }
    protected decimal Saldo { get; set; }


    public List<Clientes> listaClientes { get; set; } = new List<Clientes>();
    public List<Transaction> transactions { get; set; } = new List<Transaction>();




    public Clientes(string Dni, string Nombre, string apellido, int Telefono, DateTime FechaNacimiento, decimal SaldoInicial)
    {
        this.Dni = Dni;
        this.Nombre = Nombre;
        this.Apellido = Apellido;
        this.Telefono = Telefono;
        this.FechaNacimiento = FechaNacimiento;
        MakeDeposit(SaldoInicial, DateTime.Now, "Apertura de cuenta. Ingreso inicial");

        var user = new Clientes(Dni, Nombre, apellido, Telefono, FechaNacimiento, SaldoInicial);
        listaClientes.Add(user);

    }
    public Clientes(string Dni, string Nombre, int apellido, int Telefono, DateTime FechaNacimiento, double SaldoInicial)
    {
        this.Dni = Dni;
        this.Nombre = Nombre;
        this.Apellido = Apellido;
        this.Telefono = Telefono;
        this.FechaNacimiento = FechaNacimiento;
    }

    public void MakeDeposit(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "La cantidad depositada debe ser positiva");
        }
        var deposit = new Transaction(amount, date, note);
        transactions.Add(deposit);
    }

    public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "La cantidad retirada debe ser positiva");
        }
        if (Saldo - amount < 0)
        {
            throw new InvalidOperationException("No tienes suficiente dinero");
        }
        var withdrawal = new Transaction(-amount, date, note);
        transactions.Add(withdrawal);
    }

    public override string ToString()
    {
        //return Number ?? "NoNumber";
        var tostring = $"El Usuario {Nombre} {Apellido} ha creado una cuenta con un saldo incial de {Saldo}";
        return tostring;
    }

}
