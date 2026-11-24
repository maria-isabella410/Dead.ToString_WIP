using rpgItem;
using rpgTipoItem;

namespace rpgConsumivel;

public class Consumivel : Item
{
    public int QtdVidaRecuperada {get; private set;}
    public TipoItem tipoItemConsumivel;

    public Consumivel(String nome, String descricao, TipoItem tipoitemconsumivel, int qtdvidarecuperada) : base(nome, descricao, tipoitemconsumivel)
    {
        this.QtdVidaRecuperada = qtdvidarecuperada;
    }
}