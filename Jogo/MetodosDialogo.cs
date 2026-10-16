using rpgJogador;
using rpgJogo;
using rpgNpc;
using rpgMissao;

namespace rpgMetodosDialogo;

public class MetodosDialogo
{
    public void DialogoComNpc(Jogador Jogador, Npc Npc)
    {
        if (!Npc.DisseQuemEra)
        {
            Console.WriteLine("\nPessoa desconhecida: ");
            Console.WriteLine("— " + Npc.Dialogo.Saudacao);
        }
        else
        {
            Console.WriteLine("\n" + Npc.Nome);
            Console.WriteLine("— Ah, é você de novo!");
        }
        
        while (true)
        {
            List<Action> acoesDisponiveis = new List<Action>();
            int indice = 1;

            if (!Npc.DisseQuemEra)
            {
                Console.WriteLine($"\n[{indice}] Quem é você?");

                acoesDisponiveis.Add(() =>
                {
                    QuemEvoce(Jogador, Npc);

                    Npc.DisseQuemEra = true; 
                });

                indice++;
    
            }

            if (Npc.DisseQuemEra && !Npc.ContouOqAconteceu)
            {
                Console.WriteLine("\n[1] O que aconteceu?");

                acoesDisponiveis.Add(() =>
                {
                    OqueAconteceu(Jogador, Npc, false); 

                    Npc.ContouOqAconteceu = true;                      
                }); 

                indice++;

            }
            else if (Npc.ContouOqAconteceu)
            {
                Console.WriteLine($"[{indice}] Pode me lembrar o que aconteceu?");

                acoesDisponiveis.Add(() =>
                {
                    OqueAconteceu(Jogador, Npc, true);
                });

                indice++;
            }

            if (Npc.ContouOqAconteceu && !Npc.OfereceuMissao)
            {
                Console.WriteLine($"[{indice}] Precisa de ajuda?");

                acoesDisponiveis.Add(() =>
                {
                    PrecisaDeAjuda(Jogador, Npc, false);

                    Npc.OfereceuMissao = true;
                });

                indice++;
            }
            else if (Npc.OfereceuMissao && !Npc.AceitouMissao)
            {
                Console.WriteLine($"[{indice}] Ainda precisa de ajuda?");

                acoesDisponiveis.Add(() =>
                {
                    PrecisaDeAjuda(Jogador, Npc, true);
                });

                indice++;
            }

            else if (Npc.AceitouMissao)
            {
                Console.WriteLine($"[{indice}] Estou trabalhando na missão.");

                acoesDisponiveis.Add(() => 
                {
                    Console.WriteLine($"\n{Jogador.Nome}:\n— Estou trabalhando nisso.");
                });

                indice++;
            }
            if (Npc.DisseQuemEra && Npc.ContouOqAconteceu && Npc.OfereceuMissao)
            {
                if (!Jogador.NpcsConhecidos.Contains(Npc))
                {
                    Jogador.NpcsConhecidos.Add(Npc);
                }
            }

            Console.WriteLine("[0] Sair da conversa");
            Jogo.DivisaoDeLinha();

            int escolha = -1;

            while (true)
            {
                Console.Write("--> ");
                string input = Console.ReadLine();

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

    private int ValidarInput(int qtdOpcoes)
    {
        int escolha = -1;

            while (true)
            {
                Console.Write("--> ");
                string input = Console.ReadLine();

                if(int.TryParse(input, out escolha))
                {
                    if(escolha == 0) return 0;

                    if(escolha <= qtdOpcoes)
                    {
                        int resposta = escolha - 1;

                        return resposta;
                    }                    

                }

                Console.WriteLine("\nEntrada inválida! Tente novamente.");
            }
    }

    public void QuemEvoce(Jogador Jogador, Npc Npc)
    {
        while (true)
        {
            Console.WriteLine($"\n{Jogador.Nome}:");
            Console.WriteLine("— Quem é você?");

            Console.WriteLine("\nPessoa desconhecida:");
            Console.WriteLine("— " + Npc.Dialogo.Cumprimento + "\n");

            Console.WriteLine("[1] Me chamo...");
            Console.WriteLine("[0] Voltar");
            Jogo.DivisaoDeLinha();
            
            if(ValidarInput(1) == 0)
            {
                return;
            }
            else
            {
                Console.WriteLine($"\n{Jogador.Nome}:");
                Console.WriteLine($"— Me chamo {Jogador.Nome}.");

                if(Npc.Dialogo.Introducao != null)
                {
                    Console.WriteLine("\n" + Npc.Nome);
                    Console.WriteLine("— " + Npc.Dialogo.Introducao.Replace("{nome}", Jogador.Nome + "\n"));
                }   
            }

            break;           
        }

    }
    public void OqueAconteceu(Jogador Jogador, Npc Npc, Boolean JaPerguntado)
    {
        if (!JaPerguntado)
        {
            while (true)
            {
                Console.WriteLine($"\n{Jogador.Nome}:");
                Console.WriteLine("— O que aconteceu?");

                Console.WriteLine("\n" + Npc.Nome);
                Console.WriteLine("— " + Npc.Dialogo.Historia + "\n");

                if(Npc.Dialogo.HistoriaContinuacao != null)
                {
                    while (true)
                    {
                        Console.WriteLine("[1] Não sei se confio no que você diz.");
                        Console.WriteLine("[0] Voltar");
                        Jogo.DivisaoDeLinha();

                        if(ValidarInput(1) == 0)
                        {
                            return;
                        }
                        else
                        {
                            Console.WriteLine($"\n{Jogador.Nome}:");
                            Console.WriteLine("— Não sei se confio no que você diz.");

                            Console.WriteLine("\n" + Npc.Nome);
                            Console.WriteLine("— " + Npc.Dialogo.HistoriaContinuacao + "\n");                            
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
                Console.WriteLine($"\n{Jogador.Nome}:");
                Console.WriteLine("— Pode me lembrar o que aconteceu?");

                Console.WriteLine("\n" + Npc.Nome);
                Console.WriteLine("— " + Npc.Dialogo.Historia + "\n");

                if(Npc.Dialogo.HistoriaContinuacao != null)
                {
                    while (true)
                    {
                        Console.WriteLine("[1] Ainda não sei se confio no que você diz.");
                        Console.WriteLine("[0] Voltar");
                        Jogo.DivisaoDeLinha();
                        
                        if(ValidarInput(1) == 0)
                        {
                            return;
                        }
                        else
                        {
                            Console.WriteLine($"\n{Jogador.Nome}:");
                            Console.WriteLine("— Ainda não sei se confio no que você diz.");

                            Console.WriteLine("\n" + Npc.Nome);
                            Console.WriteLine("— " + Npc.Dialogo.HistoriaContinuacao + "\n");                            
                        }

                        break;                        
                    }

                }
                
                break;             
            } 
        }
    
      
    }
    public void PrecisaDeAjuda(Jogador Jogador, Npc Npc, Boolean JaPerguntado)
    {
        if (!JaPerguntado)
        {
            while (true)
            {
                Console.WriteLine($"\n{Jogador.Nome}:");
                Console.WriteLine("— Precisa de ajuda?");

                if(Npc.Dialogo.Missao != null)
                {
                    while (true)
                    {
                        Console.WriteLine("\n" + Npc.Nome);
                        Console.WriteLine("— " + Npc.Dialogo.Missao + "\n");

                        Console.WriteLine("[1] Certo, posso ajudar.");
                        Console.WriteLine("[2] Desculpa, não posso ajudar.");
                        Console.WriteLine("[0] Voltar");
                        Jogo.DivisaoDeLinha();

                        int resposta = ValidarInput(2);

                        if(resposta == 0)
                        {
                            return;
                        }
                        else
                        {
                            switch (resposta)
                            {
                                case 1:
                                    if(Jogador.MissaoAtual == null)
                                    {
                                        Console.WriteLine($"\n{Jogador.Nome}:");
                                        Console.WriteLine("— Certo, posso ajudar.");

                                        Console.WriteLine("\n" + Npc.Nome);
                                        Console.WriteLine("— " + Npc.Dialogo.DespedidaMissaoAceitada.Replace("{nome}", Jogador.Nome) + "\n");

                                        Jogador.MissaoAtual = Npc.Missao;

                                        Missao.MissaoAceita(Jogador);                        
                                    }
                                    else
                                    {
                                        Console.WriteLine("Você não pode aceitar outra missão enquanto a atual ainda não foi concluída.\n");

                                        break;
                                    }

                                break;
                                case 2:
                                    Console.WriteLine($"\n{Jogador.Nome}:");
                                    Console.WriteLine("— Desculpa, não posso ajudar.");

                                    Console.WriteLine("\n" + Npc.Nome);
                                    Console.WriteLine("— " + Npc.Dialogo.DespedidaMissaoRecusada + "\n");                    
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
                Console.WriteLine($"\n{Jogador.Nome}:");
                Console.WriteLine("— Do que você precisa mesmo?");

                if(Npc.Dialogo.Missao != null)
                {
                    while (true)
                    {
                        Console.WriteLine("\n" + Npc.Nome);
                        Console.WriteLine("— " + Npc.Dialogo.Missao + "\n");

                        Console.WriteLine("[1] Certo, posso ajudar.");
                        Console.WriteLine("[2] Desculpa, não posso ajudar.");
                        Console.WriteLine("[0] Voltar");
                        Jogo.DivisaoDeLinha();
                        
                        int resposta = ValidarInput(2);

                        if(resposta == 0)
                        {
                            return;
                        }

                        switch (resposta)
                        {
                            case 1:
                                if(Jogador.MissaoAtual == null)
                                {
                                    Console.WriteLine($"\n{Jogador.Nome}:");
                                    Console.WriteLine("— Certo, posso ajudar.");

                                    Console.WriteLine("\n" + Npc.Nome);
                                    Console.WriteLine("— " + Npc.Dialogo.DespedidaMissaoAceitada.Replace("{nome}", Jogador.Nome) + "\n");

                                    Jogador.MissaoAtual = Npc.Missao;

                                    Missao.MissaoAceita(Jogador);                        
                                }
                                else
                                {
                                    Console.WriteLine("Você não pode aceitar outra missão enquanto a atual ainda não foi concluída.\n");

                                    break;
                                }

                            break;
                            case 2:
                                Console.WriteLine($"\n{Jogador.Nome}:");
                                Console.WriteLine("— Desculpa, não posso ajudar.");

                                Console.WriteLine("\n" + Npc.Nome);
                                Console.WriteLine("— " + Npc.Dialogo.DespedidaMissaoRecusada + "\n");                    
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