using System.Diagnostics.Metrics;
using rpgItem;
using rpgTipoArma;
using rpgTipoMunicao;
using rpgTipoItem;
using rpgInventario;

namespace rpgArma;

public class Arma : Item
{
    public int Dano {get; private set;}
    public TipoArma Tipo {get; private set;}
    public TipoMunicao? TipoMunicao {get; private set;}
    public int? CapacidadeMunicao {get; private set;} = null;
    public int? Municao {get; private set;} = null;
    List<string> DescricoesAtaque = new List<string>();

    public Arma(String nome, String descricao, int dano, TipoArma tipo, TipoMunicao? tipomunicao, int? capacidademunicao, int? municao, List<string> descricoesataque) : base(nome, descricao, TipoItem.Arma)
    {
        this.Dano = dano;
        this.Tipo = tipo;
        this.TipoMunicao = tipomunicao;
        this.CapacidadeMunicao = capacidademunicao;
        this.Municao = municao;
        this.DescricoesAtaque = descricoesataque;
    }
    public string ObterDescAtaque(Random random)
    {
        if (DescricoesAtaque.Count == 0) return $"Você ataca com a {Nome}";
        
        return DescricoesAtaque[random.Next(DescricoesAtaque.Count)];
    }
    public Boolean TemMunicao()
    {
        if(Municao == 0) return false;
        else return true;
    }
    public void GastarMunicao()
    {
        Municao--;

        if(Municao < 0) Municao = 0;
    }
    public Boolean Recarregar(Inventario inventario)
    {
        if(CapacidadeMunicao != null && Municao != null && TipoMunicao != null)
        {
            if (!PodeRecarregar())
            {
                return false;
            }

            if (Municao == CapacidadeMunicao)
            {
                Console.WriteLine("\nSua arma já está cheia!");
                
                return false;
            }

            int quantidadeNecessaria = CapacidadeMunicao.Value - Municao.Value;       

            int quantidadeObtida = inventario.RetirarMunicao(TipoMunicao.Value, quantidadeNecessaria);

            if (quantidadeObtida == 0)
            {
                Console.WriteLine("\nVocê não possui munição compatível!");
                return false;
            }
            
            Municao += quantidadeObtida;

            Console.WriteLine($"\nVocê recarregou sua arma! (+{quantidadeObtida} balas)");

            return true;            
        }
        return false;
    }
    public Boolean PodeRecarregar()
    {
        return Tipo != TipoArma.Faca;
    }
}