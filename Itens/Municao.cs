using rpgItem;
using rpgTipoMunicao;
using rpgTipoItem;

namespace rpgMunicao;

public class Municao : Item
{
    public TipoMunicao TipoMunicao {get; private set;}
    public int Quantidade {get; private set;}

    public Municao(String nome, String descricao, TipoMunicao tipomunicao, int quantidade) : base(nome, descricao, TipoItem.Municao)
    {
        this.TipoMunicao = tipomunicao;
        this.Quantidade = quantidade;
    }
}