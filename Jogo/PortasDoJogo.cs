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
    public static Porta CriarPortaSalaDeArmas(Mapa mapa)
    {
        return new Porta(SalasDoJogo.criarSalaDeArmas(mapa), ItensDoJogo.CriarChaveSalaDeArmas());
    }
    public static Porta CriarPortaSalaDeAula(Mapa mapa)
    {
        return new Porta(SalasDoJogo.criarSalaDeAula(mapa), ItensDoJogo.CriarChaveSalaDeAula());
    }
    public static Porta CriarPortaSalaArquivos(Mapa mapa)
    {
        return new Porta(SalasDoJogo.criarSalaDeArquivosBiblioteca(mapa), ItensDoJogo.CriarChaveSalaBiblioteca());
    }
    public static Porta CriarPortaEstoqueHospital(Mapa mapa)
    {
        return new Porta(SalasDoJogo.criarEstoqueHospital(mapa), ItensDoJogo.CriarChaveEstoqueHospital());
    }
    public static Porta CriarPortaAreaExperimentos(Mapa mapa)
    {
        return new Porta(SalasDoJogo.criarAreaExperimentosLaboratorio(mapa), ItensDoJogo.CriarChaveAreaExperimentos());
    }

}