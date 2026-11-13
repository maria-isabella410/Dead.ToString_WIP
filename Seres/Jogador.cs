using System.Runtime.Intrinsics.Arm;
using rpgArma;
using rpgInventario;
using rpgPessoa;
using rpgMissao;
using rpgLocal;
using rpgConsumivel;
using rpgSala;
using rpgNpc;

namespace rpgJogador;

public class Jogador : Pessoa
{
    public Inventario Inventario {get; private set;}
    public Arma? ArmaEquipada {get; set;} = null;
    public Boolean MochilaEquipada {get; set;} = false;
    public Boolean ColeteEquipado {get; set;} = false;
    public Boolean ContemMapa {get; set;} = false;
    public Boolean BillyEncontrado {get; set;} = false;
    public Boolean MaryEncontrada {get; set;} = false;
    public Missao? MissaoAtual {get; set;}
    public Local LocalAtual {get; set;}
    public List<Npc> NpcsConhecidos = new List<Npc>();
    public Sala? SalaAtual {get; set;}
    public Boolean AceitouMissao {get; set;} = false;
    public List<Missao> MissoesConcluidas = new List<Missao>();
    public Boolean ConseguiuCura = false;
    public Boolean MatouBoss = false;

    public Jogador(int vidamaxima, int vida, int ataque, int defesa, int agilidade, String? descricaofisica, String nome, Local localatual, Sala? salaatual) : base(vidamaxima, vida, ataque, defesa, agilidade, descricaofisica, nome)
    {
        this.Inventario = new Inventario(10);
        this.LocalAtual = localatual;
        this.SalaAtual = salaatual;
    }
    public void EquiparArma(Arma arma)
    {
        this.ArmaEquipada = arma;
    }
    public void SeCurar(Consumivel consumivel)
    {
        this.Vida = Math.Min(Vida + consumivel.QtdVidaRecuperada, VidaMaxima);      
    }
    public void ConheceNpc(Npc npc)
    {
        NpcsConhecidos.Add(npc);
    }
    public Boolean FinalizouJogo(Boolean matouBoss, Boolean conseguiuCura)
    {
        if (matouBoss && conseguiuCura)
        {
            Console.WriteLine("Parabéns! Você concluiu o jogo pelo final bom.\nVocê conseguiu a cura e tem uma nova expectativa de vida.\nAos poucos, conforme o mundo vai se ajeitando, você estará presente para testemunhar a humanidade se reerguer.\nVocê foi bem! Obrigada por jogar << Dead.ToString() >>!!");
            return true;
        }

        if(matouBoss && !conseguiuCura)
        {
            Console.WriteLine("Você conseguiu derrotar o chefão... mas será que foi o suficiente?\nSem uma cura, não há esperança de dias melhores.\nEspero que você sobreviva ao menos mais alguns dias.\nÉ como dizem, certo? Um dia após o outro...\nObrigada por jogar << Dead.ToString() >>!!");
            return true;
        }
        
        return false;
    }
}