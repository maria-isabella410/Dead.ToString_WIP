using rpgItem;
using rpgTipoChave;
using rpgTipoItem;

namespace rpgChave;

public class Chave : Item
{
    public TipoChave Tipo {get; private set;}

    public Chave(String nome, String descricao, TipoChave tipo) : base(nome, descricao, TipoItem.Chave)
    {
        this.Tipo = tipo;
    }
}