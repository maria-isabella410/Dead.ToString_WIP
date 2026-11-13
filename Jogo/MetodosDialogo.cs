using rpgJogador;
using rpgJogo;
using rpgNpc;
using rpgMissao;
using rpgValidacaoInput;
using rpgNpcsDoJogo;
using System.ComponentModel.DataAnnotations;

namespace rpgMetodosDialogo;

public class MetodosDialogo
{
    private Jogador jogador;
    private Npc npc;
    private ValidacaoInput validacaoInput = new ValidacaoInput();

    public MetodosDialogo(Jogador jogador, Npc npc)
    {
        this.jogador = jogador;
        this.npc = npc;
    }
    public Boolean DialogoComCachorro()
    {
        Console.WriteLine("Cachorro:\n— Auau!!\n");

        Console.WriteLine("[1] Pegar Billy no colo");
        Console.WriteLine("[0] Voltar");

        int respostaPegarBilly = validacaoInput.OpcaoValidada(1);

        if(respostaPegarBilly == 0) return false;

        Console.WriteLine("Billy fica feliz ao estar no seu colo.\n");

        jogador.BillyEncontrado = true;

        return true;
    }
    public void DialogoComNpc()
    {
        if (npc.MissaoJaFoiConcluida && npc.Dialogo.MissaoConcluida != null)
        {
            Console.WriteLine($"{npc.Nome}: ");
            Console.WriteLine($"— {npc.Dialogo.MissaoConcluida}");

            Console.WriteLine("[0] Voltar");

            int escolhaMissaoConcluida = validacaoInput.OpcaoValidada(0);

            return;
        }

        Boolean ehCrianca = npc.Nome == NpcsDoJogo.CriaCrianca().Nome;

        Console.WriteLine(npc.DisseQuemEra ? npc.Nome : "Pessoa desconhecida: ");
        Console.WriteLine(npc.DisseQuemEra ? "— Ah, é você de novo!" : $"— {npc.Dialogo.Saudacao}");
        
        while (true)
        {
            List<Action> acoesDisponiveis = new List<Action>();
            int indice = 1;

            if (!npc.DisseQuemEra)
            {
                Console.WriteLine(ehCrianca ? $"[{indice}] Calma! Quem é você?" : $"[{indice}] Quem é você?");

                acoesDisponiveis.Add(() =>
                {
                    if (QuemEvoce(ehCrianca))
                    {
                        npc.DisseQuemEra = true; 
                    }                   
                });

                indice++;
    
            }

            if (npc.DisseQuemEra && !npc.ContouOqAconteceu)
            {
                Console.WriteLine($"[{indice}] O que aconteceu?");

                acoesDisponiveis.Add(() =>
                {
                    OqueAconteceu(false); 

                    npc.ContouOqAconteceu = true;                      
                }); 

                indice++;

            }
            else if (npc.ContouOqAconteceu)
            {
                Console.WriteLine($"[{indice}] Pode me lembrar o que aconteceu?");

                acoesDisponiveis.Add(() =>
                {
                    OqueAconteceu(true);
                });

                indice++;
            }

            if (npc.ContouOqAconteceu && !npc.OfereceuMissao)
            {
                Console.WriteLine($"[{indice}] Precisa de ajuda?");

                acoesDisponiveis.Add(() =>
                {
                    PrecisaDeAjuda(false, ehCrianca);

                    npc.OfereceuMissao = true;
                });

                indice++;
            }
            else if (npc.OfereceuMissao && !npc.AceitouMissao)
            {
                Console.WriteLine($"[{indice}] Ainda precisa de ajuda?");

                acoesDisponiveis.Add(() =>
                {
                    PrecisaDeAjuda(true, ehCrianca);
                });

                indice++;
            }

            else if (npc.AceitouMissao)
            {
                Console.WriteLine($"[{indice}] Estou trabalhando na missão.");

                acoesDisponiveis.Add(() => 
                {
                    Console.WriteLine($"{jogador.Nome}:\n— Estou trabalhando nisso.");
                    Console.WriteLine($"{npc.Nome}:\n— Estou esperando...");
                });

                indice++;
            }
            if (npc.DisseQuemEra && npc.ContouOqAconteceu && npc.OfereceuMissao)
            {
                if (!jogador.NpcsConhecidos.Contains(npc))
                {
                    jogador.NpcsConhecidos.Add(npc);
                }
            }

            if (Missao.MissaoConcluida(jogador))
            {
                Console.WriteLine($"[{indice}] Conclui a missão.");

                acoesDisponiveis.Add(() => 
                {
                    Console.WriteLine($"{jogador.Nome}:\n— Conclui o que eu estava fazendo.");
                    if(npc.Dialogo.AgradecimentoMissao != null)
                    {
                        Console.WriteLine($"{npc.Nome}:\n—{npc.Dialogo.AgradecimentoMissao.Replace("{nome}", jogador.Nome)}\n");
                    }

                    npc.MissaoJaFoiConcluida = true;

                    if(jogador.MissaoAtual != null && npc.Missao != null)
                    {
                        jogador.MissoesConcluidas.Add(jogador.MissaoAtual);
                        jogador.MissaoAtual = null;
                    }
                });

                indice++;                
            }

            Console.WriteLine("[0] Sair da conversa");

            int escolhaDialogo = validacaoInput.OpcaoValidada(acoesDisponiveis.Count);

            if(escolhaDialogo == 0) return;

            acoesDisponiveis[escolhaDialogo - 1].Invoke();

            if(npc.MissaoJaFoiConcluida) return;
        }
    }

    public Boolean QuemEvoce(Boolean ehCrianca)
    {
        Console.WriteLine($"{jogador.Nome}:");
        Console.WriteLine(ehCrianca ? "— Calma! Quem é você?" : "— Quem é você?");

        Console.WriteLine("\nPessoa desconhecida:");
        Console.WriteLine("— " + npc.Dialogo.Cumprimento + "\n");

        Console.WriteLine("[1] Me chamo...");
        Console.WriteLine("[0] Voltar");

        int escolhaResponderNome = validacaoInput.OpcaoValidada(1);

        if (escolhaResponderNome == 0)
        {
            return false;
        }
        
        Console.WriteLine($"{jogador.Nome}:");
        Console.WriteLine($"— Me chamo {jogador.Nome}.");

        if(npc.Dialogo.Introducao != null)
        {
            Console.WriteLine("\n" + npc.Nome);
            Console.WriteLine("— " + npc.Dialogo.Introducao.Replace("{nome}", jogador.Nome ) + "\n");
        }

        return true;
    }
    public void OqueAconteceu(Boolean JaPerguntado)
    {
        if(npc.Dialogo.Historia == null) return;

        Console.WriteLine($"{jogador.Nome}:");
        Console.WriteLine(JaPerguntado ? "— Pode me lembrar o que aconteceu?" : "— O que aconteceu?");

        Console.WriteLine("\n" + npc.Nome);
        Console.WriteLine("— " + npc.Dialogo.Historia + "\n");

        if(npc.Dialogo.HistoriaContinuacao != null)
        {
            Console.WriteLine("[1] Não sei se confio no que você diz.");
            Console.WriteLine("[0] Voltar");

            int escolhaResponderConfianca = validacaoInput.OpcaoValidada(1);

            if(escolhaResponderConfianca == 0) return;

            Console.WriteLine($"{jogador.Nome}:");
            Console.WriteLine("— Não sei se confio no que você diz.");

            Console.WriteLine("\n" + npc.Nome);
            Console.WriteLine("— " + npc.Dialogo.HistoriaContinuacao + "\n");         
        }
    }
      
    public void PrecisaDeAjuda(Boolean JaPerguntado, Boolean ehCrianca)
    {
        if(npc.Dialogo.Missao == null) return;

        Console.WriteLine($"{jogador.Nome}:");
        Console.WriteLine(JaPerguntado ? "— Do que você precisa mesmo?" : "— Precisa de ajuda?");       

        Console.WriteLine("\n" + npc.Nome);
        Console.WriteLine("— " + npc.Dialogo.Missao + "\n");

        Console.WriteLine("[1] Certo, posso ajudar.");
        Console.WriteLine("[2] Desculpa, não posso ajudar.");
        Console.WriteLine("[0] Voltar");

        switch (validacaoInput.OpcaoValidada(2))
        {
            case 1: AceitarMissao(ehCrianca); break;
            case 2: RecusarMissao(); break;
        }
    }

    public void AceitarMissao(Boolean ehCrianca)
    {
        if(jogador.MissaoAtual != null)
        {
            Console.WriteLine("Você não pode aceitar outra missão enquanto a atual ainda não foi concluída.\n");

            return;
        }

        if(npc.Missao == null && !ehCrianca) return;

        Console.WriteLine($"\n{jogador.Nome}:");
        Console.WriteLine("— Certo, posso ajudar.");

        if(npc.Dialogo.DespedidaMissaoAceitada != null)
        {
            Console.WriteLine("\n" + npc.Nome);
            Console.WriteLine("— " + npc.Dialogo.DespedidaMissaoAceitada.Replace("{nome}", jogador.Nome) + "\n");
        }

        if (ehCrianca)
        {
            jogador.MaryEncontrada = true;

            return;
        }

        jogador.MissaoAtual = npc.Missao;
        npc.AceitouMissao = true;

        Missao.MissaoAceita(jogador);
    }
    public void RecusarMissao()
    {
        Console.WriteLine($"\n{jogador.Nome}:");
        Console.WriteLine("— Desculpa, não posso ajudar.");

        Console.WriteLine("\n" + npc.Nome);
        Console.WriteLine("— " + npc.Dialogo.DespedidaMissaoRecusada + "\n");  
    }
}