using rpgJogador;
using rpgJogo;
using rpgNpc;
using rpgMissao;

namespace rpgMetodosDialogo;

public class MetodosDialogo
{
    public void DialogoComNpc(Jogador Jogador, Npc Npc, Boolean PrimeiraVezConversando)
    {
        if (PrimeiraVezConversando)
        {
            Console.WriteLine("\nPessoa desconhecida: ");
            Console.WriteLine("— " + Npc.Dialogo.Saudacao);
        }
        else
        {
            Console.WriteLine("\n" + Npc.Nome);
            Console.WriteLine("— Ah, é você de novo!");
        }

        //preciso arrumar

        while (true)
        {
            if (!Npc.DisseQuemEra)
            {
                while (true)
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

                    Npc.DisseQuemEra = true;       

                    break;                            
                }
    
            }

            if (!Npc.ContouOqAconteceu)
            {
                while (true)
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

                    OqueAconteceu(Jogador, Npc, Npc.ContouOqAconteceu); 

                    Npc.ContouOqAconteceu = true;  

                    break;                        
                }

            }
            else
            {
                while (true)
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

                    OqueAconteceu(Jogador, Npc, Npc.ContouOqAconteceu); 

                    break; 
                }

            }

            if (!Npc.OfereceuMissao)
            {
                while (true)
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

                    PrecisaDeAjuda(Jogador, Npc, Npc.OfereceuMissao); 

                    Npc.OfereceuMissao = true;                  

                    break;
                }
                
            }
            else
            {
                while (true)
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

                    PrecisaDeAjuda(Jogador, Npc, Npc.OfereceuMissao); 

                    break;
                }
                
            }

            if(Npc.DisseQuemEra && Npc.ContouOqAconteceu && Npc.OfereceuMissao)
            {
                Jogador.NpcsConhecidos.Add(Npc);
            }

            if (Npc.OfereceuMissao && !Jogador.AceitouMissao)
            {
                while (true)
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

                    PrecisaDeAjuda(Jogador, Npc, Npc.OfereceuMissao);  

                    break;
                }                    
            }

            if (Npc.OfereceuMissao && Jogador.AceitouMissao)
            {
                while (true)
                {
                    Console.WriteLine("\n" + Npc.Nome);
                    Console.WriteLine("— Estou esperando...");

                    Console.WriteLine("\n[1] Estou trabalhando nisso.");
                    Console.WriteLine("[0] Voltar");
                    Jogo.DivisaoDeLinha();
                    Console.Write("--> ");

                    int respondeAguardo = Convert.ToInt32(Console.ReadLine());

                    if(respondeAguardo == 0) return;

                    if(respondeAguardo != 1)
                    {
                        Console.WriteLine("\nEntrada inválida!");

                        continue;
                    }

                    Console.WriteLine($"\n{Jogador.Nome}:");
                    Console.WriteLine("— Estou trabalhando nisso."); 

                    break;
                }                    
            }
                
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
                    while (true)
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
                Console.WriteLine("— " + Npc.Dialogo.Historia);

                if(Npc.Dialogo.HistoriaContinuacao != null)
                {
                    while (true)
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

                        break;
                    }
                }         

                break;       
            }
        }
    }
}