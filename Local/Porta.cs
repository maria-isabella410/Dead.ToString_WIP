using rpgChave;
using rpgItem;
using rpgLocal;
using rpgSala;

namespace rpgPorta;

public class Porta
{
    public Local? LocalPertencente;
    public Sala? SalaPertencente {get; private set;}
    public Chave? ChaveNecessaria {get; set;}
    public Item? ItemNecessario;
    public Boolean Aberta {get; set;}

    public Porta(Local? localpertencente, Sala? salapertencente, Chave? chavenecessaria, Item? itemnecessario)
    {
        this.LocalPertencente = localpertencente;
        this.SalaPertencente = salapertencente;
        this.ChaveNecessaria = chavenecessaria;
        this.ItemNecessario = itemnecessario;
    }
    
    public Boolean Abrir(Chave chave)
    {
        if(ChaveNecessaria != null)
        {
            if(chave.Tipo == ChaveNecessaria.Tipo) return true;
            else return false;
        }

        return false;
    }
}