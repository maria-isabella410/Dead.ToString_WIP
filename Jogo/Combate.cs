using rpgArma;
using rpgJogador;
using rpgSerVivo;
using rpgZombie;
using rpgInteracaoInventario;
using rpgValidacaoInput;
using rpgTipoZombie;

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
                Console.WriteLine("\nVocê fugiu do combate!");
                return true;
            }

            Thread.Sleep(300);

            if (!Zombie.EstaVivo())
            {
                if(Zombie.ClasseZombie == TipoZombie.Final)
                {
                    Jogador.MatouBoss = true;
                }
                Console.WriteLine("\nVocê matou o zombie!");

                return true;
            }

            TurnoZombie();
        }
                    
        if (!Jogador.EstaVivo())
        {
            Console.WriteLine("\nVocê está morto... que tal tentar de novo?");
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
        Console.WriteLine($"\nJogador: [{Jogador.Vida} / {Jogador.VidaMaxima}] HP");
        Console.WriteLine($"Zombie: [{Zombie.Vida} / {Zombie.VidaMaxima}] HP");
        if(Jogador.ArmaEquipada != null)
        {
            Console.WriteLine($"Arma equipada: {Jogador.ArmaEquipada.Nome}");

            if (Jogador.ArmaEquipada.PodeRecarregar())
            {
                Console.WriteLine($"Munição: [{Jogador.ArmaEquipada.Municao} / {Jogador.ArmaEquipada.CapacidadeMunicao}]");    
            }
        }
        
    }
    private void Menu()
    {
        Console.WriteLine("\nO que quer fazer? (0 para Fugir)\n");
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

                Console.WriteLine("\nVocê não conseguiu fugir!\n");

                acaoValida = true;
            }

            opcoesMenu escolha = (opcoesMenu)escolhaCombate;

            switch(escolha)
            {
                case opcoesMenu.Atacar:
                    if(Jogador.ArmaEquipada == null)
                    {
                        Console.WriteLine("\nVocê está sem armas equipadas! Escolha 'Equipar Arma' primeiro.\n");

                        break;
                    }
                    if(Jogador.ArmaEquipada.PodeRecarregar() && !Jogador.ArmaEquipada.TemMunicao())
                    {
                        Console.WriteLine("\nA arma está sem munição! Você precisa recarregar.\n");

                        break;
                    }

                    if (Jogador.ArmaEquipada.PodeRecarregar())
                    {
                        Jogador.ArmaEquipada.GastarMunicao(random);
                    }                    

                    int danoTomado = CalcularDano(Jogador.ArmaEquipada, Jogador, Zombie);

                    Zombie.TomarDano(danoTomado);

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
                        if(Jogador.ArmaEquipada.Recarregar(Jogador.Inventario)){
                            acaoValida = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nNão é possível recarregar!\n");
                    }
                    break;
                case opcoesMenu.AbrirInventario:
                    if(interacaoInventario.AbrirInventario()) acaoValida = true;

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
            int danoDaArma = random.Next(arma.Dano / 2, arma.Dano + 1);
            
            dano += danoDaArma; 
        }

        dano -= defensor.Defesa;

        //variabilidade de dano para nao ficar estatico
        dano += random.Next(-3, 5);

        return Math.Max(1, dano);
    }
    private bool TentarFugir()
    {
        int chance = 50 + Jogador.Agilidade - Zombie.Agilidade;
        chance = Math.Clamp(chance, 10, 90);

        return random.Next(100) < chance;
    }    
}