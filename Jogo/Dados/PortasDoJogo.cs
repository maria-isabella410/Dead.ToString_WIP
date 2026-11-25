using rpgTipoChave;
using rpgPorta;
using rpgSalasDoJogo;
using rpgSala;
using rpgMapa;
using rpgChave;
using rpgItensDoJogo;
using rpgLocal;

namespace rpgPortasDoJogo;

public class PortasDoJogo
{
    public static Porta CriarPortaSalaDeArmas(Sala sala)
    {
        return new Porta(null, sala, ItensDoJogo.CriarChaveSalaDeArmas(), null);
    }
    public static Porta CriarPortaSalaDeAula(Sala sala)
    {
        return new Porta(null, sala, ItensDoJogo.CriarChaveSalaDeAula(), null);
    }
    public static Porta CriarPortaSalaArquivos(Sala sala)
    {
        return new Porta(null, sala, ItensDoJogo.CriarChaveSalaBiblioteca(), null);
    }
    public static Porta CriarPortaEstoqueHospital(Sala sala)
    {
        return new Porta(null, sala, ItensDoJogo.CriarChaveEstoqueHospital(), null);
    }
    public static Porta CriarPortaAreaExperimentos(Sala sala)
    {
        return new Porta(null, sala, ItensDoJogo.CriarChaveAreaExperimentos(), null);
    }
    public static Porta CriarPortaCasaAbandonada(Local local)
    {
        return new Porta(local, null, null, ItensDoJogo.CriarPeDeCabra());
    }

}