using rpgTipoChave;
using rpgPorta;
using rpgSalasDoJogo;
using rpgSala;
using rpgMapa;

namespace rpgPortasDoJogo;

public class PortasDoJogo
{
    public static Porta CriarPortaSalaDeArmas(Mapa mapa)
    {
        return new Porta(SalasDoJogo.criarSalaDeArmas(mapa), TipoChave.SalaDeArmas);
    }
    public static Porta CriarPortaSalaDeAula(Mapa mapa)
    {
        return new Porta(SalasDoJogo.criarSalaDeAula(mapa), TipoChave.SalaDeAula);
    }
    public static Porta CriarPortaSalaArquivos(Mapa mapa)
    {
        return new Porta(SalasDoJogo.criarSalaDeArquivosBiblioteca(mapa), TipoChave.SalaBiblioteca);
    }
    public static Porta CriarPortaEstoqueHospital(Mapa mapa)
    {
        return new Porta(SalasDoJogo.criarEstoqueHospital(mapa), TipoChave.EstoqueHospital);
    }
    public static Porta CriarPortaAreaExperimentos(Mapa mapa)
    {
        return new Porta(SalasDoJogo.criarAreaExperimentosLaboratorio(mapa), TipoChave.Laboratorio);
    }

}