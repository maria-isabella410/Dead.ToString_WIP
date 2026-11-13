using rpgJogador;
using rpgMapa;
using rpgValidacaoInput;

namespace rpgMenuPrincipal;

public enum opcoesMenu
{
    Explorar = 1,
    AbrirMapa = 2,
    AbrirInventario = 3,
    VerificarStatus = 4,
    IrParaOutroLocal = 5,
    EncerrarJogo = 0
}
public class MenuPrincipal
{
    private Jogador jogador;
    private Mapa mapa;
    private ValidacaoInput validacaoInput = new ValidacaoInput();
    
    public MenuPrincipal(Jogador jogador, Mapa mapa)
    {
        this.jogador = jogador;
        this.mapa = mapa;
    }
    public void MostrarMenuPrincipal()
    {
        Console.WriteLine("O que quer fazer?\n");
        Console.WriteLine("[1] Explorar");
        Console.WriteLine("[2] Abrir mapa");
        Console.WriteLine("[3] Abrir inventário");
        Console.WriteLine("[4] Verificar status");
        Console.WriteLine("[5] Ir para outro local");
        Console.WriteLine("[0] Encerrar jogo");
    }
    public opcoesMenu ReceberOpcao()
    {
        int opcao = validacaoInput.OpcaoValidada(5);

        return (opcoesMenu)opcao;
    }
    public void AbrirMapa()
    {
        if (!jogador.ContemMapa) Console.WriteLine("\nVocê não tem o mapa da cidade!");
        else mapa.MostrarMapa();

    }
}