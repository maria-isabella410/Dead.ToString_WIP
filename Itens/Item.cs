using rpgTipoItem;

namespace rpgItem;

public class Item{
    public String Nome {get; private set;}
    public String Descricao {get; private set;}
    public TipoItem tipoItem {get; private set;}

    public Item(String nome, String descricao, TipoItem tipoItem)
    {
        this.Nome = nome;
        this.Descricao = descricao;
        this.tipoItem = tipoItem;
    }
}