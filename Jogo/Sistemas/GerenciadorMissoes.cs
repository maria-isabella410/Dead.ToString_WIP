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
    public Boolean AtualizarMissao()
    {
        if(jogador.MissaoAtual == null) return false;

        if (!Missao.MissaoConcluida(jogador)) return false;

        Missao missao = jogador.MissaoAtual;

        Boolean missaoPossuiItemNecessario = missao.ItemNecessario != null;

        Boolean possuiItemNecessario = missaoPossuiItemNecessario && jogador.Inventario.ListarItens().Any(item => item.Nome == missao.ItemNecessario!.Nome);

        if(missao.Recompensa != null)
        {
            Boolean inventarioCheio = jogador.Inventario.EspacosOcupados >= jogador.Inventario.Capacidade;

            if(inventarioCheio && !possuiItemNecessario)
            {
                Console.WriteLine("Seu inventário está cheio! Libere espaço para receber sua recompensa.");

                return false;
            }
        }

        if (possuiItemNecessario)
        {
            jogador.Inventario.DescartarItemPorNome(missao.ItemNecessario!.Nome);
        }
        
        if(missao.Recompensa != null)
        {
            jogador.Inventario.GuardarItem(missao.Recompensa, jogador);

            if(missao.Recompensa.tipoItem == TipoItem.ConsumivelAntidoto)
            {
                Console.WriteLine($"\nMissão concluída! O antidoto foi adicionado ao seu inventário. Quando se sentir pronto, sabe o que deve fazer.");
            }
            else
            {
                Console.WriteLine($"\nMissão concluída! O item de recompensa [{missao.Recompensa.Nome}] foi adicionado ao seu inventário.");
            }
        }
        else if(missao.Recompensa == null && missao.Id == IdMissao.Enfermeira)
        {
            Console.WriteLine("\nMissão concluída! A Enfermeira Grace irá tratar seus ferimentos.");

            jogador.Vida = jogador.VidaMaxima;

            Console.WriteLine("\nApós uma sessão de cuidados, você se sente muito melhor.");
            
            Console.WriteLine($"\nHP: [{jogador.Vida} / {jogador.VidaMaxima}]");
        }

        missao.Concluida = true;

        jogador.MissoesConcluidas.Add(missao);

        jogador.MissaoAtual = null;

        return true;
    }
}