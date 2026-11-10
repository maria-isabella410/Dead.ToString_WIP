using rpgValidacaoInput;

namespace rpgMenuExploracao;

public enum opcoesExplorar
{
    ProcurarItens = 1,
    ChecarArredores = 2,
    ProcurarSobreviventes = 3
}
public class MenuExploracao
{
    private ValidacaoInput validacaoInput = new ValidacaoInput();
    public void MostrarMenuExploracao()
    {
        Console.WriteLine("O que quer fazer? (0 para Voltar)");
        Console.WriteLine("[1] Procurar itens");
        Console.WriteLine("[2] Checar os arredores por zombies");
        Console.WriteLine("[3] Procurar sobreviventes");
    }

    public opcoesExplorar ReceberOpcao()
    {
        int opcao = validacaoInput.OpcaoValidada(3);

        return (opcoesExplorar)opcao;
    }
}