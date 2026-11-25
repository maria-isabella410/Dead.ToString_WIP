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
using rpgNpcsDoJogo;

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
        this.random = random;
        menuExploracao = new MenuExploracao();
        navegacao = new Navegacao(jogador, random);
        validacaoInput = new ValidacaoInput();
    }
    public Boolean Explorar()
    {
        while (true)
        {
            List<Item> itensLocal = jogador.LocalAtual.Itens;
            List<Zombie> zombiesLocal = jogador.LocalAtual.Zombies;
            List<Npc> npcsLocal = jogador.LocalAtual.Npcs;

            if (jogador.SalaAtual != null) Console.WriteLine($"Sala atual: {jogador.SalaAtual.Nome}");
            else Console.WriteLine($"Local atual: {jogador.LocalAtual.Nome}");
            
            if(jogador.LocalAtual.Salas.Count != 0)
            {
                if(jogador.SalaAtual == null)
                {
                    navegacao.EscolherSala();

                    if (jogador.SalaAtual == null) return true;
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
                    if(jogador.LocalAtual.Salas.Count > 0)
                    {
                        jogador.SalaAtual = null;

                        break;
                    }

                    return true;
                }
                switch (escolha)
                {
                    case opcoesExplorar.ProcurarItens:
                        ProcurarItens(itensLocal); 
                    break;

                    case opcoesExplorar.ChecarArredores:
                        Boolean jogadorVivo = ExplorarArredores(zombiesLocal); 

                        if(!jogadorVivo) return false;
                    break;

                    case opcoesExplorar.ProcurarSobreviventes:
                        ProcurarSobreviventes(npcsLocal);
                    break;
                }                                      
            } 
        }
    }
    public void ProcurarItens(List<Item> itensLocal)
    {
        if(itensLocal.Count > 0)
        {
            Console.WriteLine("Explorando, você encontrou:\n");

            for(int i = 0; i < itensLocal.Count; i++)
            {
                Console.WriteLine($"— {i + 1} — {itensLocal[i].Nome}");
            }

            while(true)
            {
                Console.WriteLine("\nDigite o item que deseja coletar ou [0] para Voltar.");

                int escolhaItemColetar = validacaoInput.OpcaoValidada(itensLocal.Count);

                if(escolhaItemColetar == 0)
                {
                    return;
                }

                Item item = itensLocal[escolhaItemColetar - 1];

                if(item.tipoItem == TipoItem.Mochila || item.tipoItem == TipoItem.Colete)
                {
                    jogador.Inventario.EquiparItem(item, jogador);

                    itensLocal.RemoveAt(escolhaItemColetar - 1);

                    return;
                }

                if(item.tipoItem == TipoItem.Mapa)
                {
                    jogador.Inventario.EquiparItem(item, jogador);

                    itensLocal.RemoveAt(escolhaItemColetar - 1);

                    return;
                }

                bool conseguiuGuardar = jogador.Inventario.GuardarItem(item, jogador);

                if(conseguiuGuardar)
                {
                    Console.WriteLine($"Você coletou o item: {itensLocal[escolhaItemColetar - 1].Nome}");

                    itensLocal.RemoveAt(escolhaItemColetar - 1);

                    return;
                }
            }    
        }
        else
        {
            Console.WriteLine("Você não encontrou nenhum item.");
        }
    }    
    public Boolean ExplorarArredores(List<Zombie> zombiesLocal)
    {
        while(zombiesLocal.Count > 0)
        {
            if(zombiesLocal.Count > 0)
            {
                var zombieNoLocal = zombiesLocal[0];

                if(zombiesLocal.Count == 1)
                {
                    Console.WriteLine("Há 1 zombie aqui.\n");
                }
                else
                {
                    Console.WriteLine($"Há {zombiesLocal.Count} zombies aqui.\n");
                }            

                Console.WriteLine(zombieNoLocal.DescricaoFisica);

                Console.WriteLine("[1] Lutar");
                Console.WriteLine("[0] Ignorar");

                int escolhaCombate = validacaoInput.OpcaoValidada(1);

                if(escolhaCombate == 0)
                {
                    if(zombiesLocal.Count == 1)
                    {
                        Console.WriteLine("Você ignorou o zombie.");
                    }
                    else
                    {
                        Console.WriteLine("Você ignorou os zombies.");
                    }

                    return true; 
                }

                Combate combate = new Combate(jogador, zombieNoLocal, random);
                Boolean jogadorVivo = combate.IniciarCombate();

                if (!jogadorVivo)
                {
                    return false;
                }

                if(!zombieNoLocal.EstaVivo())
                {
                    zombiesLocal.RemoveAt(0);
                }         

                return true;
            }            
        }

        Console.WriteLine("Não há zombies aqui.");
        
        return true;
    }
    public void ProcurarSobreviventes(List<Npc> npcsLocal)
    {
        if(npcsLocal.Count == 0)
        {
            Console.WriteLine("Não há ninguém aqui.");
            return;
        }
        var npcNoLocal = npcsLocal[0];
        var metodosDialogo = new MetodosDialogo(jogador, npcNoLocal);

        Boolean ehCachorro = npcsLocal[0].Nome == NpcsDoJogo.CriaCachorro().Nome;

        Console.WriteLine(npcNoLocal.DescricaoFisica);

        if (!ehCachorro)
        {
            Console.WriteLine("[1] Sim");
            Console.WriteLine("[0] Não");

            int escolhaConversa = validacaoInput.OpcaoValidada(1);

            if(escolhaConversa == 0) return;
            
            metodosDialogo.DialogoComNpc();

            return;
        }   
        else
        {
            Boolean pegouCachorro = metodosDialogo.DialogoComCachorro();

            if (pegouCachorro)
            {
                npcsLocal.RemoveAt(0);
            }

            return;
        }
    }
}