using rpgTipoChave;
using rpgPorta;

namespace rpgPortasDoJogo;

public class PortasDoJogo
{
    public static Porta CriarPortaSalaDeArmas()
    {
        return new Porta("Porta da sala de armas", TipoChave.SalaDeArmas);
    }
    public static Porta CriarPortaSalaDeAula()
    {
        return new Porta("Porta da sala de aula", TipoChave.SalaDeAula);
    }
    public static Porta CriarPortaSalaBiblioteca()
    {
        return new Porta("Porta da sala da biblioteca", TipoChave.SalaBiblioteca);
    }
    public static Porta CriarPortaArmarioHospital()
    {
        return new Porta("Porta do armário do hospital", TipoChave.EstoqueHospital);
    }
    public static Porta CriarPortaSalaLaboratorio()
    {
        return new Porta("Porta da sala do laboratório", TipoChave.Laboratorio);
    }

}