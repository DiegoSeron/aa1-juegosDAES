namespace Juegos.Data;

using Juegos.Models;
public class JuegoData
    {
        private static int contadorId = 0;
        private Dictionary<int, Juego> juegos = new Dictionary<int, Juego>();

        public void AgregarJuego(Juego juego)
        {
            juego.idJuego = ++contadorId;
            juegos.Add(juego.idJuego, juego);
        }

        public Dictionary<int, Juego> ObtenerJuegos()
        {
            return juegos;
        }


        public void AgregarCantidad(int juegoId, int cantidadAAgregar)
        {
            if (juegos.ContainsKey(juegoId))
            {
                juegos[juegoId].cantidad += cantidadAAgregar;
                Console.WriteLine($"Se añadieron {cantidadAAgregar} unidades al juego con ID {juegoId}.");
            }
            else
            {
                Console.WriteLine($"No se encontró ningún juego con ID {juegoId}.");
            }
        }
 


    }
