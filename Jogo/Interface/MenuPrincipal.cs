namespace rpgMenuPrincipal;

public class MenuPrincipal
{
    private enum opcoesMenu
    {
        Explorar = 1,
        AbrirMapa = 2,
        AbrirInventario = 3,
        VerificarStatus = 4,
        IrParaOutroLocal = 5,
        EncerrarJogo = 0
    }
    public void menuPrincipal()
    {
        Console.WriteLine("O que quer fazer?");
        Console.WriteLine("[1] Explorar");
        Console.WriteLine("[2] Abrir mapa");
        Console.WriteLine("[3] Abrir inventário");
        Console.WriteLine("[4] Verificar status");
        Console.WriteLine("[5] Ir para outro local");
        Console.WriteLine("[0] Encerrar jogo");
        Console.Write("--> ");
    }
}