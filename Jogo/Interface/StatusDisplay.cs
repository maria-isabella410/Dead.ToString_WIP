using rpgJogador;

namespace rpgStatusDisplay;

public class StatusDisplay
{
    private Jogador jogador;

    public StatusDisplay(Jogador jogador)
    {
        this.jogador = jogador;
    }
    public void mostrarStatus(Jogador jogador)
    {
        Console.WriteLine("Jogador: " + jogador.Nome);
        Console.WriteLine($"HP: [{jogador.Vida} / {jogador.VidaMaxima}]");
        Console.WriteLine("Ataque: " + jogador.Ataque);
        Console.WriteLine("Defesa: " + jogador.Defesa);
        Console.WriteLine("Agilidade: " + jogador.Agilidade);

        if(jogador.MissaoAtual != null)
        {
            Console.WriteLine("Missão atual: " + jogador.MissaoAtual.NomeDaMissao);
        }
        if(jogador.ArmaEquipada != null)
        {
            Console.WriteLine("Arma equipada: " + jogador.ArmaEquipada.Nome);
        }
    }    
}