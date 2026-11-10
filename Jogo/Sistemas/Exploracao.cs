using rpgItem;
using rpgJogador;
using rpgNpc;
using rpgZombie;
using rpgItensDoJogo;
using rpgMenuExploracao;
using rpgCombate;
using rpgMetodosDialogo;
using rpgNavegacao;
using rpgValidacaoInput;
using rpgTipoItem;

namespace rpgExploracao;

public class Exploracao
{
    private Jogador jogador;
    private MenuExploracao menuExploracao;
    private Navegacao navegacao;
    private ValidacaoInput validacaoInput;
    private Random random;

    public Exploracao(Jogador jogador, Random random)
    {
        this.jogador = jogador;
        menuExploracao = new MenuExploracao();
        navegacao = new Navegacao(jogador);
        validacaoInput = new ValidacaoInput();
        this.random = random;
    }
    public void Explorar()
    {
        List<Item> itensLocal = jogador.LocalAtual.Itens;
        List<Zombie> zombiesLocal = jogador.LocalAtual.Zombies;
        List<Npc> npcsLocal = jogador.LocalAtual.Npcs;
        
        Console.WriteLine($"Local atual: {jogador.LocalAtual.Nome}\n");
        
        if(jogador.LocalAtual.Salas.Count != 0)
        {
            if(jogador.SalaAtual == null)
            {
                navegacao.EscolherSala();
            }            

            if(jogador.SalaAtual != null)
            {          
                itensLocal = jogador.SalaAtual.Itens;
                zombiesLocal = jogador.SalaAtual.Zombies;
                npcsLocal = jogador.SalaAtual.Npcs;
            }
        }    

        while (true)
        {            
            menuExploracao.MostrarMenuExploracao();

            opcoesExplorar escolha = menuExploracao.ReceberOpcao();

            if(escolha == 0)
            {
                jogador.SalaAtual = null;
                return;
            }
            switch (escolha)
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
    public void ProcurarItens(List<Item> itensLocal)
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

                int escolhaItemColetar = validacaoInput.OpcaoValidada(itensLocal.Count);

                if(escolhaItemColetar == 0)
                {
                    return;
                }

                Item item = itensLocal[escolhaItemColetar - 1];

                if(item.tipoItem == TipoItem.Mochila || item.tipoItem == TipoItem.Colete)
                {
                    jogador.Inventario.EquiparItem(item, jogador);

                    Console.WriteLine($"\nVocê equipou o item: {itensLocal[escolhaItemColetar - 1].Nome}");

                    if(item.tipoItem == TipoItem.Mochila)
                    {
                        jogador.Inventario.Capacidade = 15;
                    }

                    itensLocal.RemoveAt(escolhaItemColetar - 1);

                    return;
                }

                if(item.tipoItem == TipoItem.Mapa)
                {
                    jogador.Inventario.EquiparItem(item, jogador);

                    Console.WriteLine($"\nVocê guardou o item: Mapa");

                    itensLocal.RemoveAt(escolhaItemColetar - 1);

                    return;
                }

                bool conseguiuGuardar = jogador.Inventario.GuardarItem(item, jogador);

                if(conseguiuGuardar)
                {
                    Console.WriteLine($"\nVocê coletou o item: {itensLocal[escolhaItemColetar - 1].Nome}");

                    itensLocal.RemoveAt(escolhaItemColetar - 1);

                    return;
                }
            }    
        }
        else
        {
            Console.WriteLine("\nVocê não encontrou nenhum item.\n");
        }
    }    
    public void ExplorarArredores(List<Zombie> zombiesLocal)
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
                Console.WriteLine("[0] Fugir");

                int escolhaCombate = validacaoInput.OpcaoValidada(1);

                if(escolhaCombate == 1)
                {
                    while (true)
                    {
                        Console.WriteLine("Qual zombie deseja enfrentar? ([0] para Desistir)");
                        
                        for(int i = 0; i < zombiesLocal.Count; i++)
                        {
                            Console.WriteLine($"[{i + 1}] {zombiesLocal[i].Tipo}");
                        }

                        int escolhaZombieEnfrentar = validacaoInput.OpcaoValidada(zombiesLocal.Count);

                        if(escolhaZombieEnfrentar == 0)
                        {
                            return;
                        }

                        int indiceZombie = escolhaZombieEnfrentar - 1;

                        Combate combate = new Combate(jogador, zombiesLocal[indiceZombie], random);

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
                   
                if(escolhaCombate == 0)
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
    public void ProcurarSobreviventes(List<Npc> npcsLocal)
    {
        if(npcsLocal.Count > 0)
        {   
            var metodosDialogo = new MetodosDialogo(jogador, npcsLocal[0]);
            
            Console.WriteLine($"Há uma pessoa aqui.\n");            
            Console.WriteLine($"Deseja interagir com ela?");

            while (true)
            {
                Console.WriteLine("[1] Sim");
                Console.WriteLine("[0] Não");

                int escolhaConversa = validacaoInput.OpcaoValidada(1);

                if(escolhaConversa == 1)
                {
                    metodosDialogo.DialogoComNpc();
                }               

                break;             
            }
        }
        else
        {
            Console.WriteLine("\nNão há ninguém aqui.");
        }
    }    
}