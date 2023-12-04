namespace Juegos.Data;

using Juegos.Models;
public class JuegoData
    {
        private static int contadorId = 0;
        private Dictionary<int, Juegos> juegos = new Dictionary<int, Juegos>();

        public void AgregarJuego(Juegos juego)
        {
            juego.idJuego = ++contadorId;
            juegos.Add(juego.idJuego, juego);
        }

        public Dictionary<int, Juegos> ObtenerTodosLosJuegos()
        {
            return juegos;
        }




    }
