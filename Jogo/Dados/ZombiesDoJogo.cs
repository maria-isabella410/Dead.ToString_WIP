using rpgZombie;
using rpgTipoZombie;

namespace rpgZombiesDoJogo;

public class ZombiesDoJogo
{
    public static Zombie CriaZombieComumFraco()
    {
        return new Zombie(40, 40, 8, 8, 10, "Você vê uma... pessoa decadente. Pele podre, roupas rasgadas e emitindo sons guturais. Você sequer sabe se aquilo ainda pode ser considerado uma pessoa. O que você quer fazer?\n", TipoZombie.ComumFraco, "Zombie Comum");
    }
    public static Zombie CriaZombieComumForte()
    {
        return new Zombie(60, 60, 12, 12, 15, "Você vê algo cambaleando. Roupas surradas, com uma espécie de armadura por cima. Parece ter sido um soldado antes de ter morrido. O que você quer fazer?\n", TipoZombie.ComumForte, "Zombie Armadurado");
    }
    public static Zombie CriaZombieJumper()
    {
        return new Zombie(50, 50, 15, 15, 35, "Você vê um ser esguio e deformado. O capuz sobre o rosto não permite visualizar a podridão completa do zombie. Ele parece ágil. O que você quer fazer?\n", TipoZombie.Jumper, "Zombie Jumper");
    }
    public static Zombie CriaZombieTank()
    {
        return new Zombie(70, 70, 16, 18, 5, "Você vê um ser enorme na sua frente. Parece um ser modificado pelas condições e pelo tempo. É um zombie grande e forte. O que você quer fazer?\n", TipoZombie.Tank, "Zombie Tank");
    }
    public static Zombie CriaZombieFinal()
    {
        return new Zombie(130, 130, 25, 22, 25, "Você vê um ser assustador. Alto, com braços deformados e veias que pulsam sob a pele. O som que sai de sua garganta é agoniante. Você sente que esse é o último inimigo que você deve derrubar. O que você quer fazer?\n", TipoZombie.Final, "Zombie Mutante");
    }    
}