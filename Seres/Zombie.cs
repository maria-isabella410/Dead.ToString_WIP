using System.Data;
using rpgSerVivo;
using rpgTipoZombie;

namespace rpgZombie;

public class Zombie : SerVivo
{
    public TipoZombie ClasseZombie {get; set;}
    public String Tipo {get; set;}

    public Zombie(int vidamaxima, int vida, int ataque, int defesa, int agilidade, String? descricaofisica, TipoZombie classezombie, String tipo) : base(vidamaxima, vida, ataque, defesa, agilidade, descricaofisica)
    {
        this.ClasseZombie = classezombie;
        this.Tipo = tipo;
    }
}