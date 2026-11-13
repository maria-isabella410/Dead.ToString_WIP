using rpgZombie;
using rpgTipoZombie;

namespace rpgZombiesDoJogo;

public class ZombiesDoJogo
{
    public static Zombie CriaZombieComumFraco()
    {
        return new Zombie(50, 50, 15, 10, 10, "Você vê uma... pessoa decadente. Pele podre, roupas rasgadas e emitindo sons guturais. Você sequer sabe se aquilo ainda pode ser considerado uma pessoa. Você quer enfrentar o zombie?", TipoZombie.Comum, "Zombie Comum");
    }
    //concluir descricao fisica dps
    public static Zombie CriaZombieComumForte()
    {
        return new Zombie(80, 80, 25, 10, 15, "Você vê algo cambaleando. Roupas surradas, com uma espécie de armadura por cima. Parece ter sido um soldado antes de ter morrido. Você quer enfrentar o zombie?", TipoZombie.Comum, "Zombie Armadurado");
    }
    public static Zombie CriaZombieJumper()
    {
        return new Zombie(100, 100, 30, 20, 35, "Você vê um ser esguio e deformado. O capuz sobre o rosto não permite visualizar a podridão completa do zombie. Ele parece ágil. Você quer enfrentar o zombie?", TipoZombie.Especial, "Zombie Jumper");
    }
    public static Zombie CriaZombieTank()
    {
        return new Zombie(150, 150, 50, 35, 5, "Você vê um ser enorme na sua frente. Parece um ser modificado pelas condições e pelo tempo. É um zombie grande e forte. Você quer enfrentar o zombie?", TipoZombie.Especial, "Zombie Tank");
    }
    public static Zombie CriaZombieFinal()
    {
        return new Zombie(250, 250, 80, 45, 25, "Você vê um ser assustador. Alto, com braços deformados e veias que pulsam sob a pele. O som que sai de sua garganta é agoniante. Você sente que esse é o último inimigo que você deve derrubar. Você quer enfrentar o zombie?", TipoZombie.Especial, "Zombie Mutante");
    }
    
}