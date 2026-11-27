using rpgArma;
using rpgItensDoJogo;
using rpgJogador;
using rpgMissao;
using rpgTipoArma;

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
        string textoMissoesConcluidas = jogador.MissoesConcluidas.Count == 0 ? "Não há missões concluídas" : string.Join(", ", jogador.MissoesConcluidas.Select(missao => $"< {missao.NomeDaMissao} >"));

        Console.WriteLine($"Jogador: {jogador.Nome}" );
        Console.WriteLine($"HP: [{jogador.Vida} / {jogador.VidaMaxima}]");
        Console.WriteLine($"Ataque: {jogador.Ataque}");
        Console.WriteLine($"Defesa: {jogador.Defesa}");
        Console.WriteLine($"Agilidade: {jogador.Agilidade}");
        if(jogador.MissaoAtual != null)
        {
            Console.WriteLine($"Missão atual: {jogador.MissaoAtual.NomeDaMissao}");
        }
        if(jogador.ArmaEquipada != null)
        {
            Console.WriteLine($"Arma equipada: {jogador.ArmaEquipada.Nome}");
            if(jogador.ArmaEquipada.PodeRecarregar())
            {
                Console.WriteLine($"Munição: [{jogador.ArmaEquipada.Municao} / {jogador.ArmaEquipada.CapacidadeMunicao}]"); 
            }
        }
        Console.WriteLine($"Missões concluidas: {textoMissoesConcluidas}");  
    }    
}