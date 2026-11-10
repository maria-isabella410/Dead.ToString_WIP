namespace rpgValidacaoInput;

public class ValidacaoInput
{
    private Boolean ValidarInputInt(string input)
    {
        return int.TryParse(input, out int _);       
    }      
    private int TransformarEmInt(string input)
    {
        int.TryParse(input, out int inputTransformado);
        return inputTransformado;
    }     
    private Boolean ValidarOpcaoEscolhida(int opcaoEscolhida, int qtdOpcoes)
    {
        return opcaoEscolhida >= 0 && opcaoEscolhida <= qtdOpcoes;
    }

    public int OpcaoValidada(int qtdOpcoes)
    {
        while (true)
        {
            Console.Write("--> ");
            string input = Console.ReadLine() ?? "0";

            if(!ValidarInputInt(input))
            {
                Console.WriteLine("\nEntrada inválida! Digite apenas números.");
                continue;
            }
            int opcaoCorreta = TransformarEmInt(input);

            while(!ValidarOpcaoEscolhida(opcaoCorreta, qtdOpcoes))
            {
                Console.WriteLine($"\nOpção inválida! Escolha um número entre 0 e {qtdOpcoes}.");
                continue;
            }
            
            return opcaoCorreta;    
        }

    }
}