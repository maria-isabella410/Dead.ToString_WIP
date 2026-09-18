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

        Console.WriteLine("\nOlá, jogador! Seja bem-vindo(a) ao << System.Out.Dead >> !\n");
        Console.WriteLine("Durante essa jornada, qual será seu nome?\n");
        Console.Write("--> ");

        String nomeJogador = Console.ReadLine();

        Jogador = new Jogador(100, 100, 15, 10, 25, nomeJogador, Mapa.ruaPrincipal, null);

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
                Console.WriteLine("\nEntrada inválida!");

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
        DivisaoDeLinha();
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
        Console.WriteLine("O que quer fazer? ([0] para Voltar)");
        DivisaoDeLinha();
        Console.WriteLine("[1] Inspecionar item");
        Console.WriteLine("[2] Consumir item");
        Console.WriteLine("[3] Descartar item");
        Console.WriteLine("[4] Equipar arma");
        if(Jogador.ArmaEquipada != null)
        {
            Console.WriteLine("[5] Desequipar arma");
        }
        DivisaoDeLinha();
        Console.Write("--> "); 
             
    }
    private enum opcoesInventario
    {
        InspecionarItem = 1,
        ConsumirItem = 2,
        DescartarItem = 3,
        EquiparArma = 4,
        DesequiparArma = 5
    }
    public void MenuMapa()
    {
        DivisaoDeLinha();
        Console.WriteLine("[0] Voltar");
        DivisaoDeLinha();
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
        DivisaoDeLinha();
        Console.WriteLine("O que quer fazer? ([0] para Voltar)");
        DivisaoDeLinha();
        Console.WriteLine("[1] Procurar itens");
        Console.WriteLine("[2] Checar os arredores por zombies");
        Console.WriteLine("[3] Procurar sobreviventes");
        DivisaoDeLinha();
        Console.Write("--> "); 
    }
    private enum opcoesExplorar
    {
        ProcurarItens = 1,
        ChecarArredores = 2,
        ProcurarSobreviventes = 3
    }
    public void Introducao(Jogador Jogador)
    {
        DivisaoDeLinha();
        
        Console.WriteLine("O mundo como conhecíamos acabou...\n");
        Console.WriteLine("Mortos-vivos tomaram as ruas da cidade, devorando todos as pessoas que encontravam!\n");
        Console.WriteLine("Algumas pessoas conseguiram escapar e se esconderam em abrigos improvisados, mas os recursos são escassos e as ruas são perigosas...\n");
        Console.WriteLine($"Você, {Jogador.Nome}, é uma dessas pessoas. Você sobreviveu até aqui, porém, mais do que sobreviver, você quer descobrir o que causou tudo isso e como resolver!\n");
        Console.WriteLine("Busque recursos, ajude outros sobreviventes, encontre respostas e claro, sobreviva.\n");
        
        DivisaoDeLinha();

        Mapa.MostrarLocalAtual(Jogador);
    }
    public void Explorar()
    {
        List<Item> itensLocal = Jogador.LocalAtual.Itens;
        List<Zombie> zombiesLocal = Jogador.LocalAtual.Zombies;
        List<Npc> npcsLocal = Jogador.LocalAtual.Npcs;

        DivisaoDeLinha();
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

            DivisaoDeLinha();
            Console.WriteLine("O que deseja fazer? ([0] para Voltar)");
            DivisaoDeLinha();
        }       

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
                Console.WriteLine("\nEntrada inválida!");

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
                    Console.WriteLine("\nEntrada inválida!");
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
            Console.WriteLine("Missão atual: " + Jogador.MissaoAtual.NomeDaMissao);
        }
        if(Jogador.ArmaEquipada != null)
        {
            Console.WriteLine("Arma equipada: " + Jogador.ArmaEquipada.Nome);
        }
    }
    public void ConversarComNpc(Npc npc)
    {
        DivisaoDeLinha();

        MetodosDialogo dialogo = new MetodosDialogo();

        Console.WriteLine(npc.Dialogo.Saudacao);

        // dialogo.ContinuarDialogo(npc);        
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
            Console.WriteLine($"Sala atual: < {Jogador.SalaAtual.Nome} >\n");
            Console.WriteLine(Jogador.SalaAtual.Descricao);
        } 

        DivisaoDeLinha();
        Console.WriteLine("Para onde deseja ir? ([0] para Voltar)");
        DivisaoDeLinha();

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
            DivisaoDeLinha();
            Console.Write("--> ");

            int opcaoEscolhidaSala = Convert.ToInt32(Console.ReadLine());

            if(opcaoEscolhidaSala == 0)
            {
                return;
            }

            if(opcaoEscolhidaSala < 1 || opcaoEscolhidaSala > salasDisponiveis.Count)
            {
                Console.WriteLine("\nEntrada inválida!");

                continue;
            }

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
    public void AbrirInventario()
    {
        List<Item> itens = Jogador.Inventario.ListarItens();

        Console.WriteLine($"\nInventário: [{Jogador.Inventario.EspacosOcupados} / {Jogador.Inventario.Capacidade}]\n");

        if(itens.Count == 0)
        {
            Console.WriteLine("\nVocê não possui itens em seu inventário.");

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

            if(Jogador.ArmaEquipada == null && opcaoInventario == 5)
            {
                Console.WriteLine("\nEntrada inválida!");

                continue;
            }

            if(opcaoInventario < 1 || opcaoInventario > 5)
            {
                Console.WriteLine("\nEntrada inválida!");

                continue;
            }

            opcoesInventario escolhaInventario = (opcoesInventario)opcaoInventario;

            switch (escolhaInventario)
            {
                case opcoesInventario.InspecionarItem:
                    DivisaoDeLinha();
                    Console.WriteLine("Qual item deseja inspecionar? ([0] para Voltar)");
                    DivisaoDeLinha();

                    for(int i = 0; i < itens.Count; i++)
                    {
                        Console.WriteLine($"[{i + 1}] {itens[i].Nome}");
                    }

                    DivisaoDeLinha();
                    Console.Write("--> ");

                    int idInspecao = Convert.ToInt32(Console.ReadLine());

                    if(idInspecao == 0)
                    {
                        break;
                    }

                    if(idInspecao < 1 || idInspecao > itens.Count)
                    {
                        Console.WriteLine("\nEntrada inválida!");

                        continue;
                    }

                    Jogador.Inventario.InspecionarItem(itens[idInspecao - 1]);

                break;
                case opcoesInventario.ConsumirItem:
                    List<Consumivel> consumiveis = Jogador.Inventario.ListarConsumiveis();
                    
                    if(consumiveis.Count == 0)
                    {
                        Console.WriteLine("\nVocê não possui nenhum consumível em seu inventário.");
                        
                        break;
                    }
                    if (Jogador.Vida.Equals(Jogador.VidaMaxima))
                    {
                        Console.WriteLine("\nSua vida está cheia, você não precisa consumir nenhum item.");

                        break;
                    }

                    DivisaoDeLinha();
                    Console.WriteLine("Qual item deseja consumir? ([0] para Voltar)");
                    DivisaoDeLinha();

                    for(int i = 0; i < consumiveis.Count; i++)
                    {
                        Console.WriteLine($"[{i + 1}] {consumiveis[i].Nome}");
                    }

                    DivisaoDeLinha();
                    Console.Write("--> ");

                    int escolhaConsumivel = Convert.ToInt32(Console.ReadLine());

                    if(escolhaConsumivel == 0)
                    {
                        break;
                    }

                    if(escolhaConsumivel < 1 || escolhaConsumivel > consumiveis.Count)
                    {
                        Console.WriteLine("\nEntrada inválida!");

                        continue;
                    }
                    Jogador.SeCurar(consumiveis[escolhaConsumivel - 1]);
                    Jogador.Inventario.DescartarItem(consumiveis[escolhaConsumivel - 1]);

                    Console.WriteLine("\nVocê consumiu: " + consumiveis[escolhaConsumivel - 1].Nome);
                    Console.WriteLine($"\nVida atual: [{Jogador.Vida} / {Jogador.VidaMaxima}]");

                    DivisaoDeLinha();

                break;
                case opcoesInventario.DescartarItem:
                    DivisaoDeLinha();
                    Console.WriteLine("Qual item deseja descartar? ([0] para Voltar)");
                    DivisaoDeLinha();

                    for(int i = 0; i < itens.Count; i++)
                    {
                        Console.WriteLine($"[{i + 1}] {itens[i].Nome}");
                    }
                    
                    DivisaoDeLinha();
                    Console.Write("--> ");

                    int idDescarte = Convert.ToInt32(Console.ReadLine());

                    if(idDescarte == 0)
                    {
                        break;
                    }

                    if(idDescarte < 1 || idDescarte > itens.Count)
                    {
                        Console.WriteLine("\nEntrada inválida!");

                        continue;
                    }

                    Item item = itens[idDescarte - 1];

                    Jogador.Inventario.DescartarItem(item);

                    Console.WriteLine($"\nO item {item.Nome} foi descartado!");
                    Console.WriteLine($"\nInventário: [{Jogador.Inventario.EspacosOcupados} / {Jogador.Inventario.Capacidade}]");

                break;
                case opcoesInventario.EquiparArma:
                    List<Arma> armas = Jogador.Inventario.ListarArmas();

                    if(armas.Count == 0)
                    {
                        Console.WriteLine("\nVocê não possui armas em seu inventário.");

                        break;
                    }

                    for(int i = 0; i < armas.Count; i++)
                    {
                        Console.WriteLine($"[{i + 1}] {armas[i].Nome}");
                    }

                    DivisaoDeLinha();
                    Console.WriteLine("Qual arma deseja equipar? ([0] para Voltar)");
                    DivisaoDeLinha();

                    Jogador.Inventario.ListarArmas();
                    
                    DivisaoDeLinha();
                    Console.Write("--> ");

                    int opcaoArma = Convert.ToInt32(Console.ReadLine());

                    if(opcaoArma == 0)
                    {
                        break;
                    }

                    if(opcaoArma < 1 || opcaoArma > itens.Count)
                    {
                        Console.WriteLine("\nEntrada inválida!");

                        continue;
                    }

                    if(armas[opcaoArma - 1] == Jogador.ArmaEquipada)
                    {
                        Console.WriteLine("\nEssa arma já está equipada.");

                        break;
                    }

                    Jogador.Inventario.EquiparArma(armas[opcaoArma - 1], Jogador);

                break;
                case opcoesInventario.DesequiparArma:
                    Jogador.ArmaEquipada = null;

                    Console.WriteLine("\nVocê desequipou sua arma.");
                break;
            }           
        }
        
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
                DivisaoDeLinha();
                Console.WriteLine("Digite o item que deseja coletar ou [0] para Voltar.");
                DivisaoDeLinha();
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

                DivisaoDeLinha();

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

                DivisaoDeLinha();
                Console.WriteLine("O que deseja fazer quanto ao zombie?");
                DivisaoDeLinha();
            }
            else
            {
                Console.WriteLine($"Há {zombiesLocal.Count} zombies aqui.");

                DivisaoDeLinha();
                Console.WriteLine("O que deseja fazer quanto aos zombies?");
                DivisaoDeLinha();
            }

            while (true)
            {
                Console.WriteLine("[1] Lutar");
                Console.WriteLine("[2] Ignorar");
                DivisaoDeLinha();
                Console.Write("--> ");

                int opcaoCombate = Convert.ToInt32(Console.ReadLine());

                if(opcaoCombate < 1 || opcaoCombate > 2)
                {
                    Console.WriteLine("\nEntrada inválida!");

                    continue;
                }            

                DivisaoDeLinha();

                if(opcaoCombate == 1)
                {
                    while (true)
                    {
                        DivisaoDeLinha();
                        Console.WriteLine("Qual zombie deseja enfrentar? ([0] para Desistir)");
                        DivisaoDeLinha();
                        
                        for(int i = 0; i < zombiesLocal.Count; i++)
                        {
                            Console.WriteLine($"[{i + 1}] {zombiesLocal[i].Tipo}");
                        }

                        DivisaoDeLinha();
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
            DivisaoDeLinha();
            Console.WriteLine($"Há uma pessoa aqui.\n");            
            Console.WriteLine($"Deseja interagir com ela?");
            DivisaoDeLinha();

            while (true)
            {
                Console.WriteLine("[1] Sim");
                Console.WriteLine("[2] Não");
                DivisaoDeLinha();
                Console.Write("--> ");

                int opcaoConversa = Convert.ToInt32(Console.ReadLine());

                if(opcaoConversa < 1 || opcaoConversa > 2)
                {
                    Console.WriteLine("\nEntrada inválida!");

                    continue;
                }

                DivisaoDeLinha();

                if(opcaoConversa == 1)
                {
                    ConversarComNpc(npcsLocal[0]);
                }               

                if(opcaoConversa == 2)
                {
                    return;
                }              
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

        char opcaoDirecao = Convert.ToChar(Console.ReadLine().ToUpper());

        opcoesDirecao escolhaDirecao = (opcoesDirecao)opcaoDirecao;

        switch (escolhaDirecao)
        {
            case opcoesDirecao.Norte:
                if(Jogador.LocalAtual.Norte != null)
                {
                    Jogador.LocalAtual = Jogador.LocalAtual.Norte;
                    Jogador.SalaAtual = null;

                    Console.WriteLine("\nAgora, você está em: " + Jogador.LocalAtual.Nome);
                }                            

            break;
            case opcoesDirecao.Leste:
                if(Jogador.LocalAtual.Leste != null)
                {
                    Jogador.LocalAtual = Jogador.LocalAtual.Leste;
                    Jogador.SalaAtual = null;

                    Console.WriteLine("\nAgora, você está em: " + Jogador.LocalAtual.Nome);
                }                              
                
            break;
            case opcoesDirecao.Oeste:
                if(Jogador.LocalAtual.Oeste != null)
                {
                    Jogador.LocalAtual = Jogador.LocalAtual.Oeste;
                    Jogador.SalaAtual = null;

                    Console.WriteLine("\nAgora, você está em: " + Jogador.LocalAtual.Nome);
                }                              
                
            break;
            case opcoesDirecao.Sul:
                if(Jogador.LocalAtual.Sul != null)
                {
                    Jogador.LocalAtual = Jogador.LocalAtual.Sul;
                    Jogador.SalaAtual = null;

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