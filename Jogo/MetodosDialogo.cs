using rpgJogador;
using rpgJogo;
using rpgNpc;
using rpgMissao;
using rpgValidacaoInput;

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
    public void DialogoComNpc()
    {
        if (!npc.DisseQuemEra)
        {
            Console.WriteLine("\nPessoa desconhecida: ");
            Console.WriteLine("— " + npc.Dialogo.Saudacao);
        }
        else
        {
            Console.WriteLine("\n" + npc.Nome);
            Console.WriteLine("— Ah, é você de novo!");
        }
        
        while (true)
        {
            List<Action> acoesDisponiveis = new List<Action>();
            int indice = 1;

            if (!npc.DisseQuemEra)
            {
                Console.WriteLine($"\n[{indice}] Quem é você?");

                acoesDisponiveis.Add(() =>
                {
                    QuemEvoce();

                    npc.DisseQuemEra = true; 
                });

                indice++;
    
            }

            if (npc.DisseQuemEra && !npc.ContouOqAconteceu)
            {
                Console.WriteLine("\n[1] O que aconteceu?");

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
                    PrecisaDeAjuda(false);

                    npc.OfereceuMissao = true;
                });

                indice++;
            }
            else if (npc.OfereceuMissao && !npc.AceitouMissao)
            {
                Console.WriteLine($"[{indice}] Ainda precisa de ajuda?");

                acoesDisponiveis.Add(() =>
                {
                    PrecisaDeAjuda(true);
                });

                indice++;
            }

            else if (npc.AceitouMissao)
            {
                Console.WriteLine($"[{indice}] Estou trabalhando na missão.");

                acoesDisponiveis.Add(() => 
                {
                    Console.WriteLine($"\n{jogador.Nome}:\n— Estou trabalhando nisso.");
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

            Console.WriteLine("[0] Sair da conversa");

            int escolha = -1;

            while (true)
            {
                Console.Write("--> ");
                string input = Console.ReadLine() ?? "";

                if(int.TryParse(input, out escolha))
                {
                    if (escolha == 0) return;

                    int indiceReal = escolha - 1;

                    if(indiceReal >= 0 && indiceReal < acoesDisponiveis.Count)
                    {
                        break;
                    }
                }

                Console.WriteLine("\nEntrada inválida! Tente novamente.");
            }

            acoesDisponiveis[escolha - 1].Invoke();
                
        }

    }

    public void QuemEvoce()
    {
        Console.WriteLine($"\n{jogador.Nome}:");
        Console.WriteLine("— Quem é você?");

        Console.WriteLine("\nPessoa desconhecida:");
        Console.WriteLine("— " + npc.Dialogo.Cumprimento + "\n");

        Console.WriteLine("[1] Me chamo...");
        Console.WriteLine("[0] Voltar");

        int escolhaResponderNome = validacaoInput.OpcaoValidada(1);
        
        if(escolhaResponderNome == 0)
        {
            return;
        }
        Console.WriteLine($"\n{jogador.Nome}:");
        Console.WriteLine($"— Me chamo {jogador.Nome}.");

        if(npc.Dialogo.Introducao != null)
        {
            Console.WriteLine("\n" + npc.Nome);
            Console.WriteLine("— " + npc.Dialogo.Introducao.Replace("{nome}", jogador.Nome + "\n"));
        }          
    }
    public void OqueAconteceu(Boolean JaPerguntado)
    {
        if (!JaPerguntado)
        {
            Console.WriteLine($"\n{jogador.Nome}:");
            Console.WriteLine("— O que aconteceu?");

            Console.WriteLine("\n" + npc.Nome);
            Console.WriteLine("— " + npc.Dialogo.Historia + "\n");

            if(npc.Dialogo.HistoriaContinuacao != null)
            {
                Console.WriteLine("[1] Não sei se confio no que você diz.");
                Console.WriteLine("[0] Voltar");

                int escolhaResponderConfianca = validacaoInput.OpcaoValidada(1);

                if(escolhaResponderConfianca == 0)
                {
                    return;
                }

                Console.WriteLine($"\n{jogador.Nome}:");
                Console.WriteLine("— Não sei se confio no que você diz.");

                Console.WriteLine("\n" + npc.Nome);
                Console.WriteLine("— " + npc.Dialogo.HistoriaContinuacao + "\n");                            
            }            
        }
        else
        {
            Console.WriteLine($"\n{jogador.Nome}:");
            Console.WriteLine("— Pode me lembrar o que aconteceu?");

            Console.WriteLine("\n" + npc.Nome);
            Console.WriteLine("— " + npc.Dialogo.Historia + "\n");

            if(npc.Dialogo.HistoriaContinuacao != null)
            {
                    Console.WriteLine("[1] Ainda não sei se confio no que você diz.");
                    Console.WriteLine("[0] Voltar");

                    int escolhaResponderConfianca2 = validacaoInput.OpcaoValidada(1);

                    if(escolhaResponderConfianca2 == 0)
                    {
                        return;                          
                    }

                    Console.WriteLine($"\n{jogador.Nome}:");
                    Console.WriteLine("— Ainda não sei se confio no que você diz.");

                    Console.WriteLine("\n" + npc.Nome);
                    Console.WriteLine("— " + npc.Dialogo.HistoriaContinuacao + "\n");  

            }             
        } 
    }
      
    public void PrecisaDeAjuda(Boolean JaPerguntado)
    {
        if (!JaPerguntado)
        {
            while (true)
            {
                Console.WriteLine($"\n{jogador.Nome}:");
                Console.WriteLine("— Precisa de ajuda?");

                if(npc.Dialogo.Missao != null)
                {
                    while (true)
                    {
                        Console.WriteLine("\n" + npc.Nome);
                        Console.WriteLine("— " + npc.Dialogo.Missao + "\n");

                        Console.WriteLine("[1] Certo, posso ajudar.");
                        Console.WriteLine("[2] Desculpa, não posso ajudar.");
                        Console.WriteLine("[0] Voltar");

                        int escolherAjudar = validacaoInput.OpcaoValidada(2);

                        if(escolherAjudar == 0)
                        {
                            return;
                        }
                        else
                        {
                            switch (escolherAjudar)
                            {
                                case 1:
                                    if(jogador.MissaoAtual == null)
                                    {
                                        Console.WriteLine($"\n{jogador.Nome}:");
                                        Console.WriteLine("— Certo, posso ajudar.");

                                        if(npc.Dialogo.DespedidaMissaoAceitada != null)
                                        {
                                            Console.WriteLine("\n" + npc.Nome);
                                            Console.WriteLine("— " + npc.Dialogo.DespedidaMissaoAceitada.Replace("{nome}", jogador.Nome) + "\n");

                                            jogador.MissaoAtual = npc.Missao;

                                            Missao.MissaoAceita(jogador);
                                        }
                                                                
                                    }
                                    else
                                    {
                                        Console.WriteLine("Você não pode aceitar outra missão enquanto a atual ainda não foi concluída.\n");

                                        break;
                                    }

                                break;
                                case 2:
                                    Console.WriteLine($"\n{jogador.Nome}:");
                                    Console.WriteLine("— Desculpa, não posso ajudar.");

                                    Console.WriteLine("\n" + npc.Nome);
                                    Console.WriteLine("— " + npc.Dialogo.DespedidaMissaoRecusada + "\n");                    
                                break;
                            }                            
                        }

                        break;                        
                    }

                }         

                break;       
            }            
        }
        else
        {
            while (true)
            {
                Console.WriteLine($"\n{jogador.Nome}:");
                Console.WriteLine("— Do que você precisa mesmo?");

                if(npc.Dialogo.Missao != null)
                {
                    while (true)
                    {
                        Console.WriteLine("\n" + npc.Nome);
                        Console.WriteLine("— " + npc.Dialogo.Missao + "\n");

                        Console.WriteLine("[1] Certo, posso ajudar.");
                        Console.WriteLine("[2] Desculpa, não posso ajudar.");
                        Console.WriteLine("[0] Voltar");
                        
                        int escolherAjudarDenovo = validacaoInput.OpcaoValidada(2);

                        if(escolherAjudarDenovo == 0)
                        {
                            return;
                        }

                        switch (escolherAjudarDenovo)
                        {
                            case 1:
                                if(jogador.MissaoAtual == null)
                                {
                                    Console.WriteLine($"\n{jogador.Nome}:");
                                    Console.WriteLine("— Certo, posso ajudar.");

                                    if(npc.Dialogo.DespedidaMissaoAceitada != null)
                                    {
                                        Console.WriteLine("\n" + npc.Nome);
                                        Console.WriteLine("— " + npc.Dialogo.DespedidaMissaoAceitada.Replace("{nome}", jogador.Nome) + "\n");

                                        jogador.MissaoAtual = npc.Missao;

                                        Missao.MissaoAceita(jogador);  
                                    }                                                          
                                }
                                else
                                {
                                    Console.WriteLine("Você não pode aceitar outra missão enquanto a atual ainda não foi concluída.\n");

                                    break;
                                }

                            break;
                            case 2:
                                Console.WriteLine($"\n{jogador.Nome}:");
                                Console.WriteLine("— Desculpa, não posso ajudar.");

                                Console.WriteLine("\n" + npc.Nome);
                                Console.WriteLine("— " + npc.Dialogo.DespedidaMissaoRecusada + "\n");                    
                            break;
                        }

                        break;
                    }
                }         

                break;       
            }
        }
    }
}