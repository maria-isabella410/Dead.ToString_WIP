using rpgJogador;
using rpgItem;
using rpgArma;
using rpgConsumivel;
using rpgMenuInventario;
using rpgValidacaoInput;

namespace rpgInteracaoInventario;

public class InteracaoInventario
{
    private Jogador jogador;
    private MenuInventario menuInventario;
    private ValidacaoInput validacaoInput = new ValidacaoInput();

    public InteracaoInventario(Jogador jogador)
    {
        this.jogador = jogador;
        menuInventario = new MenuInventario(jogador);
    }
    public Boolean EquiparArma()
    {
        while (true)
        {                                   
            List<Arma> armas = jogador.Inventario.ListarArmas();

            if(armas.Count == 0)
            {
                Console.WriteLine("\nVocê não possui armas em seu inventário.\n");

                return false;
            }

            if(jogador.ArmaEquipada != null)
            {
                Boolean mesmaArmaEquipada = armas.Contains(jogador.ArmaEquipada);
                if(mesmaArmaEquipada && armas.Count == 1)
                {
                    Console.WriteLine("\nSua única arma já está equipada!");

                    return false;
                }
            }

            for(int i = 0; i < armas.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] — {armas[i].Nome}");
            }

            Console.WriteLine("\nQual arma deseja equipar? (0 para Voltar)");

            int opcaoArma = validacaoInput.OpcaoValidada(armas.Count);

            if(opcaoArma == 0)
            {
                return false;
            }

            if(jogador.ArmaEquipada != null)
            {
                if(armas[opcaoArma - 1].Tipo == jogador.ArmaEquipada.Tipo)
                {
                    Console.WriteLine("\nEssa arma já está equipada!");

                    return false;
                }
            }            

            jogador.Inventario.EquiparArma(armas[opcaoArma - 1], jogador);

            if(jogador.ArmaEquipada != null)
            {
                return true;
            }             
        }

    }
    public Boolean AbrirInventario()
    {
        while (true)
        {   
            var itens = jogador.Inventario.ListarItens(); 

            Console.WriteLine($"\nInventário: [{jogador.Inventario.EspacosOcupados} / {jogador.Inventario.Capacidade}]\n");

            if(itens.Count == 0)
            {
                Console.WriteLine("\nVocê não possui itens em seu inventário.");

                return false;
            }

            for(int i = 0; i < itens.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] — {itens[i].Nome}");
            }

            menuInventario.MostrarMenuInventario();

            opcoesInventario escolha = menuInventario.ReceberOpcao();
            
            if(escolha == 0)
            {
                return false;
            }

            switch (escolha)
            {
                case opcoesInventario.InspecionarItem:
                    Console.WriteLine("\nQual item deseja inspecionar? (0 para Voltar)\n");

                    for(int i = 0; i < itens.Count; i++)
                    {
                        Console.WriteLine($"[{i + 1}] — {itens[i].Nome}");
                    }

                    int idInspecao = validacaoInput.OpcaoValidada(itens.Count);

                    if(idInspecao == 0)
                    {
                        break;
                    }

                    jogador.Inventario.InspecionarItem(itens[idInspecao - 1]);

                    break;
                case opcoesInventario.ConsumirItem:
                    List<Consumivel> consumiveis = jogador.Inventario.ListarConsumiveis();
                    
                    if(consumiveis.Count == 0)
                    {
                        Console.WriteLine("\nVocê não possui nenhum consumível em seu inventário.");
                        
                        break;
                    }
                    if (jogador.Vida.Equals(jogador.VidaMaxima))
                    {
                        Console.WriteLine("\nSua vida está cheia, você não precisa consumir nenhum item.");

                        break;
                    }

                    Console.WriteLine("\nQual item deseja consumir? (0 para Voltar)\n");

                    for(int i = 0; i < consumiveis.Count; i++)
                    {
                        Console.WriteLine($"[{i + 1}] — {consumiveis[i].Nome}");
                    }

                    int escolhaConsumivel = validacaoInput.OpcaoValidada(consumiveis.Count);

                    if(escolhaConsumivel == 0)
                    {
                        break;
                    }

                    jogador.SeCurar(consumiveis[escolhaConsumivel - 1]);

                    jogador.Inventario.DescartarItem(consumiveis[escolhaConsumivel - 1]);

                    Console.WriteLine("\nVocê consumiu: " + consumiveis[escolhaConsumivel - 1].Nome);

                    Console.WriteLine($"\nVida atual: [{jogador.Vida} / {jogador.VidaMaxima}]");

                    return true;
                case opcoesInventario.DescartarItem:
                    Console.WriteLine("\nQual item deseja descartar? (0 para Voltar)\n");

                    for(int i = 0; i < itens.Count; i++)
                    {
                        Console.WriteLine($"[{i + 1}] — {itens[i].Nome}");
                    }
                    
                    int idDescarte = validacaoInput.OpcaoValidada(itens.Count);

                    if(idDescarte == 0)
                    {
                        break;
                    }

                    Item item = itens[idDescarte - 1];

                    jogador.Inventario.DescartarItem(item);

                    Console.WriteLine($"\nO item {item.Nome} foi descartado!");
                    
                    Console.WriteLine($"\nInventário: [{jogador.Inventario.EspacosOcupados} / {jogador.Inventario.Capacidade}]\n");

                    break;
                case opcoesInventario.EquiparArma:
                    if (EquiparArma())
                    {
                        return true;
                    }

                    break;
                    
                case opcoesInventario.DesequiparArma:
                    if(jogador.ArmaEquipada == null)
                    {
                        Console.WriteLine("\nNão é possível desequipar uma arma, pois você não está empunhando nenhuma.");

                        return false;
                    }
                    jogador.ArmaEquipada = null;

                    Console.WriteLine("\nVocê desequipou sua arma.");
                    return true;
            }           
        }
        
    }    
}