using rpgArma;
using rpgJogador;
using rpgSerVivo;
using rpgZombie;
using rpgJogo;

namespace rpgCombate;

public class Combate
{   
    private Jogador Jogador {get; set;}
    private Zombie Zombie {get; set;}
    private Random random {get; set;}

    public Combate(Jogador jogador, Zombie zombie, Random random)
    {
        this.Jogador = jogador;
        this.Zombie = zombie;
        this.random = random;
    }
    public void IniciarCombate()
    {
        while(Jogador.EstaVivo() && Zombie.EstaVivo())
        {
            TurnoJogador();

            if (!Jogador.EstaVivo())
            {
                Console.WriteLine("Você está morto! Que tal tentar de novo?");

                break;
            }

            TurnoZombie();

            if (!Zombie.EstaVivo())
            {
                Console.WriteLine("Você matou o zombie!");
            }
        }
    }
    private enum opcoesMenu
    {
        Atacar = 1,
        EquiparArma = 2,
        Recarregar = 3,
        AbrirInventario = 4,
        Info = 0
    }

    private void StatusGeral()
    {
        Console.WriteLine($"Jogador: [{Jogador.Vida} / {Jogador.VidaMaxima}] HP");
        Console.WriteLine($"Zombie: [{Zombie.Vida} / {Zombie.VidaMaxima}] HP");
        if(Jogador.ArmaEquipada != null)
        {
            Console.WriteLine("Arma equipada: " + Jogador.ArmaEquipada.Nome);

            if (Jogador.ArmaEquipada.PodeRecarregar())
            {
                Console.WriteLine($"Munição: [{Jogador.ArmaEquipada.Municao} / {Jogador.ArmaEquipada.CapacidadeMunicao}]");    
            }
        }
        
    }
    private void Menu()
    {
        Console.WriteLine("O que quer fazer? (0 para Fugir.)");
        Console.WriteLine("[1] Atacar");
        Console.WriteLine("[2] Equipar Arma");
        Console.WriteLine("[3] Recarregar");
        Console.WriteLine("[4] Abrir inventário");
        Console.Write("--> ");
    }
    private void TurnoJogador()
    {
        bool acaoValida = false;

        while (!acaoValida)
        {
            StatusGeral();

            Menu();

            int opcao = Convert.ToInt32(Console.ReadLine());

            if(opcao < 0 || opcao > 4)
            {
                Console.WriteLine("\nEntrada inválida!");

                continue;
            }
            opcoesMenu escolha = (opcoesMenu)opcao;

            switch(escolha)
            {
                case opcoesMenu.Atacar:
                    if(Jogador.ArmaEquipada == null)
                    {
                        Console.WriteLine("\nVocê está sem armas equipadas! Escolha 'Equipar Arma' primeiro.");

                        break;
                    }
                    if(!Jogador.ArmaEquipada.TemMunicao())
                    {
                        Console.WriteLine("\nA arma está sem munição! Você precisa recarregar.");

                        break;
                    }

                    Jogador.ArmaEquipada.GastarMunicao();

                    int danoTomado = CalcularDano(Jogador.ArmaEquipada, Jogador, Zombie);
                        
                    if(Jogador.BonusDesvio)
                    {
                        Zombie.TomarDano(danoTomado + (danoTomado / 2));
                        Jogador.BonusDesvio = false;
                    }
                    else
                    {
                        Zombie.TomarDano(danoTomado);
                    }

                    Console.WriteLine("\nVocê atacou o zombie!");

                    Console.WriteLine($"\nVocê deu {danoTomado} de dano!");

                    Console.WriteLine($"\nA vida do zombie é: [{Zombie.Vida} / {Zombie.VidaMaxima}]");

                    acaoValida = true;                    

                    break;
                case opcoesMenu.EquiparArma:

                    Console.WriteLine("\nQual arma deseja equipar?\n");

                    List<Arma> armas = Jogador.Inventario.ListarArmas();

                    if (armas.Count == 0)
                    {
                        Console.WriteLine("Seu inventário não tem armas!");
                        break;
                    }

                    for(int i = 0; i < armas.Count; i++)
                    {
                        Console.WriteLine($"[{i + 1}] {armas[i].Nome}");
                    }

                    Console.Write("--> ");

                    if (int.TryParse(Console.ReadLine(), out int escolhaArma) && escolhaArma >= 1 && escolhaArma <= armas.Count)
                    {
                        Jogador.EquiparArma(armas[escolhaArma - 1]);

                        if(Jogador.ArmaEquipada != null)
                        {
                            Console.WriteLine("\nVocê equipou: " + Jogador.ArmaEquipada.Nome);
                            acaoValida = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nEscolha de arma inválida.");
                    }
                    break;
                case opcoesMenu.Recarregar:
                    if(Jogador.ArmaEquipada != null && Jogador.ArmaEquipada.PodeRecarregar())
                    {
                        Jogador.ArmaEquipada.Recarregar(Jogador.ArmaEquipada);
                        Console.WriteLine("\nVocê recarregou a arma.");
                        acaoValida = true;
                    }
                    else
                    {
                        Console.WriteLine("\nNão é possível recarregar!");
                    }
                    break;
            }           
        }
    }
    private void TurnoZombie()
    {
        int danoTomado = 0;

        Console.WriteLine("\nO zombie te atacou!");

        danoTomado = CalcularDano(null, Zombie, Jogador);

        Jogador.TomarDano(danoTomado);

        Console.WriteLine($"\nVocê tomou {danoTomado} de dano!");

        Console.WriteLine($"\nSua vida atual é: [{Jogador.Vida} / {Jogador.VidaMaxima}]");
    }
    private int CalcularDano(Arma? arma, SerVivo atacante, SerVivo defensor)
    {
        int dano = atacante.Ataque;

        if(arma != null)
        {
            dano += arma.Dano; 
        }

        dano -= defensor.Defesa;

        //variabilidade de dano para nao ficar estatico
        dano += random.Next(-4, 5);

        return Math.Max(1, dano);
    }
    // private Boolean TentarDesviar(SerVivo defensor, SerVivo atacante)
    // {
    //     int chance = 20 + defensor.Agilidade - atacante.Agilidade;

    //     chance = Math.Clamp(chance, 5, 80);

    //     return random.Next(100) < chance;
    // }
    
}