using rpgJogador;
using rpgMissao;
using rpgMissoesDoJogo;

namespace rpgGerenciadorMissoes;

public class GerenciadorMissoes
{
    private Jogador jogador;

    public GerenciadorMissoes(Jogador jogador)
    {
        this.jogador = jogador;
    }
    public void AtualizarMissao()
    {
        if(jogador.MissaoAtual == null) return;

        if (Missao.MissaoValida(jogador))
        {
            jogador.MissaoAtual.Concluida = true;

            jogador.Inventario.DescartarItem(jogador.MissaoAtual.ItemNecessario);

            jogador.Inventario.GuardarItem(jogador.MissaoAtual.Recompensa, jogador);
                
            if(jogador.MissaoAtual.Recompensa != null)
            {
                Console.WriteLine($"\nMissão concluída! O item de recompensa [{jogador.MissaoAtual.Recompensa.Nome}] foi adicionado ao seu inventário.\n");
            } 
            if(jogador.MissaoAtual.Recompensa == null && jogador.MissaoAtual == MissoesDoJogo.CriaMissaoEnfermeira())
            {                
                Console.WriteLine("\nMissão concluída! A Enfermeira Grace irá tratar seus ferimentos.");

                jogador.Vida = jogador.VidaMaxima;

                Console.WriteLine("\nApós uma sessão de cuidados, você se sente muito melhor.");
                Console.WriteLine($"\nHP: [{jogador.Vida} / {jogador.VidaMaxima}]");                
            }            

            jogador.MissaoAtual = null;
        }
        //arrumar dps
    }
}