using rpgZombie;
using rpgTipoZombie;

namespace rpgZombiesDoJogo;

public class ZombiesDoJogo
{
    public static Zombie CriaZombieComumFraco()
    {
        return new Zombie(50, 50, 10, 10, 10, TipoZombie.Comum, "Zombie Comum");
    }
    public static Zombie CriaZombieComumForte()
    {
        return new Zombie(80, 80, 15, 10, 15, TipoZombie.Comum, "Zombie Armadurado");
    }
    public static Zombie CriaZombieJumper()
    {
        return new Zombie(100, 100, 30, 20, 35, TipoZombie.Especial, "Zombie Jumper");
    }
    public static Zombie CriaZombieTank()
    {
        return new Zombie(150, 150, 45, 35, 5, TipoZombie.Especial, "Zombie Tank");
    }
    public static Zombie CriaZombieFinal()
    {
        return new Zombie(250, 250, 60, 45, 25, TipoZombie.Especial, "Zombie Mutante");
    }
    
}