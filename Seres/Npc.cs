using rpgPessoa;
using rpgMissao;
using rpgDialogo;

namespace rpgNpc;

public class Npc : Pessoa
{
    public Missao? Missao;
    public Dialogo Dialogo;
    public Boolean ConversouTudo = false;
    public Boolean DisseQuemEra = false;
    public Boolean ContouOqAconteceu = false;
    public Boolean OfereceuMissao = false;
    public Boolean AceitouMissao = false;
    public Boolean MissaoJaFoiConcluida = false;

    public Npc(String nome, int vidamaxima, int vida, int ataque, int defesa, int agilidade, Missao? missao, Dialogo dialogo) : base(vidamaxima, vida, ataque, defesa, agilidade, nome)
    {
        this.Missao = missao;
        this.Dialogo = dialogo;
    }
}