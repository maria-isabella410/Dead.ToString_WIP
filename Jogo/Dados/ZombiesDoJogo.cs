using rpgZombie;
using rpgTipoZombie;

namespace rpgZombiesDoJogo;

public class ZombiesDoJogo
{
    public static Zombie CriaZombieComumFraco()
    {
        return new Zombie(50, 50, 10, 10, 10, "Você vê uma... pessoa decadente. Pele podre, roupas rasgadas e emitindo sons guturais. Você sequer sabe se aquilo ainda pode ser considerado uma pessoa. O que você quer fazer?\n", TipoZombie.Comum, "Zombie Comum");
    }
    public static Zombie CriaZombieComumForte()
    {
        return new Zombie(80, 80, 15, 10, 15, "Você vê algo cambaleando. Roupas surradas, com uma espécie de armadura por cima. Parece ter sido um soldado antes de ter morrido. O que você quer fazer?\n", TipoZombie.Comum, "Zombie Armadurado");
    }
    public static Zombie CriaZombieJumper()
    {
        return new Zombie(100, 100, 20, 20, 35, "Você vê um ser esguio e deformado. O capuz sobre o rosto não permite visualizar a podridão completa do zombie. Ele parece ágil. O que você quer fazer?\n", TipoZombie.Especial, "Zombie Jumper");
    }
    public static Zombie CriaZombieTank()
    {
        return new Zombie(150, 150, 30, 35, 5, "Você vê um ser enorme na sua frente. Parece um ser modificado pelas condições e pelo tempo. É um zombie grande e forte. VO que você quer fazer?\n", TipoZombie.Especial, "Zombie Tank");
    }
    public static Zombie CriaZombieFinal()
    {
        return new Zombie(250, 250, 60, 45, 25, "Você vê um ser assustador. Alto, com braços deformados e veias que pulsam sob a pele. O som que sai de sua garganta é agoniante. Você sente que esse é o último inimigo que você deve derrubar. O que você quer fazer?\n", TipoZombie.Especial, "Zombie Mutante");
    }
    
}