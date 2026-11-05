using rpgJogador;
using rpgItem;
using rpgArma;
using rpgConsumivel;

namespace rpgMenuInventario;

public class MenuInventario
{
    private Jogador jogador;

    public MenuInventario(Jogador jogador)
    {
        this.jogador = jogador;
    }
    private enum opcoesInventario
    {
        InspecionarItem = 1,
        ConsumirItem = 2,
        DescartarItem = 3,
        EquiparArma = 4,
        DesequiparArma = 5
    }
    public void menuInventario(Jogador jogador)
    {      
        Console.WriteLine("O que quer fazer? ([0] para Voltar)");
        Console.WriteLine("[1] Inspecionar item");
        Console.WriteLine("[2] Consumir item");
        Console.WriteLine("[3] Descartar item");
        Console.WriteLine("[4] Equipar arma");
        if(jogador.ArmaEquipada != null) Console.WriteLine("[5] Desequipar arma");
        Console.Write("--> "); 
    }
    public void AbrirInventario(Jogador jogador)
    {
        List<Item> itens = jogador.Inventario.ListarItens();

        Console.WriteLine($"\nInventário: [{jogador.Inventario.EspacosOcupados} / {jogador.Inventario.Capacidade}]\n");

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
            menuInventario(jogador);

            int opcaoInventario = Convert.ToInt32(Console.ReadLine());
            
            if(opcaoInventario == 0)
            {
                return;
            } 

            //arrumar dps o resto das verificacoes

            if(jogador.ArmaEquipada == null && opcaoInventario >= 5)
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
                    Console.WriteLine("Qual item deseja inspecionar? ([0] para Voltar)");

                    for(int i = 0; i < itens.Count; i++)
                    {
                        Console.WriteLine($"[{i + 1}] {itens[i].Nome}");
                    }

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

                    Console.WriteLine("Qual item deseja consumir? ([0] para Voltar)");

                    for(int i = 0; i < consumiveis.Count; i++)
                    {
                        Console.WriteLine($"[{i + 1}] {consumiveis[i].Nome}");
                    }

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
                    jogador.SeCurar(consumiveis[escolhaConsumivel - 1]);
                    jogador.Inventario.DescartarItem(consumiveis[escolhaConsumivel - 1]);

                    Console.WriteLine("\nVocê consumiu: " + consumiveis[escolhaConsumivel - 1].Nome);
                    Console.WriteLine($"\nVida atual: [{jogador.Vida} / {jogador.VidaMaxima}]");

                break;
                case opcoesInventario.DescartarItem:
                    Console.WriteLine("Qual item deseja descartar? ([0] para Voltar)");

                    for(int i = 0; i < itens.Count; i++)
                    {
                        Console.WriteLine($"[{i + 1}] {itens[i].Nome}");
                    }
                    
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

                    jogador.Inventario.DescartarItem(item);

                    Console.WriteLine($"\nO item {item.Nome} foi descartado!");
                    Console.WriteLine($"\nInventário: [{jogador.Inventario.EspacosOcupados} / {jogador.Inventario.Capacidade}]");

                break;
                case opcoesInventario.EquiparArma:
                    List<Arma> armas = jogador.Inventario.ListarArmas();

                    if(armas.Count == 0)
                    {
                        Console.WriteLine("\nVocê não possui armas em seu inventário.");

                        break;
                    }

                    for(int i = 0; i < armas.Count; i++)
                    {
                        Console.WriteLine($"[{i + 1}] {armas[i].Nome}");
                    }

                    Console.WriteLine("Qual arma deseja equipar? ([0] para Voltar)");

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

                    if(armas[opcaoArma - 1] == jogador.ArmaEquipada)
                    {
                        Console.WriteLine("\nEssa arma já está equipada.");

                        break;
                    }

                    jogador.Inventario.EquiparArma(armas[opcaoArma - 1], jogador);

                break;
                case opcoesInventario.DesequiparArma:
                    jogador.ArmaEquipada = null;

                    Console.WriteLine("\nVocê desequipou sua arma.");
                break;
            }           
        }
        
    }
}