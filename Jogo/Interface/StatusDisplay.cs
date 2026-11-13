using rpgJogador;

namespace rpgStatusDisplay;

public class StatusDisplay
{
    private Jogador jogador;

    public StatusDisplay(Jogador jogador)
    {
        this.jogador = jogador;
    }
    public void MostrarStatus(Jogador jogador)
    {
        Console.WriteLine($"\nJogador: {jogador.Nome}" );
        Console.WriteLine($"HP: [{jogador.Vida} / {jogador.VidaMaxima}]");
        if(jogador.MissaoAtual != null)
        {
            Console.WriteLine($"Missão atual: {jogador.MissaoAtual.NomeDaMissao}");
        }
        if(jogador.ArmaEquipada != null)
        {
            Console.WriteLine($"Arma equipada: {jogador.ArmaEquipada.Nome}");
        }
        Console.WriteLine($"Ataque: {jogador.Ataque}");
        Console.WriteLine($"Defesa: {jogador.Defesa}");
        Console.WriteLine($"Agilidade: {jogador.Agilidade}\n");
    }    
}