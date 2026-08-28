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
        return new Porta("Sala de armas", TipoChave.SalaDeArmas);
    }
    public static Porta CriarPortaSalaDeAula(Mapa mapa)
    {
        return new Porta("Sala de aula", TipoChave.SalaDeAula);
    }
    public static Porta CriarPortaSalaBiblioteca(Mapa mapa)
    {
        return new Porta("Sala da biblioteca", TipoChave.SalaBiblioteca);
    }
    public static Porta CriarPortaArmarioHospital(Mapa mapa)
    {
        return new Porta("Armário do hospital", TipoChave.ArmarioHospital);
    }
    public static Porta CriarPortaLaboratorio()
    {
        return new Porta("Laboratório", TipoChave.Laboratorio);
    }

}