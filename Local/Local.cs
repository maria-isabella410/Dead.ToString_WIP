using rpgItem;
using rpgNpc;
using rpgSala;
using rpgZombie;

namespace rpgLocal;

public class Local
{
    public String Nome {get; private set;}
    public String Descricao {get; private set;}
    public Local? Norte {get; set;}
    public Local? Sul {get; set;}
    public Local? Leste {get; set;}
    public Local? Oeste {get; set;}
    public List<Sala> Salas {get; private set;}
    public List<Item> Itens {get; private set;}
    public List<Npc> Npcs {get; private set;}
    public List<Zombie> Zombies {get; private set;}

    public Local(String nome, String descricao)
    {
        this.Nome = nome;
        this.Descricao = descricao;
        
        Itens = new List<Item>();
        Npcs = new List<Npc>();
        Zombies = new List<Zombie>();
        Salas = new List<Sala>();
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
    public void AdicionarSala(Sala sala)
    {
        Salas.Add(sala);
    }
    public static void DescreverLocal(Local local)
    {
        Console.WriteLine("Local: " + local.Nome);
        Console.WriteLine("\nDescrição: " + local.Descricao);
    }
}