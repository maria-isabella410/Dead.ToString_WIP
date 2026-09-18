namespace rpgDialogoOpcoes;

public class DialogoOpcao
{
    public String Opcao {get; set;}
    public Action Action {get; set;}

    public DialogoOpcao(String opcao, Action action)
    {
        this.Opcao = opcao;
        this.Action = action;
    }
}