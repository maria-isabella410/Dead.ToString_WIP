using rpgItem;
using rpgJogador;
using rpgLocal;
using rpgMapa;
using rpgConsumivel;
using rpgChave;
using rpgZombie;
using rpgNpc;
using rpgCombate;
using rpgMetodosDialogo;
using rpgMissao;
using rpgSalasDoJogo;
using rpgSala;
using rpgMissoesDoJogo;
using rpgItensDoJogo;
using rpgInventario;
using rpgArma;
using rpgMenuInventario;

namespace rpgJogo;

public class Jogo
{
    private Jogador Jogador;
    private Boolean emExecucao; 
    private Mapa Mapa;
    private Random random = new Random();
    private Exploracao exploracao;
    private Navegacao navegacao;
    private GerenciadorMissoes gerenciadorMissoes;
    private MenuInventario menuInventario;

    private static Boolean VerificaInputNum(int inputNum, int qntOpcoes)
    {
        if(inputNum > qntOpcoes || inputNum < 0 )
        {
            Console.WriteLine("\nEntrada inválida! Tente novamente.");
            return false;
        }
        else
        {
            return true;
        }
    }
    public void Iniciar()
    {
        emExecucao = true;

        Mapa = new Mapa(random);

        SalasDoJogo salasDoJogo = new SalasDoJogo(Mapa, random);

        Console.WriteLine("\nOlá, jogador! Seja bem-vindo(a) ao << Dead.ToString() >> !\n");
        Console.WriteLine("Durante essa jornada, qual será seu nome?\n");
        Console.Write("--> ");

        String nomeJogador = Console.ReadLine();

        Jogador = new Jogador(50, 50, 15, 10, 25, nomeJogador, Mapa.ruaPrincipal, null);

        Introducao(Jogador);

        while (emExecucao)
        {
            MenuPrincipal();

            int opcao = Convert.ToInt32(Console.ReadLine());

            if(opcao == 0)
            {
                Encerrar();

                emExecucao = false;

                return;
            }            

            if(!VerificaInputNum(opcao, 5))
            {
                continue;
            }
            else
            {
                opcoesMenu escolha = (opcoesMenu)opcao;

                switch (escolha)
                {
                    case opcoesMenu.Explorar:
                        Explorar();                                                            
                    break;

                    case opcoesMenu.AbrirMapa:
                        AbrirMapa(Mapa);
                    break;
                        
                    case opcoesMenu.AbrirInventario:
                        AbrirInventario();
                    break;

                    case opcoesMenu.VerificarStatus:
                        MostrarStatus();
                    break;

                    case opcoesMenu.IrParaOutroLocal:
                        IrParaOutroLocal();
                    break;
                }               
            }
        }

        Encerrar();
    }

    public void Introducao(Jogador Jogador)
    {        
        Console.WriteLine("O mundo como conhecíamos acabou...\n");
        Console.WriteLine("Mortos-vivos tomaram as ruas da cidade, devorando todos as pessoas que encontravam!\n");
        Console.WriteLine("Algumas pessoas conseguiram escapar e se esconderam em abrigos improvisados, mas os recursos são escassos e as ruas são perigosas...\n");
        Console.WriteLine($"Você, {Jogador.Nome}, é uma dessas pessoas. Você sobreviveu até aqui, porém, mais do que sobreviver, você quer descobrir o que causou tudo isso e como resolver!\n");
        Console.WriteLine("Busque recursos, ajude outros sobreviventes, encontre respostas e claro, sobreviva.\n");

        Mapa.MostrarLocalAtual(Jogador);
    }
    public void Explorar()
    {
        List<Item> itensLocal = Jogador.LocalAtual.Itens;
        List<Zombie> zombiesLocal = Jogador.LocalAtual.Zombies;
        List<Npc> npcsLocal = Jogador.LocalAtual.Npcs;

        Console.WriteLine($"Local atual: {Jogador.LocalAtual.Nome}\n");
        
        if(Jogador.LocalAtual.Salas.Count != 0)
        {
            if(Jogador.SalaAtual == null)
            {
                EscolherSala();
            }            

            if(Jogador.SalaAtual != null)
            {          
                itensLocal = Jogador.SalaAtual.Itens;
                zombiesLocal = Jogador.SalaAtual.Zombies;
                npcsLocal = Jogador.SalaAtual.Npcs;
            } 

            Console.WriteLine("O que deseja fazer? ([0] para Voltar)");
        }       

        while (true)
        {            
            MenuExplorar();

            int opcao = Convert.ToInt32(Console.ReadLine());

            if(opcao == 0)
            {
                Jogador.SalaAtual = null;
                return;
            }

            if(!VerificaInputNum(opcao, 3))
            {
                continue;
            }
            else
            {
                opcoesExplorar opcaoExplorar = (opcoesExplorar)opcao;

                switch (opcaoExplorar)
                {
                    case opcoesExplorar.ProcurarItens:
                        ProcurarItens(itensLocal); 
                    break;

                    case opcoesExplorar.ChecarArredores:
                        ExplorarArredores(zombiesLocal);                    
                    break;

                    case opcoesExplorar.ProcurarSobreviventes:
                        ProcurarSobreviventes(npcsLocal);
                    break;

                    default:
                        Console.WriteLine("\nEntrada inválida!");
                    break;
                }                
            }                      
        } 
    }
    public void ConversarComNpc(Npc Npc)
    {
        MetodosDialogo MetodosDialogo = new MetodosDialogo();

        MetodosDialogo.DialogoComNpc(Jogador, Npc);      
    }
    public void EscolherDirecao(Local local)
    {
        Console.WriteLine("Para onde deseja ir?");

        Boolean temMapa = Jogador.ContemMapa;

        if(local.Norte != null)
        {
            string nomeNorte = (temMapa || local.Norte.FoiVisitado) ? local.Norte.Nome : "??? (Desconhecido)";
            Console.WriteLine($"[N] - {nomeNorte}");
        }
        if(local.Leste != null)
        {
            string nomeLeste = (temMapa || local.Leste.FoiVisitado) ? local.Leste.Nome : "??? (Desconhecido)";
            Console.WriteLine($"[L] - {nomeLeste}");
        }
        if(local.Oeste != null)
        {
            string nomeOeste = (temMapa || local.Oeste.FoiVisitado) ? local.Oeste.Nome : "??? (Desconhecido)";
            Console.WriteLine($"[O] - {nomeOeste}");
        }
        if(local.Sul != null)
        {
            string nomeSul = (temMapa || local.Sul.FoiVisitado) ? local.Sul.Nome : "??? (Desconhecido)";
            Console.WriteLine($"[S] - {nomeSul}");
        }        
        Console.Write("--> ");
    }
    private enum opcoesDirecao
    {
        Norte = 'N',
        Leste = 'L',
        Oeste = 'O',
        Sul = 'S'
    }
    private void EscolherSala()
    {
        if(Jogador.SalaAtual != null)
        {
            Console.WriteLine($"Sala atual: < {Jogador.SalaAtual.Nome} >\n");
            Console.WriteLine(Jogador.SalaAtual.Descricao);
        } 

        Console.WriteLine("Para onde deseja ir? ([0] para Voltar)");

        List<Sala> salasDisponiveis = Jogador.LocalAtual.Salas.Where(sala => sala != Jogador.SalaAtual).ToList();

        while (true)
        {        
            for(int i = 0; i < salasDisponiveis.Count; i++)
            {
                Sala sala = salasDisponiveis[i];

                if(sala.PortaTrancada != null && !sala.PortaTrancada.Aberta)
                {
                    Console.WriteLine($"[{i + 1}] {sala.Nome} - Trancada");
                }
                else
                {
                    Console.WriteLine($"[{i + 1}] {sala.Nome}");
                }
            }                               

            Console.Write("--> ");

            int opcaoEscolhidaSala = Convert.ToInt32(Console.ReadLine());

            if(opcaoEscolhidaSala == 0)
            {
                return;
            }

            if(!VerificaInputNum(opcaoEscolhidaSala, salasDisponiveis.Count))
            {
                continue;
            }
            else
            {
                Sala salaEscolhida = salasDisponiveis[opcaoEscolhidaSala - 1];


                if(salaEscolhida.PortaTrancada != null && !salaEscolhida.PortaTrancada.Aberta)
                {
                    List<Chave> chaves = Jogador.Inventario.ListarChaves();

                    Console.WriteLine($"\nVocê não pode entrar nessa sala sem a {salaEscolhida.PortaTrancada.ChaveNecessaria.Nome}.");

                    foreach(Chave chave in chaves)
                    {
                        if(chave == salaEscolhida.PortaTrancada.ChaveNecessaria)
                        {
                            Console.WriteLine("\nVocê consegue abrir a porta.");
                            Console.WriteLine($"\nAgora, você tem acesso a {salaEscolhida.Nome}.");

                            salaEscolhida.PortaTrancada.Aberta = true;

                            Jogador.Inventario.DescartarItem(chave);

                            Console.WriteLine($"\n{chave.Nome} foi descartada.\n");

                            break;
                        }
                    }
                    if (!salaEscolhida.PortaTrancada.Aberta)
                    {
                        Console.WriteLine("\nVocê não tem a chave necessária para abrir essa porta.");

                        return;
                    } 
                }
                Jogador.SalaAtual = salaEscolhida;

                Console.WriteLine($"\nAgora, você está em: < {Jogador.SalaAtual.Nome} >\n");
                Console.WriteLine(Jogador.SalaAtual.Descricao);                
            }
            return;
        }                 
    }
    public void AtualizarMissao(Jogador jogador)
    {
        if(jogador.MissaoAtual == null) return;

        if (Missao.MissaoValida(jogador))
        {
            jogador.MissaoAtual.Concluida = true;

            jogador.Inventario.DescartarItem(jogador.MissaoAtual.ItemNecessario);

            jogador.Inventario.GuardarItem(jogador.MissaoAtual.Recompensa, Jogador);
                
            if(jogador.MissaoAtual.Recompensa != null)
            {
                Console.WriteLine($"\nMissão concluída! O item de recompensa [{jogador.MissaoAtual.Recompensa.Nome}] foi adicionado ao seu inventário.\n");
            } 
            if(jogador.MissaoAtual.Recompensa == null && jogador.MissaoAtual == MissoesDoJogo.CriaMissaoEnfermeira())
            {                
                Console.WriteLine("\nMissão concluída! A Enfermeira Grace irá tratar seus ferimentos.");

                jogador.Vida = jogador.VidaMaxima;

                Console.WriteLine("\nApós uma sessão de cuidados, você se sente muito melhor.");
                Console.WriteLine($"\nHP: [{jogador.Vida} / {jogador.VidaMaxima}]");                
            }            

            jogador.MissaoAtual = null;
        }
        //arrumar dps
    }

    private void AbrirMapa(Mapa Mapa)
    {
        if (!Jogador.ContemMapa)
        {
            Console.WriteLine("\nVocê não tem o mapa da cidade!");
        }
        else
        {
            Mapa.MostrarMapa();

            while (true)
            {
                MenuMapa();

                int opcaoMenuMapa = Convert.ToInt32(Console.ReadLine());

                if(opcaoMenuMapa == 0)
                {
                    return;
                }

                Console.WriteLine("\nEntrada inválida!");
            }

        }
    }
    private void ProcurarItens(List<Item> itensLocal)
    {
        if(itensLocal.Count > 0)
        {
            Console.WriteLine("\nExplorando, você encontrou:\n");

            for(int i = 0; i < itensLocal.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {itensLocal[i].Nome}");
            }

            while(true)
            {
                Console.WriteLine("Digite o item que deseja coletar ou [0] para Voltar.");
                Console.Write("--> ");

                int opcaoEscolhidaItem = Convert.ToInt32(Console.ReadLine());

                if(opcaoEscolhidaItem == 0)
                {
                    return;
                }
                if(opcaoEscolhidaItem < 1 || opcaoEscolhidaItem > itensLocal.Count)
                {
                    Console.WriteLine("\nEntrada inválida!");

                    continue;
                }

                Item item = itensLocal[opcaoEscolhidaItem - 1];

                if(item == ItensDoJogo.CriarMochila() || item == ItensDoJogo.CriarColete())
                {
                    Jogador.Inventario.EquiparItem(item, Jogador);

                    Console.WriteLine($"\nVocê equipou o item: {itensLocal[opcaoEscolhidaItem - 1].Nome}");

                    itensLocal.RemoveAt(opcaoEscolhidaItem - 1);

                    return;
                }

                if(item == ItensDoJogo.CriarMapaDaCidade())
                {
                    Jogador.Inventario.EquiparItem(item, Jogador);

                    Console.WriteLine($"\nVocê guardou o item: {itensLocal[opcaoEscolhidaItem - 1].Nome}");

                    itensLocal.RemoveAt(opcaoEscolhidaItem - 1);

                    return;
                }

                bool conseguiuGuardar = Jogador.Inventario.GuardarItem(item, Jogador);

                if(conseguiuGuardar)
                {
                    Console.WriteLine($"\nVocê coletou o item: {itensLocal[opcaoEscolhidaItem - 1].Nome}");

                    itensLocal.RemoveAt(opcaoEscolhidaItem - 1);

                    return;
                }
            }    
        }
        else
        {
            Console.WriteLine("\nVocê não encontrou nenhum item.\n");
        }
    }
    private void ExplorarArredores(List<Zombie> zombiesLocal)
    {
        if(zombiesLocal.Count > 0)
        {
            if(zombiesLocal.Count == 1)
            {
                Console.WriteLine($"Há {zombiesLocal.Count} zombie aqui.");

                Console.WriteLine("O que deseja fazer quanto ao zombie?");
            }
            else
            {
                Console.WriteLine($"Há {zombiesLocal.Count} zombies aqui.");

                Console.WriteLine("O que deseja fazer quanto aos zombies?");
            }

            while (true)
            {
                Console.WriteLine("[1] Lutar");
                Console.WriteLine("[2] Ignorar");
                Console.Write("--> ");

                int opcaoCombate = Convert.ToInt32(Console.ReadLine());

                if(opcaoCombate < 1 || opcaoCombate > 2)
                {
                    Console.WriteLine("\nEntrada inválida!");

                    continue;
                }            

                if(opcaoCombate == 1)
                {
                    while (true)
                    {
                        Console.WriteLine("Qual zombie deseja enfrentar? ([0] para Desistir)");
                        
                        for(int i = 0; i < zombiesLocal.Count; i++)
                        {
                            Console.WriteLine($"[{i + 1}] {zombiesLocal[i].Tipo}");
                        }

                        Console.Write("--> ");

                        int opcaoEnfrentar = Convert.ToInt32(Console.ReadLine());

                        if(opcaoEnfrentar == 0)
                        {
                            return;
                        }

                        if(opcaoEnfrentar < 1 || opcaoEnfrentar > zombiesLocal.Count)
                        {
                            Console.WriteLine("\nEntrada inválida!");

                            continue;
                        }

                        int indiceZombie = opcaoEnfrentar - 1;

                        Combate combate = new Combate(Jogador, zombiesLocal[indiceZombie], random);

                        combate.IniciarCombate();

                        if(!zombiesLocal[indiceZombie].EstaVivo())
                        {
                            zombiesLocal.RemoveAt(indiceZombie);
                        }

                        if(zombiesLocal.Count == 0)
                        {
                            return;
                        }                        
                    }
                }
                   
                if(opcaoCombate == 2)
                {
                    if(zombiesLocal.Count == 1)
                    {
                        Console.WriteLine("\nVocê ignorou o zombie.");

                        return;                      
                    }
                    else
                    {
                        Console.WriteLine("\nVocê ignorou os zombies.");

                        return;
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("\nNão há zombies aqui.");
        }
    }
    private void ProcurarSobreviventes(List<Npc> npcsLocal)
    {
        if(npcsLocal.Count > 0)
        {   
            Console.WriteLine($"Há uma pessoa aqui.\n");            
            Console.WriteLine($"Deseja interagir com ela?");

            while (true)
            {
                Console.WriteLine("[1] Sim");
                Console.WriteLine("[2] Não");
                Console.Write("--> ");

                int opcaoConversa = Convert.ToInt32(Console.ReadLine());

                if(opcaoConversa < 1 || opcaoConversa > 2)
                {
                    Console.WriteLine("\nEntrada inválida!");

                    continue;
                }

                if(opcaoConversa == 1)
                {
                    ConversarComNpc(npcsLocal[0]);
                }               

                if(opcaoConversa == 2)
                {
                    return;
                } 

                break;             
            }
        }
        else
        {
            Console.WriteLine("\nNão há ninguém aqui.");
        }
    }
    private void IrParaOutroLocal()
    {
        EscolherDirecao(Jogador.LocalAtual);

        string entrada = Console.ReadLine();
        if (string.IsNullOrEmpty(entrada))
        {
            Console.WriteLine("\nEntrada inválida!");
            return;
        }

        char opcaoDirecao = char.ToUpper(entrada[0]);

        opcoesDirecao escolhaDirecao = (opcoesDirecao)opcaoDirecao;

        switch (escolhaDirecao)
        {
            case opcoesDirecao.Norte:
                if(Jogador.LocalAtual.Norte != null)
                {
                    Jogador.LocalAtual = Jogador.LocalAtual.Norte;
                    Jogador.SalaAtual = null;

                    Jogador.LocalAtual.FoiVisitado = true;

                    Console.WriteLine("\nAgora, você está em: " + Jogador.LocalAtual.Nome);
                }                            

            break;
            case opcoesDirecao.Leste:
                if(Jogador.LocalAtual.Leste != null)
                {
                    Jogador.LocalAtual = Jogador.LocalAtual.Leste;
                    Jogador.SalaAtual = null;

                    Jogador.LocalAtual.FoiVisitado = true;

                    Console.WriteLine("\nAgora, você está em: " + Jogador.LocalAtual.Nome);
                }                              
                
            break;
            case opcoesDirecao.Oeste:
                if(Jogador.LocalAtual.Oeste != null)
                {
                    Jogador.LocalAtual = Jogador.LocalAtual.Oeste;
                    Jogador.SalaAtual = null;

                    Jogador.LocalAtual.FoiVisitado = true;

                    Console.WriteLine("\nAgora, você está em: " + Jogador.LocalAtual.Nome);
                }                              
                
            break;
            case opcoesDirecao.Sul:
                if(Jogador.LocalAtual.Sul != null)
                {
                    Jogador.LocalAtual = Jogador.LocalAtual.Sul;
                    Jogador.SalaAtual = null;

                    Jogador.LocalAtual.FoiVisitado = true;

                    Console.WriteLine("\nAgora, você está em: " + Jogador.LocalAtual.Nome);
                }                              
        
            break;
            default:
                Console.WriteLine("\nEntrada inválida!");

            break;
        }
    }
    public void Encerrar()
    {
        Console.WriteLine("\nObrigada por jogar! Jogo finalizado...\n");
    }
}