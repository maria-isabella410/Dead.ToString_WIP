using rpgJogador;
using rpgJogo;
using rpgNpc;
using rpgMissao;
using rpgValidacaoInput;
using rpgNpcsDoJogo;
using rpgGerenciadorMissoes;

namespace rpgMetodosDialogo;

public class MetodosDialogo
{
    private Jogador jogador;
    private Npc npc;
    private ValidacaoInput validacaoInput = new ValidacaoInput();
    private GerenciadorMissoes gerenciadorMissoes;

    public MetodosDialogo(Jogador jogador, Npc npc)
    {
        this.jogador = jogador;
        this.npc = npc;

        gerenciadorMissoes = new GerenciadorMissoes(jogador);
    }
    public Boolean DialogoComCachorro()
    {
        Console.WriteLine("Cachorro:\n— Auau!!");

        Console.WriteLine("\n[1] Pegar Billy no colo");
        Console.WriteLine("[0] Voltar");

        int respostaPegarBilly = validacaoInput.OpcaoValidada(1);

        if(respostaPegarBilly == 0) return false;

        Console.WriteLine("Billy fica feliz ao estar no seu colo.");

        jogador.BillyEncontrado = true;

        return true;
    }
    public void DialogoComNpc()
    {
        if (npc.MissaoJaFoiConcluida && npc.Dialogo.MissaoConcluida != null)
        {
            Console.WriteLine($"{npc.Nome}: ");
            Console.WriteLine($"— {npc.Dialogo.MissaoConcluida}");

            Console.WriteLine("\n[0] Voltar");

            int escolhaMissaoConcluida = validacaoInput.OpcaoValidada(0);

            return;
        }

        Boolean ehCrianca = npc.Nome == NpcsDoJogo.CriaCrianca().Nome;

        Console.WriteLine(npc.DisseQuemEra ? npc.Nome : "Pessoa desconhecida: ");
        Console.Write(npc.DisseQuemEra ? "— Ah, é você de novo!" : $"— {npc.Dialogo.Saudacao}");

        Boolean encerrarConversa = false;
        
        while (true)
        {
            Console.WriteLine("\n");

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
                    if(PrecisaDeAjuda(false, ehCrianca))
                    {
                        npc.OfereceuMissao = true;

                        encerrarConversa = true;
                    } 
                });

                indice++;
            }

            if (npc.OfereceuMissao && !npc.AceitouMissao)
            {
                Console.WriteLine($"[{indice}] Ainda precisa de ajuda?");

                acoesDisponiveis.Add(() =>
                {
                    if(PrecisaDeAjuda(true, ehCrianca)) encerrarConversa = true; 
                });

                indice++;
            }

            if (npc.AceitouMissao && !ehCrianca)
            {
                Console.WriteLine($"[{indice}] Estou trabalhando no que você pediu.");

                acoesDisponiveis.Add(() => 
                {
                    Console.WriteLine($"{jogador.Nome}:\n— Estou trabalhando no que você pediu.");
                    Console.Write($"\n{npc.Nome}:\n— Ok, estou esperando...");
                });

                indice++;
            }

            if (npc.AceitouMissao && !ehCrianca)
            {
                Console.WriteLine($"[{indice}] Desculpe, não posso mais te ajudar.");

                acoesDisponiveis.Add(() => 
                {
                    Console.WriteLine($"{jogador.Nome}:\n— Desculpe, não posso mais te ajudar.");
                    Console.Write($"\n{npc.Nome}:\n— Ah, certo...");

                    npc.AceitouMissao = false;

                    jogador.MissaoAtual = null;
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

            if (Missao.MissaoConcluida(jogador) && !ehCrianca)
            {
                Console.WriteLine($"[{indice}] Conclui a missão.");

                acoesDisponiveis.Add(() =>
                {
                    Console.WriteLine($"{jogador.Nome}:\n— Conclui o que eu estava fazendo.");

                    if (npc.Dialogo.AgradecimentoMissao != null)
                    {
                        Console.WriteLine($"{npc.Nome}:\n— {npc.Dialogo.AgradecimentoMissao.Replace("{nome}", jogador.Nome)}");
                    }

                    Boolean ehPossivelAtualizarMissao = gerenciadorMissoes.AtualizarMissao();

                    if (ehPossivelAtualizarMissao)
                    {
                        if (npc.Missao?.Id == IdMissao.Policial)
                        {
                            var salaArmas = jogador.LocalAtual.Salas.FirstOrDefault(sala => sala.Nome.Equals("Sala de armas", StringComparison.OrdinalIgnoreCase));

                            if (salaArmas?.PortaTrancada != null)
                            {
                                salaArmas.PortaTrancada.Aberta = true;

                                Console.WriteLine("\nA porta da Sala de armas agora está aberta!");
                            }
                        }

                        npc.MissaoJaFoiConcluida = true;
                    }
                });        
            }

            Console.WriteLine("[0] Sair da conversa");

            int escolhaDialogo = validacaoInput.OpcaoValidada(acoesDisponiveis.Count);

            if(escolhaDialogo == 0) return;

            acoesDisponiveis[escolhaDialogo - 1].Invoke();

            if (npc.MissaoJaFoiConcluida || encerrarConversa) return;
        }
    }

    public Boolean QuemEvoce(Boolean ehCrianca)
    {
        Console.WriteLine($"{jogador.Nome}:");
        Console.WriteLine(ehCrianca ? "— Calma! Quem é você?" : "— Quem é você?");

        Console.WriteLine("\nPessoa desconhecida:");
        Console.WriteLine($"— {npc.Dialogo.Cumprimento}");

        Console.WriteLine("\n[1] Me chamo...");
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
            Console.Write("— " + npc.Dialogo.Introducao.Replace("{nome}", jogador.Nome ));
        }

        return true;
    }
    public void OqueAconteceu(Boolean JaPerguntado)
    {
        if(npc.Dialogo.Historia == null) return;

        Console.WriteLine($"{jogador.Nome}:");
        Console.WriteLine(JaPerguntado ? "— Pode me lembrar o que aconteceu?" : "— O que aconteceu?");

        Console.WriteLine("\n" + npc.Nome);
        Console.Write("— " + npc.Dialogo.Historia);

        if(npc.Dialogo.HistoriaContinuacao != null)
        {
            Console.WriteLine("\n[1] Não sei se confio no que você diz.");
            Console.WriteLine("[0] Voltar");

            int escolhaResponderConfianca = validacaoInput.OpcaoValidada(1);

            if(escolhaResponderConfianca == 0) return;

            Console.WriteLine($"{jogador.Nome}:");
            Console.WriteLine("— Não sei se confio no que você diz.");

            Console.WriteLine("\n" + npc.Nome);
            Console.WriteLine("— " + npc.Dialogo.HistoriaContinuacao);         
        }
    }
      
    public Boolean PrecisaDeAjuda(Boolean JaPerguntado, Boolean ehCrianca)
    {
        if(npc.Dialogo.Missao == null) return false;

        Console.WriteLine($"{jogador.Nome}:");
        Console.WriteLine(JaPerguntado ? "— Do que você precisa mesmo?" : "— Precisa de ajuda?");       

        Console.WriteLine("\n" + npc.Nome);
        Console.WriteLine("— " + npc.Dialogo.Missao);

        Console.WriteLine("\n[1] Certo, posso ajudar.");
        Console.WriteLine("[2] Desculpa, não posso ajudar.");
        Console.WriteLine("[0] Voltar");

        switch (validacaoInput.OpcaoValidada(2))
        {
            case 1: return AceitarMissao(ehCrianca);
            case 2: return RecusarMissao();
            default: return false;
        }
    }

    public Boolean AceitarMissao(Boolean ehCrianca)
    {   
        if(!ehCrianca && npc.Missao == null) return false; 
                
        if(!ehCrianca && jogador.MissaoAtual != null)
        {
            Console.WriteLine("Você não pode aceitar outra missão enquanto a atual ainda não foi concluída.");

            return false;
        }

        Console.WriteLine($"{jogador.Nome}:");
        Console.WriteLine("— Certo, posso ajudar.");

        if(npc.Dialogo.DespedidaMissaoAceitada != null)
        {
            Console.WriteLine("\n" + npc.Nome);
            Console.Write("— " + npc.Dialogo.DespedidaMissaoAceitada.Replace("{nome}", jogador.Nome));
        }
        
        if(npc.Missao != null)
        {
            jogador.MissaoAtual = npc.Missao;
            
            npc.AceitouMissao = true;

            Missao.MissaoAceita(jogador);            
        }

        if (ehCrianca)
        {
            jogador.MaryEncontrada = true;
        }

        return true;
    }
    public Boolean RecusarMissao()
    {
        Console.WriteLine($"{jogador.Nome}:");
        Console.WriteLine("— Desculpa, não posso ajudar.");

        Console.WriteLine("\n" + npc.Nome);
        Console.Write("— " + npc.Dialogo.DespedidaMissaoRecusada);  

        return true;
    }
}