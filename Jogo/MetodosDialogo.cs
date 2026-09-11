using rpgJogador;
using rpgJogo;
using rpgNpc;
using rpgTopicoDialogo;
using rpgMissao;

namespace rpgMetodosDialogo;

public class MetodosDialogo
{
    private Jogador Jogador {get; set;}

    public MetodosDialogo(Jogador jogador)
    {
        this.Jogador = jogador;
    }
    public int EscolherOpcao(params string[] opcoes)
    {
        for(int i = 0; i < opcoes.Length; i++)
        {
            Console.WriteLine($"[{i+1}] {opcoes[i]}");
        }

        Console.Write("--> ");

        return Convert.ToInt32(Console.ReadLine());
    }
    public void ApresentarJogador(Npc npc)
    {
        Console.WriteLine(npc.Dialogo.Cumprimento);

        Console.WriteLine($"Me chamo {Jogador.Nome}.");

        if(npc.Dialogo.Introducao != null)
        {
            Console.WriteLine(npc.Dialogo.Introducao.Replace("{nome}", Jogador.Nome));
        }
           
    }
    public void OferecerMissao(Npc npc)
    {
        Console.WriteLine(npc.Dialogo.Missao);

        Jogo.DivisaoDeLinha();

        Console.WriteLine(npc.Missao);

        int escolha = EscolherOpcao("Certo, posso fazer isso.", "Desculpa, não posso.", "Preciso ir embora.");

        switch(escolha)
        {
            case 1:
                Console.WriteLine(npc.Dialogo.DespedidaMissaoAceitada.Replace("{nome}", Jogador.Nome));
                Jogador.MissaoAtual = npc.Missao;

                break;
            case 2:
                Console.WriteLine(npc.Dialogo.DespedidaMissaoRecusada.Replace("{nome}", Jogador.Nome));

                break;
            case 3:
                return;
            default:
                Console.WriteLine("Entrada inválida!");
                
                break;
            }
    }
    public void ContinuarDialogo(Npc npc)
    {
        Console.WriteLine(npc.Dialogo.Historia);

        HashSet<TopicoDialogo> topicosFalados = new ();

        Boolean conversando = true;

        while (conversando)
        {
            if(!topicosFalados.Contains(TopicoDialogo.Quem))
            {
                Console.WriteLine("[1] Quem é você?");
            }
            if(!topicosFalados.Contains(TopicoDialogo.Historia))
            {
                Console.WriteLine("[2] O que aconteceu?");
            }
            if(!topicosFalados.Contains(TopicoDialogo.Missao))
            {
                Console.WriteLine("[3] Posso ajudar?");
            }

            Console.WriteLine("[4] Preciso ir embora.");

            if(topicosFalados.Contains(TopicoDialogo.Quem) && topicosFalados.Contains(TopicoDialogo.Historia) && topicosFalados.Contains(TopicoDialogo.Missao))
            {
                conversando = false;

                npc.ConversouTudo = true;
            }

            int escolha = Convert.ToInt32(Console.ReadLine());

            switch(escolha)
            {
                case 1:
                    ApresentarJogador(npc);

                    topicosFalados.Add(TopicoDialogo.Quem);

                    break;
                case 2:
                    Console.WriteLine(npc.Dialogo.Historia.Replace("{nome}", Jogador.Nome));

                    topicosFalados.Add(TopicoDialogo.Historia);

                    break;
                case 3:
                    OferecerMissao(npc);

                    topicosFalados.Add(TopicoDialogo.Missao);
                    
                    break;
                case 4:
                    conversando = false;

                    return;
                default:
                    Console.WriteLine("Entrada inválida!");
                    
                    break;    
            }
            
        }

        if (npc.ConversouTudo && !Missao.MissaoValida(Jogador))
        {
            Console.WriteLine("Estou esperando...");
        } else if(npc.ConversouTudo && Missao.MissaoValida(Jogador))
        {
            Console.WriteLine(npc.Dialogo.MissaoConcluida.Replace("{nome}", Jogador.Nome));

            //arrumar dps
        }
    }
}