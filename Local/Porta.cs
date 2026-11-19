using rpgChave;
using rpgSala;
using rpgTipoChave;

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
    
    public void Abrir(Chave chave)
    {
        if(chave == ChaveNecessaria)
        {
            this.Aberta = true;
            Console.WriteLine("\nVocê abriu a porta.\n");
        }
        else
        {
            Console.WriteLine("\nVocê não tem a chave necessária para abrir essa porta.\n");
        }
    }
}