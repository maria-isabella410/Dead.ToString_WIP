using rpgTipoChave;
using rpgPorta;
using rpgSalasDoJogo;
using rpgSala;
using rpgMapa;
using rpgChave;
using rpgItensDoJogo;

namespace rpgPortasDoJogo;

public class PortasDoJogo
{
    public static Porta CriarPortaSalaDeArmas(Mapa mapa, Sala sala)
    {
        return new Porta(sala, ItensDoJogo.CriarChaveSalaDeArmas());
    }
    public static Porta CriarPortaSalaDeAula(Mapa mapa, Sala sala)
    {
        return new Porta(sala, ItensDoJogo.CriarChaveSalaDeAula());
    }
    public static Porta CriarPortaSalaArquivos(Mapa mapa, Sala sala)
    {
        return new Porta(sala, ItensDoJogo.CriarChaveSalaBiblioteca());
    }
    public static Porta CriarPortaEstoqueHospital(Mapa mapa, Sala sala)
    {
        return new Porta(sala, ItensDoJogo.CriarChaveEstoqueHospital());
    }
    public static Porta CriarPortaAreaExperimentos(Mapa mapa, Sala sala)
    {
        return new Porta(sala, ItensDoJogo.CriarChaveAreaExperimentos());
    }

}