using rpgPessoa;
using rpgMissao;
using rpgDialogo;

namespace rpgNpc;

public class Npc : Pessoa
{
    public Missao? Missao {get; set;}
    public Dialogo Dialogo {get; set;}
    public Boolean ConversouTudo {get; set;} = false;

    public Npc(String nome, int vidamaxima, int vida, int ataque, int defesa, int agilidade, Missao? missao, Dialogo dialogo) : base(vidamaxima, vida, ataque, defesa, agilidade, nome)
    {
        this.Missao = missao;
        this.Dialogo = dialogo;
    }
}