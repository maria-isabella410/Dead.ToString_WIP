using rpgJogador;
using rpgValidacaoInput;

namespace rpgMenuInventario;

public enum opcoesInventario
{
    InspecionarItem = 1,
    ConsumirItem = 2,
    DescartarItem = 3,
    EquiparArma = 4,
    DesequiparArma = 5
}   
public class MenuInventario
{
    private Jogador jogador;
    private ValidacaoInput validacaoInput = new ValidacaoInput();

    public MenuInventario(Jogador jogador)
    {
        this.jogador = jogador;
    }
    public void MostrarMenuInventario()
    {      
        Console.WriteLine("O que quer fazer? ([0] para Voltar)");
        Console.WriteLine("[1] Inspecionar item");
        Console.WriteLine("[2] Consumir item");
        Console.WriteLine("[3] Descartar item");
        if(jogador.ArmaEquipada == null) Console.WriteLine("[4] Equipar arma");
        else
        {
            Console.WriteLine("[4] Equipar outra arma");
            Console.WriteLine("[5] Desequipar arma");
        } 
    }
    public opcoesInventario ReceberOpcao()
    {
        if(jogador.ArmaEquipada != null)
        {
            int opcao = validacaoInput.OpcaoValidada(5);

            return (opcoesInventario)opcao;
        }
        else
        {
            int opcao = validacaoInput.OpcaoValidada(4);

            return (opcoesInventario)opcao;
        }
    }
}