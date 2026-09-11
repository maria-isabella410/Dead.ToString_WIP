namespace rpgSerVivo;

public class SerVivo
{
    public int VidaMaxima {get; set;}
    public int Vida {get; set;}
    public int Ataque {get; set;}
    public int Defesa {get; set;}
    public int Agilidade {get; set;}

    public SerVivo(int vidamaxima, int vida, int ataque, int defesa, int agilidade)
    {
        this.VidaMaxima = vidamaxima;
        this.Vida = vida;
        this.Ataque = ataque;
        this.Defesa = defesa;
        this.Agilidade = agilidade;
    }

    public void TomarDano(int dano)
    {
        Vida -= dano;
    }
    public Boolean EstaVivo()
    {
        if (Vida <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}