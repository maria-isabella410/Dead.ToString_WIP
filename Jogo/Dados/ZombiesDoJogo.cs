using rpgZombie;
using rpgTipoZombie;

namespace rpgZombiesDoJogo;

public class ZombiesDoJogo
{
    public static Zombie CriaZombieComumFraco()
    {
        return new Zombie(40, 40, 8, 8, 10, "Você vê uma... pessoa decadente. Pele podre, roupas rasgadas e emitindo sons guturais. Você sequer sabe se aquilo ainda pode ser considerado uma pessoa.\n\nO que você quer fazer?\n", TipoZombie.ComumFraco, "Zombie Comum", ["Com um rosnado gutural, o zombie tenta cravar os dentes no seu ombro", "Balançando os braços sem coordenação, o zombie acerta um golpe bruto no seu peito", "O zombie avança cambaleando e arranha seu braço com as unhas sujas", "O zombie tropeça para frente e tenta morder seu pescoço de surpresa", "O zombie se joga contra você e derruba você com o peso do corpo"]);
    }
    public static Zombie CriaZombieComumForte()
    {
        return new Zombie(60, 60, 12, 12, 15, "Você vê algo cambaleando. Roupas surradas, com uma espécie de armadura por cima. Parece ter sido um soldado antes de ter morrido.\n\nO que você quer fazer?\n", TipoZombie.ComumForte, "Zombie Armadurado", ["Com um passo firme, o zombie investe contra você e tenta te derrubar no chão", "O zombie ergue os punhos e acerta um soco forte contra suas costelas", "Aproveitando o peso da armadura, o zombie dá uma ombrada que faz você recuar", "O zombie empurra você com o equipamento pesado e desequilibra sua postura", "O zombie avança e acerta uma joelhada pesada na sua coxa"]);
    }
    public static Zombie CriaZombieJumper()
    {
        return new Zombie(50, 50, 15, 15, 35, "Você vê um ser esguio e deformado. O capuz sobre o rosto não permite visualizar a podridão completa do zombie. Ele parece ágil.\n\nO que você quer fazer?\n", TipoZombie.Jumper, "Zombie Jumper", ["Em um movimento brusco, o zombie salta sobre você e rasga sua pele com um golpe rápido", "O zombie desliza para o lado e ataca suas costas antes que você consiga reagir", "Com uma agilidade assustadora, o zombie pula e acerta seu rosto", "O zombie salta de repente, atingindo seu peito com os dois pés e recuando em seguida", "Sob o capuz rasgado, o zombie avança como um vulto e desfere dois arranhões seguidos"]);
    }
    public static Zombie CriaZombieTank()
    {
        return new Zombie(70, 70, 16, 17, 5, "Você vê um ser enorme na sua frente. Parece um ser modificado pelas condições e pelo tempo. É um zombie grande e forte.\n\nO que você quer fazer?\n", TipoZombie.Tank, "Zombie Tank", ["O zombie ergue os dois braços enormes e desfere uma pancada esmagadora de cima para baixo", "Com um rugido grave, o zombie acerta um soco pesado que faz o ar sair dos seus pulmões", "O zombie avança como uma parede viva e arremessa você para trás com um empurrão brutal", "O zombie agarra você pelo ombro e o joga violentamente contra o chão", "O zombie desfere um golpe esmagador que faz seu corpo tremer", "O zombie desfere um golpe esmagador no seu ombro"]);
    }
    public static Zombie CriaZombieFinal()
    {
        return new Zombie(130, 130, 20, 20, 25, "Você vê um ser assustador. Alto, com braços deformados e veias que pulsam sob a pele. O som que sai de sua garganta é agoniante. Você sente que esse é o último inimigo que você deve derrubar.\n\nO que você quer fazer?\n", TipoZombie.Final, "Zombie Mutante", ["Com um grito agoniante, o zombie chicoteia o ar com o braço deformado e acerta você em cheio", "O zombie golpeia o chão e projeta o corpo contra você com uma velocidade assustadora", "Com uma força descomunal, o zombie acerta um golpe cruzado que quase te tira do chão", "O zombie desfere uma sequência violenta de golpes com os braços deformados", "O zombie acerta um ataque devastador que abala todo o seu corpo"]);
    }    
}