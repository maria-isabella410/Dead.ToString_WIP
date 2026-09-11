using System.Collections.Generic;
using System.Data;
using rpgArma;
using rpgConsumivel;
using rpgItem;
using rpgChave;
using rpgJogador;
using rpgItensDoJogo;

namespace rpgInventario;

public class Inventario
{
    private List<Item> Itens {get; set;}
    public int Capacidade {get; set;} = 10;
    public int EspacosOcupados {get {return Itens.Count;}}

    public Inventario(int capacidade)
    {
        Itens = new List<Item>();
        this.Capacidade = capacidade;
    }
    public List<Item> ListarItens()
    {        
        return Itens;
    }
    public void InspecionarItem(Item item)
    {
        Console.WriteLine($"{item.Nome} - {item.Descricao}");
    }

    public List<Arma> ListarArmas()
    {
        List<Arma> armas = new List<Arma>();
        
        foreach(Item item in Itens)
        {
            if(item is Arma arma)
            {
                armas.Add(arma);
            }
        }

        return armas;   
    }
    public List<Consumivel> ListarConsumiveis()
    {
        List<Consumivel> consumiveis = new List<Consumivel>();

        foreach(Item item in Itens)
        {
            if(item is Consumivel consumivel)
            {
                consumiveis.Add(consumivel);
            }
        }

        return consumiveis;
    }
    public List<Chave> ListarChaves()
    {
        List<Chave> chaves = new List<Chave>();

        foreach(Item item in Itens)
        {
            if(item is Chave chave)
            {
                chaves.Add(chave);
            }
        }

        return chaves;
    }
    public Boolean GuardarItem(Item item, Jogador jogador)
    {
        if(Itens.Count >= Capacidade)
        {
            Console.WriteLine($"Seu inventário está cheio. Descarte um item para coletar o outro. [{jogador.Inventario.EspacosOcupados} / {jogador.Inventario.Capacidade}]");

            return false;
        }

        if(item == ItensDoJogo.CriarMapaDaCidade())
        {
            jogador.ContemMapa = true;

            return true;
        }

        if(item == ItensDoJogo.CriarMochila())
        {
            jogador.MochilaEquipada = true;

            this.Capacidade = 15;

            return true;
        }

        if(item == ItensDoJogo.CriarColete())
        {
            jogador.ColeteEquipado = true;

            jogador.Defesa += 20;
        }

        Itens.Add(item);

        return true;
    }
    public void DescartarItem(Item item)
    {
        Itens.Remove(item);
    }
}