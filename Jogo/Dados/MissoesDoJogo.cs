using rpgMissao;
using rpgItensDoJogo;

namespace rpgMissoesDoJogo;

public class MissoesDoJogo
{
    public static Missao CriaMissaoPolicial()
    {
        return new Missao("- Abra a sala de armas -", "Você deve encontrar a chave da sala de armas. Provavelmente está na sala dos armários. Encontre a chave, traga-a para o policial Ethan e você ganhará uma arma como agradecimento. (Recompensa: Shotgun)", ItensDoJogo.CriarChaveSalaDeArmas(), ItensDoJogo.CriarShotgun());
    }
    public static Missao CriaMissaoEnfermeira()
    {
        return new Missao("- Traga-me bandagens -", "Você deve entregar 3 bandagens para a enfermeira Grace, assim ela poderá tratar seus ferimentos. (Recompensa: Cura completa)", ItensDoJogo.CriarCaixaBandagens(), null);
    }
    public static Missao CriaMissaoCientista()
    {
        return new Missao("- Encontre documentos perdidos -", "Você deve ir até a biblioteca e encontrar uma pasta de documentos deixada pelo cientista Freddie. Se trouxer o que ele precisa, ele poderá finalizar a criação do antídoto. (Recompensa: Imunidade ao vírus - Final bom)", ItensDoJogo.CriarDiario(), ItensDoJogo.CriarAntidoto());
    }
    public static Missao CriaMissaoPadre()
    {
        return new Missao("- Billy está desaparecido -", "Você deve ir até a floresta e encontrar Billy, o cachorrinho do padre John. Se conseguir trazê-lo bem, será recompensado com um dos suprimentos que o padre tem guardado. (Recompensa: Comida enlatada)", null, ItensDoJogo.CriarComidaEnlatada());
    }
    public static Missao CriaMissaoProfessora()
    {
        return new Missao("- Mary está sozinha -", "Você deve buscar na escola a aluna Mary, que se perdeu durante o surto. Ela está trancada em uma sala, mas a professora Sarah não consegue ir até lá porque há muitos zombies no caminho. Traga Mary bem e será recompensado com um kit médico. (Recompensa: Kit médico)", null, ItensDoJogo.CriarKitMed());
    }

}