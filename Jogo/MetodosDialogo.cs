using rpgJogador;
using rpgJogo;
using rpgNpc;
using rpgTopicoDialogo;
using rpgMissao;
using rpgNpc;
using rpgDialogoOpcao;

namespace rpgMetodosDialogo;

public class MetodosDialogo
{    private Boolean Conversando {get; set;} = false;
    private Boolean ConheceNpc {get; set;} = false;

    private void NomeNpc(Jogador jogador, Npc npc)
    {
        if (ConheceNpc || jogador.NpcsConhecidos.Contains(npc))
        {
            Console.WriteLine($"\n{npc.Nome}:");
        }
        else
        {
            Console.WriteLine("\nPessoa desconhecida:");
        }
    }
    public void EscolherOpcao(Jogador Jogador, Npc Npc)
    {
        List<DialogoOpcao> dialogoopcoes = new List<DialogoOpcao>
        {
            new DialogoOpcao ("Quem é você?", () => QuemEvoce(Jogador, Npc)),
            new DialogoOpcao ("O que aconteceu?", () => OqueAconteceu(Jogador, Npc)),
            new DialogoOpcao ("Como posso ajudar?", () => ComoPossoAjudar(Jogador, Npc))
        };

        Console.WriteLine("Pessoa desconhecida: ");
        Console.WriteLine("— " + Npc.Dialogo.Saudacao + "\n");

        while (true)
        {
            for(int i = 0; i < dialogoopcoes.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {dialogoopcoes[i].Opcao}");
            }
            Console.WriteLine("[0] Voltar");
            Jogo.DivisaoDeLinha();
            Console.Write("--> ");

            int opcao = Convert.ToInt32(Console.ReadLine());

            if(opcao == 0)
            {
                return;
            }

            if(opcao < 1 || opcao > dialogoopcoes.Count)
            {
                Console.WriteLine("\nEntrada inválida!");

                continue;
            }

            int index = opcao - 1;

            dialogoopcoes[index].Action();

            dialogoopcoes.RemoveAt(index);

            if(dialogoopcoes.Count == 0)
            {
                break;     

                ConheceNpc = false;
            }
                   
        }

    }
    public void QuemEvoce(Jogador Jogador, Npc Npc)
    {
        while (true)
        {
            Console.WriteLine($"{Jogador.Nome}:");
            Console.WriteLine("— Quem é você?\n");

            NomeNpc(Jogador, Npc);
            Console.WriteLine(Npc.Dialogo.Cumprimento);

            ConheceNpc = true;

            Console.WriteLine("\n[1] Me chamo...");
            Jogo.DivisaoDeLinha();
            Console.Write("--> ");

            int respondeNome = Convert.ToInt32(Console.ReadLine());

            if(respondeNome == 0)
            {
                return; 
            }
            if(respondeNome != 1)
            {
                Console.WriteLine("\nEntrada inválida!");

                continue;
            }

            Console.WriteLine($"{Jogador.Nome}:");
            Console.WriteLine($"— Me chamo {Jogador.Nome}.\n");

            if(Npc.Dialogo.Introducao != null)
            {
                NomeNpc(Jogador, Npc);
                Console.WriteLine(Npc.Dialogo.Introducao.Replace("{nome}", Jogador.Nome));
            }  

            break;       
        }

    }
    public void OqueAconteceu(Jogador Jogador, Npc Npc)
    {
        while (true)
        {
            Console.WriteLine($"\n{Jogador.Nome}:");
            Console.WriteLine("— O que aconteceu?");

            NomeNpc(Jogador, Npc);
            Console.WriteLine("— " + Npc.Dialogo.Historia + "\n");

            if(Npc.Dialogo.HistoriaContinuacao != null)
            {
                Console.WriteLine("[1] Não sei se confio no que você diz.");
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

                NomeNpc(Jogador, Npc);
                Console.WriteLine("— " + Npc.Dialogo.HistoriaContinuacao + "\n");
            }
            
            break;             
        }      
      
    }
    public void ComoPossoAjudar(Jogador Jogador, Npc Npc)
    {
        while (true)
        {
            Console.WriteLine($"\n{Jogador.Nome}:");
            Console.WriteLine("— Como posso ajudar?");

            if(Npc.Dialogo.Missao != null)
            {
                NomeNpc(Jogador, Npc);
                Console.WriteLine("— " + Npc.Dialogo.Missao + "\n");

                Console.WriteLine("[1] Certo, posso ajudar.");
                Console.WriteLine("[2] Desculpa, não posso ajudar.");
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

                            NomeNpc(Jogador, Npc);
                            Console.WriteLine("— " + Npc.Dialogo.DespedidaMissaoAceitada.Replace("{nome}", Jogador.Nome) + "\n");

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

                        NomeNpc(Jogador, Npc);
                        Console.WriteLine("— " + Npc.Dialogo.DespedidaMissaoRecusada + "\n");                    
                    break;
                }
            }         

            break;       
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