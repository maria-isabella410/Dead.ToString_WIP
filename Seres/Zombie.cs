using System.Data;
using rpgSerVivo;
using rpgTipoZombie;

namespace rpgZombie;

public class Zombie : SerVivo
{
    public TipoZombie ClasseZombie {get; set;}
    public String Tipo {get; set;}
    List<string> DescricoesAtaque = new List<string>();

    public Zombie(int vidamaxima, int vida, int ataque, int defesa, int agilidade, String? descricaofisica, TipoZombie classezombie, String tipo, List<string> descricoesataque) : base(vidamaxima, vida, ataque, defesa, agilidade, descricaofisica)
    {
        this.ClasseZombie = classezombie;
        this.Tipo = tipo;
        this.DescricoesAtaque = descricoesataque;
    }

    public string ObterDescAtaque(Random random)
    {
        if (DescricoesAtaque.Count == 0) return $"O zombie te ataca";
        return DescricoesAtaque[random.Next(DescricoesAtaque.Count)];
    }
}