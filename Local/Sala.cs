using rpgPorta;
using rpgLocal;

namespace rpgSala;

public class Sala
{
    public String Nome;
    public String Descricao;
    public Local LocalPertencente;
    public Porta? PortaTrancada;

    public Sala(String nome, String descricao, Local localpertencente, Porta? portatrancada)
    {
        this.Nome = nome;
        this.Descricao = descricao;
        this.LocalPertencente = localpertencente;
        this.PortaTrancada = portatrancada;
    }
}