using rpgChave;
using rpgSala;

namespace rpgPorta;

public class Porta
{
    public Sala SalaPertencente {get; private set;}
    public Chave ChaveNecessaria {get; set;}
    public Boolean Aberta {get; set;}

    public Porta(Sala salapertencente, Chave chavenecessaria)
    {
        this.SalaPertencente = salapertencente;
        this.ChaveNecessaria = chavenecessaria;
    }
    
    public Boolean Abrir(Chave chave)
    {
        if(chave.Tipo == ChaveNecessaria.Tipo) return true;
        else return false;
    }
}