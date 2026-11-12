using rpgItem;
using rpgJogador;
using rpgMissoesDoJogo;

namespace rpgMissao;

public enum IdMissao
{
    Policial,
    Enfermeira,
    Cientista,
    Padre,
    Professora   
}
public class Missao
{
    public IdMissao Id;
    public String NomeDaMissao;
    public Item? ItemNecessario;
    public String Descricao;
    public Item? Recompensa;
    public bool Concluida = false;

    public Missao(IdMissao id, String nomedamissao, String descricao, Item? itemnecessario, Item? recompensa)
    {
        this.Id = id;
        this.NomeDaMissao = nomedamissao;
        this.Descricao = descricao;
        this.ItemNecessario = itemnecessario;
        this.Recompensa = recompensa;        
    }

    public static Boolean MissaoConcluida(Jogador jogador)
    {
        var missao = jogador.MissaoAtual;

        if (missao == null) return false;

        if (missao.Id == IdMissao.Padre && jogador.BillyEncontrado) return true;

        if (missao.Id == IdMissao.Professora && jogador.MaryEncontrada) return true;

        if (missao.ItemNecessario == null) return false;
            
        return jogador.Inventario.ListarItens().Any(item => item.Nome == missao.ItemNecessario.Nome);
    }

    public static void MissaoAceita(Jogador jogador)
    {
        if(jogador.MissaoAtual != null)
        {
            Console.WriteLine("\nVocê aceitou uma missão!\n");
            Console.WriteLine($"Missão: < {jogador.MissaoAtual.NomeDaMissao} >");
            Console.WriteLine($"Objetivo: {jogador.MissaoAtual.Descricao}");
        }
        
    }
}