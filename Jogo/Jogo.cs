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
using rpgMissoesDoJogo;

namespace rpgJogo;

public class Jogo
{
    private Jogador Jogador {get; set;}
    private Boolean emExecucao {get; set;}
    private Mapa Mapa {get; set;}
    private Random random = new Random();

    public static void DivisaoDeLinha()
    {
        Console.WriteLine("-----------------------");
    }
    public void Iniciar()
    {
        emExecucao = true;

        Mapa = new Mapa(random);

        Console.WriteLine("Qual será seu nome?");
        Console.Write("--> ");

        String nomeJogador = Console.ReadLine();

        Jogador = new Jogador(100, 100, 30, 20, 25, nomeJogador, Mapa.ruaPrincipal);

        Introducao(Jogador);

        while (emExecucao)
        {
            MenuPrincipal();

            int opcao = Convert.ToInt32(Console.ReadLine());
        
            opcoesMenu escolha = (opcoesMenu)opcao;

            switch (escolha)
            {
                case opcoesMenu.Explorar:
                    Explorar(Jogador, Jogador.LocalAtual.Itens, Jogador.LocalAtual.Zombies, Jogador.LocalAtual.Npcs);
                    
                    break;
                case opcoesMenu.AbrirMapa:
                    if (!Jogador.ContemMapa)
                    {
                        Console.WriteLine("Você não tem o mapa da cidade!");
                    }
                    else
                    {
                        Mapa.MostrarMapa();

                        MenuMapa();

                        int opcaoMenuMapa = Convert.ToInt32(Console.ReadLine());
        
                        opcoesMapa escolhaMenuMapa = (opcoesMapa)opcaoMenuMapa;

                        switch (escolhaMenuMapa)
                        {
                            case opcoesMapa.Voltar:
                                break;
                            default:
                                Console.WriteLine("Entrada inválida!");
                                break;
                        }
                    }
                    break;
                case opcoesMenu.AbrirInventario:
                    AbrirInventario();

                    break;
                case opcoesMenu.VerificarStatus:
                    MostrarStatus();

                    break;
                case opcoesMenu.IrParaOutroLocal:
                    EscolherDirecao(Jogador.LocalAtual);

                    Char opcaoDirecao = Convert.ToChar(Console.ReadLine());

                    opcoesDirecao escolhaDirecao = (opcoesDirecao)opcaoDirecao;

                    switch (escolhaDirecao)
                    {
                        case opcoesDirecao.Norte:
                            if(Jogador.LocalAtual.Norte!= null)
                            {
                                Jogador.LocalAtual = Jogador.LocalAtual.Norte;

                                Console.WriteLine("Agora, você está em: " + Jogador.LocalAtual.Nome);
                            }                            

                            break;
                        case opcoesDirecao.Leste:
                            if(Jogador.LocalAtual.Leste!= null)
                            {
                                Jogador.LocalAtual = Jogador.LocalAtual.Leste;

                                Console.WriteLine("Agora, você está em: " + Jogador.LocalAtual.Nome);
                            }                              
                            
                            break;
                        case opcoesDirecao.Oeste:
                            if(Jogador.LocalAtual.Oeste!= null)
                            {
                                Jogador.LocalAtual = Jogador.LocalAtual.Oeste;

                                Console.WriteLine("Agora, você está em: " + Jogador.LocalAtual.Nome);
                            }                              
                            
                            break;
                        case opcoesDirecao.Sul:
                            if(Jogador.LocalAtual.Sul!= null)
                            {
                                Jogador.LocalAtual = Jogador.LocalAtual.Sul;

                                Console.WriteLine("Agora, você está em: " + Jogador.LocalAtual.Nome);
                            }                              
                    
                            break;
                        default:
                            Console.WriteLine("Entrada inválida!");

                            break;
                    }

                    break;
                case opcoesMenu.EncerrarJogo:                    
                    Encerrar();

                    emExecucao = false;

                    break;
                default:
                    Console.WriteLine("Entrada inválida!");
                    
                    break;
            }
        }

        Encerrar();
    }
    public void MenuPrincipal()
    {
        DivisaoDeLinha();
        Console.WriteLine("O que quer fazer?");
        DivisaoDeLinha();
        Console.WriteLine("[1] Explorar");
        Console.WriteLine("[2] Abrir mapa");
        Console.WriteLine("[3] Abrir inventário");
        Console.WriteLine("[4] Verificar status");
        Console.WriteLine("[5] Ir para outro local");
        Console.WriteLine("[0] Encerrar jogo");
        Console.Write("--> ");
        DivisaoDeLinha();
    }
    private enum opcoesMenu
    {
        Explorar = 1,
        AbrirMapa = 2,
        AbrirInventario = 3,
        VerificarStatus = 4,
        IrParaOutroLocal = 5,
        EncerrarJogo = 0
    }
    private void MenuInventario()
    {
        DivisaoDeLinha();
        Console.WriteLine("O que quer fazer?");
        Console.WriteLine("[1] Inspecionar item");
        Console.WriteLine("[2] Usar chave");
        Console.WriteLine("[3] Consumir item");
        Console.WriteLine("[4] Descartar item");
        Console.WriteLine("[0] Voltar");
        Console.Write("--> ");
        DivisaoDeLinha();
    }
    private enum opcoesInventario
    {
        InspecionarItem = 1,
        UsarChave = 2,
        ConsumirItem = 3,
        DescartarItem = 4,
        Voltar = 0
    }
    public void MenuMapa()
    {
        Console.WriteLine("[1] Voltar");
        Console.Write("--> ");
    }
    private enum opcoesMapa
    {
        Voltar = 1
    }
    public void MenuExplorar()
    {
        Console.WriteLine("[1] Procurar itens");
        Console.WriteLine("[2] Checar os arredores por zombies");
        Console.WriteLine("[3] Procurar sobreviventes");
        Console.WriteLine("[0] Ir embora");
    }
    private enum opcoesExplorar
    {
        ProcurarItens = 1,
        ChecarArredores = 2,
        ProcurarSobreviventes = 3,
        IrEmbora = 0
    }
    public void Introducao(Jogador Jogador)
    {
        DivisaoDeLinha();
        
        Console.WriteLine("O mundo como conhecíamos acabou...");
        Console.WriteLine("Mortos-vivos tomaram as ruas da cidade, devorando todos as pessoas que encontravam!");
        Console.WriteLine("Algumas pessoas conseguiram escapar e se esconderam em abrigos improvisados, mas os recursos são escassos e as ruas são perigosas...");
        Console.WriteLine($"Você, {Jogador.Nome}, é uma dessas pessoas. Você sobreviveu até aqui, porém, mais do que sobreviver, você quer descobrir o que causou tudo isso e como resolver!");
        Console.WriteLine("Busque recursos, ajude outros sobreviventes, encontre respostas e claro, sobreviva.");
        
        DivisaoDeLinha();

        Mapa.MostrarLocalAtual(Jogador);
    }
    public void Explorar(Jogador Jogador, List<Item> itensLocal, List<Zombie> zombiesLocal, List<Npc> npcsLocal)
    {
        Console.WriteLine("=======================");
        Console.WriteLine($"Local atual: {Jogador.LocalAtual.Nome}");
        Console.WriteLine("=======================");
        Console.WriteLine("O que deseja fazer?");
        MenuExplorar();
        Console.Write("--> ");

        int escolhaExplorar = Convert.ToInt32(Console.ReadLine());

        if(escolhaExplorar < 0 || escolhaExplorar > 3)
        {
            Console.WriteLine("Entrada inválida!");
        }
        else
        {
            opcoesExplorar opcaoExplorar = (opcoesExplorar)escolhaExplorar;

            switch (opcaoExplorar)
            {
                case opcoesExplorar.ProcurarItens:

                    if(itensLocal.Count > 0)
                    {
                        Console.WriteLine("Explorando, você encontrou:");

                        for(int i = 0; i < itensLocal.Count; i++)
                        {
                            Console.WriteLine($"[{i + 1}] {itensLocal[i].Nome}");
                        }

                        int opcaoEscolhidaItem; 

                        do
                        {
                            for(int i = 0; i < itensLocal.Count; i++)
                            {
                                Console.WriteLine($"- {itensLocal[i].Nome}");
                            }

                            Console.WriteLine("[1] Coletar item");
                            Console.WriteLine("[0] Voltar");
                            Console.Write("--> ");

                            opcaoEscolhidaItem = Convert.ToInt32(Console.ReadLine());

                            if(opcaoEscolhidaItem < 0 || opcaoEscolhidaItem > 1)
                            {
                                Console.WriteLine("Entrada inválida!");
                            }
                            else{
                                DivisaoDeLinha();

                                switch (opcaoEscolhidaItem)
                                {
                                    case 1:
                                        Console.WriteLine("Qual item deseja coletar?");
                                        int opcaoItemEscolhido = Convert.ToInt32(Console.ReadLine());

                                        if (opcaoItemEscolhido < 1 || opcaoItemEscolhido > itensLocal.Count)
                                        {
                                            Console.WriteLine("Entrada inválida!");
                                        }
                                        else
                                        {
                                            Item item = itensLocal[opcaoItemEscolhido - 1];

                                            Jogador.Inventario.GuardarItem(item);

                                            itensLocal.RemoveAt(opcaoItemEscolhido - 1);

                                            Console.WriteLine($"{item.Nome} foi adicionado ao inventário.");
                                        }
                                    
                                        break;
                                    case 0:
                                        break;
                                    default:
                                        Console.WriteLine("Entrada inválida!");

                                        break;
                                }
                            }
                        } while(opcaoEscolhidaItem != 0);
                
                    }
                    else
                    {
                        Console.WriteLine("Você não encontrou nenhum item.");
                    }
                    break;

                case opcoesExplorar.ChecarArredores:

                    if(zombiesLocal.Count > 0)
                    {
                        Console.WriteLine($"Há {zombiesLocal.Count} zombie(s) aqui.");

                        DivisaoDeLinha();

                        Console.WriteLine("O que deseja fazer quanto ao(s) zombie(s)?");
                        Console.WriteLine("[1] Lutar");
                        Console.WriteLine("[2] Ignorar");
                        Console.Write("--> ");

                        int opcaoCombate = Convert.ToInt32(Console.ReadLine());

                        if(opcaoCombate < 0 || opcaoCombate > 2)
                        {
                            Console.WriteLine("Entrada inválida!");
                        }
                        else
                        {
                            switch (opcaoCombate)
                            {
                                case 1:
                                    int indiceZombie = zombiesLocal.Count - 1;

                                    Combate combate = new Combate(Jogador, zombiesLocal[indiceZombie], random);

                                    combate.IniciarCombate();

                                    if(!zombiesLocal[indiceZombie].EstaVivo())
                                    {
                                        zombiesLocal.RemoveAt(indiceZombie);
                                    }

                                    break;
                                case 2:
                                    Console.WriteLine("Você ignorou o(s) zombie(s).");

                                    break;
                            }    
                        }
                    }
                    else
                    {
                        Console.WriteLine("Não há zombies aqui.");
                    }
                    break;

                case opcoesExplorar.ProcurarSobreviventes:

                    if(npcsLocal.Count > 0)
                    {
                        foreach(Npc npc in npcsLocal) Console.WriteLine($"Há uma pessoa aqui: {npc.Nome}");

                        Console.WriteLine($"Deseja conversar com {npcsLocal[0].Nome}?");
                        Console.WriteLine("[1] Sim");
                        Console.WriteLine("[2] Não");
                        Console.Write("--> ");

                        int opcaoConversa = Convert.ToInt32(Console.ReadLine());

                        if(opcaoConversa < 0 || opcaoConversa > 2)
                        {
                            Console.WriteLine("Entrada inválida!");
                        }
                        else
                        {
                            switch (opcaoConversa)
                            {
                                case 1:
                                    ConversarComNpc(npcsLocal[0], Jogador);

                                    break;
                                case 2:
                                    return;
                                default:
                                    Console.WriteLine("Entrada inválida!"); 
                                    
                                    break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Não há ninguém aqui.");
                    }
                    break;

                case opcoesExplorar.IrEmbora:
                    return;

                default:
                    Console.WriteLine("Entrada inválida!");
                    break;
            }
        }    
    }
    public void MostrarStatus()
    {
        DivisaoDeLinha();
        Console.WriteLine("Jogador: " + Jogador.Nome);
        Console.WriteLine($"HP: [{Jogador.Vida} / {Jogador.VidaMaxima}]");
        Console.WriteLine("Ataque: " + Jogador.Ataque);
        Console.WriteLine("Defesa: " + Jogador.Defesa);
        Console.WriteLine("Agilidade: " + Jogador.Agilidade);

        if(Jogador.MissaoAtual != null)
        {
            Console.WriteLine("Missão atual: " + Jogador.MissaoAtual);
        }
        DivisaoDeLinha();
    }
    public void ConversarComNpc(Npc npc, Jogador Jogador)
    {
        DivisaoDeLinha();

        MetodosDialogo dialogo = new MetodosDialogo(Jogador);

        Console.WriteLine(npc.Dialogo.Saudacao);

        dialogo.ContinuarDialogo(npc);        
    }
    public void EscolherDirecao(Local local)
    {
        if(local.Norte != null)
        {
            Console.WriteLine($"[N] - {local.Norte.Nome}");
        }
        if(local.Leste != null)
        {
            Console.WriteLine($"[L] - {local.Leste.Nome}");
        }
        if(local.Oeste != null)
        {
            Console.WriteLine($"[O] - {local.Oeste.Nome}");
        }
        if(local.Sul != null)
        {
            Console.WriteLine($"[S] - {local.Sul.Nome}");
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
    public void AtualizarMissao(Jogador jogador)
    {
        if(jogador.MissaoAtual == null) return;

        if (Missao.MissaoValida(jogador))
        {
            jogador.MissaoAtual.Concluida = true;

            jogador.Inventario.DescartarItem(jogador.MissaoAtual.ItemNecessario);

            jogador.Inventario.GuardarItem(jogador.MissaoAtual.Recompensa);
                
            Console.WriteLine("Missão concluída!");

            jogador.MissaoAtual = null;
        }
    }
    public void AbrirInventario()
    {
        List<Item> itens = Jogador.Inventario.ListarItens();

        for(int i = 0; i < itens.Count; i++)
        {
            Console.WriteLine($"[{i + 1}] {itens[i].Nome}");
        }

        MenuInventario();

        int opcaoInventario = Convert.ToInt32(Console.ReadLine());

        opcoesInventario escolhaInventario = (opcoesInventario)opcaoInventario;

        // if(escolhaInventario == opcoesInventario.Voltar)
        // {
        //     break;
        // }
        switch (escolhaInventario)
        {
            case opcoesInventario.InspecionarItem:
                Console.WriteLine("Qual item deseja inspecionar?");

                Jogador.Inventario.ListarItens();
                
                Console.Write("--> ");

                int idInspecao = Convert.ToInt32(Console.ReadLine());

                Jogador.Inventario.InspecionarItem(itens[idInspecao - 1]);

                break;
            case opcoesInventario.ConsumirItem:
                if(Jogador.Inventario.ListarConsumiveis().Count == 0)
                {
                    Console.WriteLine("Você não possui nenhum consumível em seu inventário.");
                    
                    break;
                }
                if (Jogador.Vida.Equals(Jogador.VidaMaxima))
                {
                    Console.WriteLine("Sua vida está cheia, você não precisa consumir nenhum item!");

                    break;
                }
                List<Consumivel> consumiveis = Jogador.Inventario.ListarConsumiveis();

                Console.WriteLine("Qual item deseja consumir?");

                for(int i = 0; i < consumiveis.Count; i++)
                {
                    Console.WriteLine($"[{i + 1}] {consumiveis[i].Nome}");
                }

                DivisaoDeLinha();

                Console.Write("--> ");

                int escolhaConsumivel = Convert.ToInt32(Console.ReadLine());

                if(escolhaConsumivel < 0 || escolhaConsumivel > consumiveis.Count)
                {
                    Console.WriteLine("Entrada inválida");
                }
                else
                {
                    Jogador.SeCurar(consumiveis[escolhaConsumivel - 1]);
                    Jogador.Inventario.DescartarItem(consumiveis[escolhaConsumivel - 1]);

                    Console.WriteLine("Você consumiu: " + consumiveis[escolhaConsumivel - 1].Nome);
                    Console.WriteLine($"Vida atual: [{Jogador.Vida} / {Jogador.VidaMaxima}]");

                    DivisaoDeLinha();
                }

                break;
            case opcoesInventario.UsarChave:
                List<Chave> chaves = Jogador.Inventario.ListarChaves();

                if(Jogador.Inventario.ListarChaves().Count == 0)
                {
                    Console.WriteLine("Você não possui nenhuma chave em seu inventário.");
                    
                    return;
                }

                Console.WriteLine("Qual chave deseja usar?");

                for(int i = 0; i < chaves.Count; i++)
                {
                    Console.WriteLine($"[{i + 1}] {chaves[i].Nome}");
                }

                DivisaoDeLinha();

                Console.Write("--> ");

                int escolhaChave = Convert.ToInt32(Console.ReadLine());

                if(escolhaChave < 0 || escolhaChave > chaves.Count)
                {
                    Console.WriteLine("Entrada inválida!");
                }
                else
                {
                    //ARRUMAR ISSO DPS
                    if()
                    {
                        Jogador.LocalAtual.SalaTrancada.Porta.Abrir(chaves[escolhaChave - 1]);
                    }

                    DivisaoDeLinha();
                }                          

                break;
            case opcoesInventario.DescartarItem:
                Console.WriteLine("Qual item deseja descartar?");

                Jogador.Inventario.ListarItens();
                
                Console.Write("--> ");

                int idDescarte = Convert.ToInt32(Console.ReadLine());

                Jogador.Inventario.DescartarItem(itens[idDescarte - 1]);

                Console.WriteLine($"O item {itens[idDescarte - 1].Nome} foi descartado!");

                break;
        }
    }
    public void MoverJogador()
    {
        EscolherDirecao(Jogador.LocalAtual);

        Char opcaoDirecao = Convert.ToChar(Console.ReadLine().ToUpper());

        opcoesDirecao escolhaDirecao = (opcoesDirecao)opcaoDirecao;

        switch (escolhaDirecao)
        {
            case opcoesDirecao.Norte:
                if(Jogador.LocalAtual.Norte != null)
                {
                    Jogador.LocalAtual = Jogador.LocalAtual.Norte;

                    Console.WriteLine("Agora, você está em: " + Jogador.LocalAtual.Nome);
                }

                break;
            case opcoesDirecao.Leste:
            if(Jogador.LocalAtual.Leste != null)
                {
                    Jogador.LocalAtual = Jogador.LocalAtual.Leste;

                    Console.WriteLine("Agora, você está em: " + Jogador.LocalAtual.Nome);
                }                          
                
                break;
            case opcoesDirecao.Oeste:
            if(Jogador.LocalAtual.Oeste != null)
                {
                    Jogador.LocalAtual = Jogador.LocalAtual.Oeste; 

                    Console.WriteLine("Agora, você está em: " + Jogador.LocalAtual.Nome);
                }
                                            
                break;
            case opcoesDirecao.Sul:
            if(Jogador.LocalAtual.Sul != null)
                {
                    Jogador.LocalAtual = Jogador.LocalAtual.Sul;

                    Console.WriteLine("Agora, você está em: " + Jogador.LocalAtual.Nome);
                }
                                    
                break;
            default:
                Console.WriteLine("Entrada inválida!");

                break;
        }
    }
    public void Encerrar()
    {
        Console.WriteLine("Obrigada por jogar! Jogo finalizado...");
    }
}