using rpgJogador;
using rpgJogo;
using rpgNpc;
using rpgTopicoDialogo;
using rpgMissao;
using rpgNpc;
using rpgDialogoOpcao;

namespace rpgMetodosDialogo;

public class MetodosDialogo
{
    public void DialogoComNpc(Jogador Jogador, Npc Npc, Boolean PrimeiraVezConversando)
    {
        Boolean disse_quem_era = false;
        Boolean contou_oq_aconteceu = false;
        Boolean ofereceu_missao = false;
        Boolean aceitou_missao = false;

        if (PrimeiraVezConversando)
        {
            Console.WriteLine("\nPessoa desconhecida: ");
            Console.WriteLine("— " + Npc.Dialogo.Saudacao);

            while (true)
            {
                if (!disse_quem_era)
                {
                    Console.WriteLine("\n[1] Quem é você?");
                    Console.WriteLine("[0] Voltar");
                    Jogo.DivisaoDeLinha();
                    Console.Write("--> ");

                    int opcao = Convert.ToInt32(Console.ReadLine());

                    if(opcao == 0) return;

                    if(opcao != 1)
                    {
                        Console.WriteLine("\nEntrada inválida!");

                        continue;
                    }

                    QuemEvoce(Jogador, Npc); 

                    disse_quem_era = true;                 
                }

                if (!contou_oq_aconteceu)
                {
                    Console.WriteLine("\n[1] O que aconteceu?");
                    Console.WriteLine("[0] Voltar");
                    Jogo.DivisaoDeLinha();
                    Console.Write("--> ");

                    int opcao = Convert.ToInt32(Console.ReadLine());

                    if(opcao == 0) return;

                    if(opcao != 1)
                    {
                        Console.WriteLine("\nEntrada inválida!");

                        continue;
                    }

                    OqueAconteceu(Jogador, Npc, contou_oq_aconteceu); 

                    contou_oq_aconteceu = true;  
                }
                else
                {
                    Console.WriteLine("\n[1] Pode me lembrar o que aconteceu?");
                    Console.WriteLine("[0] Voltar");
                    Jogo.DivisaoDeLinha();
                    Console.Write("--> ");

                    int opcao = Convert.ToInt32(Console.ReadLine());

                    if(opcao == 0) return;

                    if(opcao != 1)
                    {
                        Console.WriteLine("\nEntrada inválida!");

                        continue;
                    }

                    OqueAconteceu(Jogador, Npc, contou_oq_aconteceu); 
                }

                if (!ofereceu_missao)
                {
                    Console.WriteLine("\n[1] Precisa de ajuda?");
                    Console.WriteLine("[0] Voltar");
                    Jogo.DivisaoDeLinha();
                    Console.Write("--> ");

                    int opcao = Convert.ToInt32(Console.ReadLine());

                    if(opcao == 0) return;

                    if(opcao != 1)
                    {
                        Console.WriteLine("\nEntrada inválida!");

                        continue;
                    }

                    PrecisaDeAjuda(Jogador, Npc, ofereceu_missao); 

                    contou_oq_aconteceu = true;                  
                }
                else
                {
                    Console.WriteLine("\n[1] Do que você precisa mesmo?");
                    Console.WriteLine("[0] Voltar");
                    Jogo.DivisaoDeLinha();
                    Console.Write("--> ");

                    int opcao = Convert.ToInt32(Console.ReadLine());

                    if(opcao == 0) return;

                    if(opcao != 1)
                    {
                        Console.WriteLine("\nEntrada inválida!");

                        continue;
                    }

                    PrecisaDeAjuda(Jogador, Npc, ofereceu_missao); 
                }

                if (ofereceu_missao && !aceitou_missao)
                {
                    
                }

                if (ofereceu_missao && aceitou_missao)
                {
                    
                }
                    
            }

        }
        else
        {
            
        }

        
    }
    public void QuemEvoce(Jogador Jogador, Npc Npc)
    {
        while (true)
        {
            Console.WriteLine($"\n{Jogador.Nome}:");
            Console.WriteLine("— Quem é você?");

            Console.WriteLine("\nPessoa desconhecida:");
            Console.WriteLine("— " + Npc.Dialogo.Cumprimento);

            Console.WriteLine("\n[1] Me chamo...");
            Console.WriteLine("[0] Voltar");
            Jogo.DivisaoDeLinha();
            Console.Write("--> ");

            int respondeNome = Convert.ToInt32(Console.ReadLine());

            if(respondeNome == 0) return;

            if(respondeNome != 1)
            {
                Console.WriteLine("\nEntrada inválida!");

                continue;
            }

            Console.WriteLine($"\n{Jogador.Nome}:");
            Console.WriteLine($"\n— Me chamo {Jogador.Nome}.");

            if(Npc.Dialogo.Introducao != null)
            {
                Console.WriteLine("\n" + Npc.Nome);
                Console.WriteLine("— " + Npc.Dialogo.Introducao.Replace("{nome}", Jogador.Nome));
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
                Console.WriteLine("— " + Npc.Dialogo.Historia);

                if(Npc.Dialogo.HistoriaContinuacao != null)
                {
                    Console.WriteLine("\n[1] Não sei se confio no que você diz.");
                    Console.WriteLine("[0] Voltar");
                    Jogo.DivisaoDeLinha();
                    Console.Write("--> ");

                    int respondeNaoConfia = Convert.ToInt32(Console.ReadLine());

                    if(respondeNaoConfia == 0)
                    {
                        return;
                    }

                    if(respondeNaoConfia != 1)
                    {
                        Console.WriteLine("\nEntrada inválida!");

                        continue;
                    }

                    Console.WriteLine($"\n{Jogador.Nome}:");
                    Console.WriteLine("— Não sei se confio no que você diz.");

                    Console.WriteLine("\n" + Npc.Nome);
                    Console.WriteLine("— " + Npc.Dialogo.HistoriaContinuacao);
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
                Console.WriteLine("— " + Npc.Dialogo.Historia);

                if(Npc.Dialogo.HistoriaContinuacao != null)
                {
                    Console.WriteLine("\n[1] Ainda não sei se confio no que você diz.");
                    Console.WriteLine("[0] Voltar");
                    Jogo.DivisaoDeLinha();
                    Console.Write("--> ");

                    int respondeNaoConfia = Convert.ToInt32(Console.ReadLine());

                    if(respondeNaoConfia == 0)
                    {
                        return;
                    }

                    if(respondeNaoConfia != 1)
                    {
                        Console.WriteLine("\nEntrada inválida!");

                        continue;
                    }

                    Console.WriteLine($"\n{Jogador.Nome}:");
                    Console.WriteLine("— Ainda não sei se confio no que você diz.");

                    Console.WriteLine("\n" + Npc.Nome);
                    Console.WriteLine("— " + Npc.Dialogo.HistoriaContinuacao);
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
                    Console.WriteLine("\n" + Npc.Nome);
                    Console.WriteLine("— " + Npc.Dialogo.Missao);

                    Console.WriteLine("\n[1] Certo, posso ajudar.");
                    Console.WriteLine("[2] Desculpa, não posso ajudar.");
                    Console.WriteLine("[0] Voltar");
                    Jogo.DivisaoDeLinha();
                    Console.Write("--> ");

                    int respondeMissao = Convert.ToInt32(Console.ReadLine());

                    if(respondeMissao == 0)
                    {
                        return;
                    }

                    if(respondeMissao < 1 || respondeMissao > 2)
                    {
                        Console.WriteLine("\nEntrada inválida!");

                        continue;
                    }

                    switch (respondeMissao)
                    {
                        case 1:
                            if(Jogador.MissaoAtual == null)
                            {
                                Console.WriteLine($"\n{Jogador.Nome}:");
                                Console.WriteLine("— Certo, posso ajudar.");

                                Console.WriteLine("\n" + Npc.Nome);
                                Console.WriteLine("— " + Npc.Dialogo.DespedidaMissaoAceitada.Replace("{nome}", Jogador.Nome));

                                Jogador.MissaoAtual = Npc.Missao;

                                Missao.MissaoAceita(Jogador);                        
                            }
                            else
                            {
                                Console.WriteLine("Você não pode aceitar outra missão enquanto a atual ainda não foi concluída.");

                                break;
                            }

                        break;
                        case 2:
                            Console.WriteLine($"\n{Jogador.Nome}:");
                            Console.WriteLine("— Desculpa, não posso ajudar.");

                            Console.WriteLine("\n" + Npc.Nome);
                            Console.WriteLine("— " + Npc.Dialogo.DespedidaMissaoRecusada);                    
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
                    Console.WriteLine("\n" + Npc.Nome);
                    Console.WriteLine("— " + Npc.Dialogo.Missao);

                    Console.WriteLine("\n[1] Certo, posso ajudar.");
                    Console.WriteLine("[2] Desculpa, não posso ajudar.");
                    Console.WriteLine("[0] Voltar");
                    Jogo.DivisaoDeLinha();
                    Console.Write("--> ");

                    int respondeMissao = Convert.ToInt32(Console.ReadLine());

                    if(respondeMissao == 0)
                    {
                        return;
                    }

                    if(respondeMissao < 1 || respondeMissao > 2)
                    {
                        Console.WriteLine("\nEntrada inválida!");

                        continue;
                    }

                    switch (respondeMissao)
                    {
                        case 1:
                            if(Jogador.MissaoAtual == null)
                            {
                                Console.WriteLine($"\n{Jogador.Nome}:");
                                Console.WriteLine("— Certo, posso ajudar.");

                                Console.WriteLine("\n" + Npc.Nome);
                                Console.WriteLine("— " + Npc.Dialogo.DespedidaMissaoAceitada.Replace("{nome}", Jogador.Nome));

                                Jogador.MissaoAtual = Npc.Missao;

                                Missao.MissaoAceita(Jogador);                        
                            }
                            else
                            {
                                Console.WriteLine("Você não pode aceitar outra missão enquanto a atual ainda não foi concluída.");

                                break;
                            }

                        break;
                        case 2:
                            Console.WriteLine($"\n{Jogador.Nome}:");
                            Console.WriteLine("— Desculpa, não posso ajudar.");

                            Console.WriteLine("\n" + Npc.Nome);
                            Console.WriteLine("— " + Npc.Dialogo.DespedidaMissaoRecusada);                    
                        break;
                    }
                }         

                break;       
            }
        }
        
      
    }
    // public void ContinuarDialogo(Npc npc)
    // {
    //     if(ContadorDialogo != 0) return;

    //     if (npc.ConversouTudo && !Missao.MissaoValida(Jogador))
    //     {
    //         ConheceNpc(Jogador, npc);
    //         Console.WriteLine("\nEstou esperando...");
    //     } else if(npc.ConversouTudo && Missao.MissaoValida(Jogador))
    //     {
    //         ConheceNpc(Jogador, npc);
    //         Console.WriteLine(npc.Dialogo.MissaoConcluida.Replace("{nome}", Jogador.Nome));

    //         //arrumar dps
    //     }
    // }
}