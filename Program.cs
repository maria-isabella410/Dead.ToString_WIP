using rpgArma;
using rpgJogador;
using rpgTipoArma;
using rpgInventario;
using rpgZombie;
using rpgTipoZombie;
using rpgMapa;
using rpgJogo;

namespace MainProgram;

public class Program{
    public static void Main(string[] args)
    {
        Jogo Jogo = new Jogo();
        Jogo.Iniciar();
    }
}