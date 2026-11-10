using System.Diagnostics.Metrics;
using rpgItem;
using rpgTipoArma;
using rpgTipoMunicao;
using rpgTipoItem;

namespace rpgArma;

public class Arma : Item
{
    public int Dano {get; private set;}
    public TipoArma Tipo {get; private set;}
    public TipoMunicao? TipoMunicao {get; private set;}
    public int? CapacidadeMunicao {get; private set;} = null;
    public int? Municao {get; private set;} = null;

    public Arma(String nome, String descricao, int dano, TipoArma tipo, TipoMunicao? tipomunicao, int? capacidademunicao, int? municao) : base(nome, descricao, TipoItem.Arma)
    {
        this.Dano = dano;
        this.Tipo = tipo;
        this.TipoMunicao = tipomunicao;
        this.CapacidadeMunicao = capacidademunicao;
        this.Municao = municao;
    }

    public Boolean TemMunicao()
    {
        if(Municao == 0) return false;
        else return true;
    }
    public void GastarMunicao()
    {
        Municao -= 1;
    }
    public void Recarregar(Arma arma)
    {
        if(arma.Municao == arma.CapacidadeMunicao)
        {
            Console.WriteLine("Sua arma já está cheia!");
            return;
        }
        while(arma.Municao != arma.CapacidadeMunicao)
        {
            Municao++;   
        }
        Console.WriteLine("Sua arma foi recarregada!");
        
    }
    public Boolean PodeRecarregar()
    {
        return Tipo != TipoArma.Faca;
    }
}