using rpgArma;
using rpgJogador;
using rpgSerVivo;
using rpgZombie;
using rpgInteracaoInventario;
using rpgValidacaoInput;

namespace rpgCombate;

public class Combate
{   
    private Jogador Jogador {get; set;}
    private Zombie Zombie {get; set;}
    private Random random {get; set;}
    private ValidacaoInput validacaoInput = new ValidacaoInput();
    private InteracaoInventario interacaoInventario = null!;

    public Combate(Jogador jogador, Zombie zombie, Random random)
    {
        this.Jogador = jogador;
        this.Zombie = zombie;
        this.random = random;
    }
    public Boolean IniciarCombate()
    {
        interacaoInventario = new InteracaoInventario(Jogador);

        while(Jogador.EstaVivo() && Zombie.EstaVivo())
        {
            bool fugiu = TurnoJogador();

            if(fugiu)
            {
                Console.WriteLine("\nVocê fugiu do combate!\n");
                return true;
            }

            Thread.Sleep(600);

            if (!Zombie.EstaVivo())
            {
                Console.WriteLine("\nVocê matou o zombie!\n");

                break;
            }

            TurnoZombie();
        }
                    
        if (!Jogador.EstaVivo())
        {
            Console.WriteLine("\nAcho que você está morto... que tal tentar de novo?");
        }

        return false;
    }
    private enum opcoesMenu
    {
        Atacar = 1,
        AbrirInventario = 2,
        EquiparArma = 3,
        Recarregar = 4,
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
        Console.WriteLine("[2] Abrir inventário");
        if(Jogador.ArmaEquipada != null)
        {
            Console.WriteLine("[3] Equipar outra arma");
            Console.WriteLine("[4] Recarregar");            
        }
        else
        {
            Console.WriteLine("[3] Equipar arma");
        }
        Console.WriteLine("[0] Fugir (50% de chance)");
       
    }
    private Boolean TurnoJogador()
    {
        bool acaoValida = false;

        while (!acaoValida)
        {
            StatusGeral();

            Menu();

            int escolhaCombate = -1;

            if(Jogador.ArmaEquipada != null)
            {
                escolhaCombate = validacaoInput.OpcaoValidada(4);
            }
            else
            {
                escolhaCombate = validacaoInput.OpcaoValidada(3);
            }                        

            if(escolhaCombate == 0)
            {
                if(TentarFugir())
                {
                    return true;
                }

                Console.WriteLine("\nVocê não conseguiu fugir!");

                acaoValida = true;
            }

            opcoesMenu escolha = (opcoesMenu)escolhaCombate;

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

                    acaoValida = true;                    

                    break;
                case opcoesMenu.EquiparArma:
                    if(interacaoInventario.EquiparArma())
                    {
                        acaoValida = true;
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
                case opcoesMenu.AbrirInventario:
                    interacaoInventario.AbrirInventario();
                    break;
            }           
        }

        return false;
    }
    private void TurnoZombie()
    {
        int danoTomado = 0;

        Console.WriteLine("\nO zombie te atacou!");

        danoTomado = CalcularDano(null, Zombie, Jogador);

        Jogador.TomarDano(danoTomado);

        Console.WriteLine($"\nVocê tomou {danoTomado} de dano!");
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
    private bool TentarFugir()
    {
        int chance = 50 + Jogador.Agilidade - Zombie.Agilidade;
        chance = Math.Clamp(chance, 10, 90);

        return random.Next(100) < chance;
    }    
}