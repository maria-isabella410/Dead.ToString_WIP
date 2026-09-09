using rpgPorta;
using rpgLocal;
using rpgItem;
using rpgNpc;
using rpgZombie;

namespace rpgSala;

public class Sala
{
    public String Nome {get; private set;}
    public String Descricao {get; private set;}
    public Local LocalPertencente {get; private set;}
    public Porta? PortaTrancada {get; private set;}
    public List<Item> Itens {get; private set;}
    public List<Npc> Npcs {get; private set;}
    public List<Zombie> Zombies {get; private set;}    

    public Sala(String nome, String descricao, Local localpertencente, Porta? portatrancada)
    {
        this.Nome = nome;
        this.Descricao = descricao;
        this.LocalPertencente = localpertencente;
        this.PortaTrancada = portatrancada;
    }
    public void AdicionarItens(Item item)
    {
        Itens.Add(item);
    }
    public void AdicionarNpc(Npc npc)
    {
        Npcs.Add(npc);
    }  
    public void AdicionarZombie(Zombie zombie)
    {
        Zombies.Add(zombie);
    }
}