using System.Collections.Generic;
using rpgItem;
using rpgItensDoJogo;
using rpgJogador;

namespace rpgMissao;

public class Missao
{
    public String NomeDaMissao {get; set;}
    public Item? ItemNecessario;
    public String Descricao {get; set;}
    public Item Recompensa {get; set;}
    public bool Concluida {get; set;} = false;

    public Missao(String nomedamissao, String descricao, Item? itemnecessario, Item recompensa)
    {
        this.NomeDaMissao = nomedamissao;
        this.Descricao = descricao;
        this.ItemNecessario = itemnecessario;
        this.Recompensa = recompensa;        
    }

    public static Boolean MissaoValida(Jogador jogador)
    {
        List<Item> itens = jogador.Inventario.ListarItens();

        Boolean contemItem = false;

        foreach(Item item in itens)
        {
            if(jogador.MissaoAtual.ItemNecessario == item)
            {
                contemItem = true;
            }
        }
        if (contemItem)
        {
            return true;
        }
        else return false;    
    }
}