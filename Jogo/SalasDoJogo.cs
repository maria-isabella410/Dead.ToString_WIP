using rpgMapa;
using rpgPortasDoJogo;
using rpgSala;

namespace rpgSalasDoJogo;

public class SalasDoJogo
{
    private Mapa Mapa {get; set;}
    public static Sala criarSalaDeArmas()
    {
        return new Sala(Mapa.delegacia, PortasDoJogo.CriarPortaSalaDeArmas());
    }
}