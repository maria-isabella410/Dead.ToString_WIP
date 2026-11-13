using rpgSerVivo;

namespace rpgPessoa;

public class Pessoa : SerVivo
{
    public String Nome {get; set;}

    public Pessoa(int vidamaxima, int vida, int ataque, int defesa, int agilidade, String? descricaofisica, String nome) : base(vidamaxima, vida, ataque, defesa, agilidade, descricaofisica)
    {
        this.Nome = nome;
    }
}