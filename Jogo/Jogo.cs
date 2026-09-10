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

        SalasDoJogo salasDoJogo = new SalasDoJogo(Mapa, random);

        Console.WriteLine("Qual será seu nome?");
        Console.Write("--> ");

        String nomeJogador = Console.ReadLine();

        Jogador = new Jogador(100, 100, 30, 20, 25, nomeJogador, Mapa.ruaPrincipal, null);

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

            if(opcao < 1 || opcao > 5)
            {
                Console.WriteLine("Entrada inválida!");

                continue;
            }
        
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
        Console.WriteLine("[2] Consumir item");
        Console.WriteLine("[3] Descartar item");
        Console.WriteLine("[0] Voltar");
        Console.Write("--> "); 
             
    }
    private enum opcoesInventario
    {
        InspecionarItem = 1,
        ConsumirItem = 2,
        DescartarItem = 3,
        Voltar = 0
    }
    public void MenuMapa()
    {
        Console.WriteLine("[0] Voltar");
        Console.Write("--> ");
    }
    // public void MenuExplorar()
    // {
    //     Console.WriteLine("[1] Explorar arredores");
    //     Console.WriteLine("[0] Ir embora");        
    // }
    // private enum opcoesExplorar
    // {
    //     ExplorarArredores = 1
    // }
    public void MenuExplorar()
    {
        Console.WriteLine("[1] Procurar itens");
        Console.WriteLine("[2] Checar os arredores por zombies");
        Console.WriteLine("[3] Procurar sobreviventes");
        Console.WriteLine("[0] Voltar");
        Console.Write("--> "); 
    }
    private enum opcoesExplorar
    {
        ProcurarItens = 1,
        ChecarArredores = 2,
        ProcurarSobreviventes = 3,
        Voltar = 0
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
    public void Explorar()
    {
        List<Item> itensLocal = Jogador.LocalAtual.Itens;
        List<Zombie> zombiesLocal = Jogador.LocalAtual.Zombies;
        List<Npc> npcsLocal = Jogador.LocalAtual.Npcs;

        Console.WriteLine("=======================");
        Console.WriteLine($"Local atual: {Jogador.LocalAtual.Nome}");
        
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

            Console.WriteLine("=======================");
            Console.WriteLine("O que deseja fazer?");

            while (true)
            {            
                MenuExplorar();

                int escolhaExplorar = Convert.ToInt32(Console.ReadLine());

                if(escolhaExplorar == 0)
                {
                    Jogador.SalaAtual = null;
                    return;
                }

                if(escolhaExplorar < 1 || escolhaExplorar > 3)
                {
                    Console.WriteLine("Entrada inválida!");

                    continue;
                }

                opcoesExplorar opcaoExplorar = (opcoesExplorar)escolhaExplorar;

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
                        Console.WriteLine("Entrada inválida!");
                    break;
                }                      
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
    private void EscolherSala()
    {
        if(Jogador.SalaAtual != null)
        {
            Console.WriteLine($"Sala atual: {Jogador.SalaAtual.Nome}");
            Console.WriteLine(Jogador.SalaAtual.Descricao);
        } 

        Console.WriteLine("Para onde deseja ir?");

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

            Console.WriteLine("[0] Voltar");
            DivisaoDeLinha();
            Console.Write("--> ");

            int opcaoEscolhidaSala = Convert.ToInt32(Console.ReadLine());

            if(opcaoEscolhidaSala == 0)
            {
                return;
            }

            if(opcaoEscolhidaSala < 1 || opcaoEscolhidaSala > salasDisponiveis.Count)
            {
                Console.WriteLine("Entrada inválida!");

                continue;
            }

            Sala salaEscolhida = salasDisponiveis[opcaoEscolhidaSala - 1];


            if(salaEscolhida.PortaTrancada != null && !salaEscolhida.PortaTrancada.Aberta)
            {
                List<Chave> chaves = Jogador.Inventario.ListarChaves();

                Console.WriteLine($"Você não pode entrar nessa sala sem a {salaEscolhida.PortaTrancada.ChaveNecessaria.Nome}.");

                foreach(Chave chave in chaves)
                {
                    if(chave == salaEscolhida.PortaTrancada.ChaveNecessaria)
                    {
                        Console.WriteLine("Você consegue abrir a porta.");
                        Console.WriteLine($"Agora, você tem acesso a {salaEscolhida.Nome}.");

                        salaEscolhida.PortaTrancada.Aberta = true;

                        Jogador.Inventario.DescartarItem(chave);

                        Console.WriteLine($"{chave.Nome} foi descartada.");

                        break;
                    }
                }
                if (!salaEscolhida.PortaTrancada.Aberta)
                {
                    Console.WriteLine("Você não tem a chave necessária para abrir essa porta.");

                    return;
                } 
            }
            Jogador.SalaAtual = salaEscolhida;

            Console.WriteLine($"Agora, você está em {Jogador.SalaAtual.Nome}.");
            Console.WriteLine(Jogador.SalaAtual.Descricao);

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
                
            Console.WriteLine("Missão concluída!");

            jogador.MissaoAtual = null;
        }
        //arrumar dps
    }
    public void AbrirInventario()
    {
        List<Item> itens = Jogador.Inventario.ListarItens();

        Console.WriteLine($"Inventário: [{Jogador.Inventario.EspacosOcupados} / {Jogador.Inventario.Capacidade}]");

        if(itens.Count == 0)
        {
            Console.WriteLine("Você não possui itens em seu inventário.");

            return;
        }

        for(int i = 0; i < itens.Count; i++)
        {
            Console.WriteLine($"[{i + 1}] {itens[i].Nome}");
        }

        while (true)
        {
            MenuInventario();

            int opcaoInventario = Convert.ToInt32(Console.ReadLine());
            
            if(opcaoInventario == 0)
            {
                return;
            } 

            if(opcaoInventario < 1 || opcaoInventario > 3)
            {
                Console.WriteLine("Entrada inválida!");

                continue;
            }

            opcoesInventario escolhaInventario = (opcoesInventario)opcaoInventario;

            switch (escolhaInventario)
            {
                case opcoesInventario.InspecionarItem:
                    Console.WriteLine("Qual item deseja inspecionar?");

                    Jogador.Inventario.ListarItens();
                    
                    Console.Write("--> ");

                    int idInspecao = Convert.ToInt32(Console.ReadLine());

                    if(idInspecao == 0)
                    {
                        return;
                    }

                    if(idInspecao < 1 || idInspecao > itens.Count)
                    {
                        Console.WriteLine("Entrada inválida!");

                        continue;
                    }

                    Jogador.Inventario.InspecionarItem(itens[idInspecao - 1]);

                break;
                case opcoesInventario.ConsumirItem:
                    List<Consumivel> consumiveis = Jogador.Inventario.ListarConsumiveis();
                    
                    if(consumiveis.Count == 0)
                    {
                        Console.WriteLine("Você não possui nenhum consumível em seu inventário.");
                        
                        break;
                    }
                    if (Jogador.Vida.Equals(Jogador.VidaMaxima))
                    {
                        Console.WriteLine("Sua vida está cheia, você não precisa consumir nenhum item.");

                        break;
                    }
                
                    Console.WriteLine("Qual item deseja consumir?");

                    for(int i = 0; i < consumiveis.Count; i++)
                    {
                        Console.WriteLine($"[{i + 1}] {consumiveis[i].Nome}");
                    }

                    DivisaoDeLinha();

                    Console.Write("--> ");

                    int escolhaConsumivel = Convert.ToInt32(Console.ReadLine());

                    if(escolhaConsumivel == 0)
                    {
                        return;
                    }

                    if(escolhaConsumivel < 1 || escolhaConsumivel > consumiveis.Count)
                    {
                        Console.WriteLine("Entrada inválida");

                        continue;
                    }
                    Jogador.SeCurar(consumiveis[escolhaConsumivel - 1]);
                    Jogador.Inventario.DescartarItem(consumiveis[escolhaConsumivel - 1]);

                    Console.WriteLine("Você consumiu: " + consumiveis[escolhaConsumivel - 1].Nome);
                    Console.WriteLine($"Vida atual: [{Jogador.Vida} / {Jogador.VidaMaxima}]");

                    DivisaoDeLinha();

                break;
                case opcoesInventario.DescartarItem:
                    Console.WriteLine("Qual item deseja descartar?");

                    Jogador.Inventario.ListarItens();
                    
                    Console.Write("--> ");

                    int idDescarte = Convert.ToInt32(Console.ReadLine());

                    if(idDescarte == 0)
                    {
                        return;
                    }

                    if(idDescarte < 1 || idDescarte > itens.Count)
                    {
                        Console.WriteLine("Entrada inválida!");

                        continue;
                    }

                    Item item = itens[idDescarte - 1];

                    Jogador.Inventario.DescartarItem(item);

                    Console.WriteLine($"O item {item.Nome} foi descartado!");
                    Console.WriteLine($"Estado de inventário: [{Jogador.Inventario.EspacosOcupados} / {Jogador.Inventario.Capacidade}]");

                break;
            }           
        }
        
    }
    private void AbrirMapa(Mapa Mapa)
    {
        if (!Jogador.ContemMapa)
        {
            Console.WriteLine("Você não tem o mapa da cidade!");
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

                Console.WriteLine("Entrada inválida!");
            }

        }
    }
    private void ProcurarItens(List<Item> itensLocal)
    {
        if(itensLocal.Count > 0)
        {
            Console.WriteLine("Explorando, você encontrou:");

            for(int i = 0; i < itensLocal.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {itensLocal[i].Nome}");
            }

            while(true)
            {
                for(int i = 0; i < itensLocal.Count; i++)
                {
                    Console.WriteLine($"- {itensLocal[i].Nome}");
                }

                Console.WriteLine("Digite o item que deseja coletar ou [0] para Voltar.");
                Console.Write("--> ");

                int opcaoEscolhidaItem = Convert.ToInt32(Console.ReadLine());

                if(opcaoEscolhidaItem == 0)
                {
                    return;
                }
                if(opcaoEscolhidaItem < 1 || opcaoEscolhidaItem > itensLocal.Count)
                {
                    Console.WriteLine("Entrada inválida!");

                    continue;
                }

                DivisaoDeLinha();

                Item item = itensLocal[opcaoEscolhidaItem - 1];

                bool conseguiuGuardar = Jogador.Inventario.GuardarItem(item, Jogador);

                if(conseguiuGuardar)
                {
                    itensLocal.RemoveAt(opcaoEscolhidaItem - 1);
                }
            }    
        }
        else
        {
            Console.WriteLine("Você não encontrou nenhum item.");
        }
    }
    private void ExplorarArredores(List<Zombie> zombiesLocal)
    {
        if(zombiesLocal.Count > 0)
        {
            if(zombiesLocal.Count == 1)
            {
                Console.WriteLine($"Há {zombiesLocal.Count} zombie aqui.");

                DivisaoDeLinha();

                Console.WriteLine("O que deseja fazer quanto ao zombie?");
            }
            else
            {
                Console.WriteLine($"Há {zombiesLocal.Count} zombies aqui.");

                DivisaoDeLinha();

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
                    Console.WriteLine("Entrada inválida!");

                    continue;
                }            

                DivisaoDeLinha();

                if(opcaoCombate == 1)
                {
                    while (true)
                    {
                        Console.WriteLine("Qual zombie deseja enfrentar?");
                        
                        for(int i = 0; i < zombiesLocal.Count; i++)
                        {
                            Console.WriteLine($"[{i + 1}] {zombiesLocal[i].Tipo}");
                        }

                        Console.WriteLine("[0] Desistir");
                        Console.Write("--> ");

                        int opcaoEnfrentar = Convert.ToInt32(Console.ReadLine());

                        if(opcaoEnfrentar == 0)
                        {
                            return;
                        }

                        if(opcaoEnfrentar < 1 || opcaoEnfrentar > zombiesLocal.Count)
                        {
                            Console.WriteLine("Entrada inválida!");

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
                        Console.WriteLine("Você ignorou o zombie.");

                        return;                      
                    }
                    else
                    {
                        Console.WriteLine("Você ignorou os zombies.");

                        return;
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("Não há zombies aqui.");
        }
    }
    private void ProcurarSobreviventes(List<Npc> npcsLocal)
    {
        if(npcsLocal.Count > 0)
        {
            foreach(Npc npc in npcsLocal) Console.WriteLine($"Há uma pessoa aqui: {npc.Nome}");

            Console.WriteLine($"Deseja conversar com {npcsLocal[0].Nome}?");

            while (true)
            {
                Console.WriteLine("[1] Sim");
                Console.WriteLine("[2] Não");
                Console.Write("--> ");

                int opcaoConversa = Convert.ToInt32(Console.ReadLine());

                if(opcaoConversa < 1 || opcaoConversa > 2)
                {
                    Console.WriteLine("Entrada inválida!");

                    continue;
                }

                DivisaoDeLinha();

                switch (opcaoConversa)
                {
                    case 1:
                        ConversarComNpc(npcsLocal[0], Jogador);

                    break;
                } 
                if(opcaoConversa == 2)
                {
                    return;
                }              
            }
        }
        else
        {
            Console.WriteLine("Não há ninguém aqui.");
        }
    }
    private void IrParaOutroLocal()
    {
        EscolherDirecao(Jogador.LocalAtual);

        char opcaoDirecao = Convert.ToChar(Console.ReadLine().ToUpper());

        opcoesDirecao escolhaDirecao = (opcoesDirecao)opcaoDirecao;

        switch (escolhaDirecao)
        {
            case opcoesDirecao.Norte:
                if(Jogador.LocalAtual.Norte != null)
                {
                    Jogador.LocalAtual = Jogador.LocalAtual.Norte;
                    Jogador.SalaAtual = null;

                    Console.WriteLine("Agora, você está em: " + Jogador.LocalAtual.Nome);
                }                            

            break;
            case opcoesDirecao.Leste:
                if(Jogador.LocalAtual.Leste != null)
                {
                    Jogador.LocalAtual = Jogador.LocalAtual.Leste;
                    Jogador.SalaAtual = null;

                    Console.WriteLine("Agora, você está em: " + Jogador.LocalAtual.Nome);
                }                              
                
            break;
            case opcoesDirecao.Oeste:
                if(Jogador.LocalAtual.Oeste != null)
                {
                    Jogador.LocalAtual = Jogador.LocalAtual.Oeste;
                    Jogador.SalaAtual = null;

                    Console.WriteLine("Agora, você está em: " + Jogador.LocalAtual.Nome);
                }                              
                
            break;
            case opcoesDirecao.Sul:
                if(Jogador.LocalAtual.Sul != null)
                {
                    Jogador.LocalAtual = Jogador.LocalAtual.Sul;
                    Jogador.SalaAtual = null;

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