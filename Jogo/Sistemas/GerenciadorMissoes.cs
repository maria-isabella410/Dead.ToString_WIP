using rpgJogador;
using rpgMissao;
using rpgMissoesDoJogo;
using rpgTipoItem;

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

        if (Missao.MissaoConcluida(jogador))
        {
            jogador.MissaoAtual.Concluida = true;

            jogador.MissoesConcluidas.Add(jogador.MissaoAtual);

            if(jogador.MissaoAtual.ItemNecessario != null)
            {
                jogador.Inventario.DescartarItem(jogador.MissaoAtual.ItemNecessario);
            }

            if(jogador.MissaoAtual.Recompensa != null)
            {
                if(jogador.Inventario.GuardarItem(jogador.MissaoAtual.Recompensa, jogador))
                {
                    if(jogador.MissaoAtual.Recompensa.tipoItem == TipoItem.ConsumivelAntidoto)
                    {
                        Console.WriteLine($"\nMissão concluída! O antidoto foi adicionado ao seu inventário. Quando se sentir pronto, sabe o que deve fazer.");
                    }
                    else
                    {
                        Console.WriteLine($"\nMissão concluída! O item de recompensa [{jogador.MissaoAtual.Recompensa.Nome}] foi adicionado ao seu inventário.");
                    }
                }
            }
                
            if(jogador.MissaoAtual.Recompensa == null && jogador.MissaoAtual.Id == IdMissao.Enfermeira)
            {                
                Console.WriteLine("\nMissão concluída! A Enfermeira Grace irá tratar seus ferimentos.");

                jogador.Vida = jogador.VidaMaxima;

                Console.WriteLine("\nApós uma sessão de cuidados, você se sente muito melhor.");
                Console.WriteLine($"\nHP: [{jogador.Vida} / {jogador.VidaMaxima}]");                
            }            

            jogador.MissaoAtual = null;
        }
    }
}