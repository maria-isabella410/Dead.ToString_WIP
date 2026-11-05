namespace rpgMenuExploracao;

public class MenuExploracao
{
    private enum opcoesExplorar
    {
        ProcurarItens = 1,
        ChecarArredores = 2,
        ProcurarSobreviventes = 3
    }
    public void menuExploracao()
    {
        Console.WriteLine("O que quer fazer? ([0] para Voltar)");
        Console.WriteLine("[1] Procurar itens");
        Console.WriteLine("[2] Checar os arredores por zombies");
        Console.WriteLine("[3] Procurar sobreviventes");
        Console.Write("--> "); 
    }
}