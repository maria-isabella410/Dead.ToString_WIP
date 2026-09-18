using rpgMissoesDoJogo;
using rpgNpc;
using rpgDialogo;
using rpgJogador;

namespace rpgNpcsDoJogo;

public class NpcsDoJogo
{
    public static Npc CriaPolicial()
    {
        Dialogo dialogo = new Dialogo("Ah, que bom ver outra pessoa viva!", "Sou o policial Ethan. Qual é seu nome?", "Bom te conhecer, {nome}!", "O caos tomou conta depois que um zombie conseguiu entrar na delegacia e todos morreram... quero dizer, todos menos eu. Vi colegas e amigos sendo mortos... foi horrível.", null, "Preciso pegar mais munição na sala de armas, mas o Robert estava com a chave e nunca mais o vi... a única coisa que sei é que ele tinha ido encher o tanque no posto de gasolina. Traga a chave da sala de armas para mim e eu te dou uma arma.", "Estou contando com você, {nome}.", "Ah, isso é uma pena. Nós dois poderíamos sair ganhando...", "Mandou bem! Agora posso recarregar minhas armas e você ganha uma shotgun novinha... bom trabalho, {nome}");

        return new Npc("Ethan", 120, 120, 0, 40, 0, MissoesDoJogo.CriaMissaoPolicial(), dialogo);
    }
    public static Npc CriaCientista()
    {
        Dialogo dialogo = new Dialogo("Heya! Algo vivo andando? Faz tempo que não vejo isso!", "Sou o cientista Freddie e talvez eu saiba como resolver todo esse caos... E quem é você?", "Ótimo te conhecer, {nome}! Tenho muita sorte de você ter aparecido, você pode me ajudar com algo.", "No início de tudo, o laboratório foi o grande culpado de tudo, diziam que nossos testes criaram os mortos-vivos... E, embora não estejam totalmente errados, a culpa não foi completamente nossa! Estávamos desenvolvendo um componente para reanimação de corpos de cobaias, mas algo aconteceu e o componente saiu do espaço de contenção e se espalhou pela rede de esgoto, contaminando a maior parte da população...", "Mas escute, em contrapartida, eu posso desenvolver uma cura e assim podemos voltar a - quase - toda a normalidade de antes! Fazer os mortos-vivos se tornarem vivos de novo. Sei que estou soando como um maluco, mas confie em mim, eu sei o que estou fazendo! Eu criei isso e posso destruir!", "Preciso das anotações do meu colega - descanse em paz Mark - pois só ele sabe o jeito certo de misturar os componentes para criar o antidoto. Vá até a biblioteca e encontre o diário dele e me traga, assim podemos salvar o mundo juntos.", "Hehe, sabia que podia contar com você, {nome}! Você será o grande héroi que salvou o mundo, e talvez eu seja preso... mas resolvemos isso depois! A prioridade é fazermos o antidoto!", "Eeh? Você está literalmente deixando o mundo morrer... Recusar ajudar um cientista a desenvolver uma cura parece pior do que ser o cientista que destruiu o mundo. Isso até me faz sentir menos culpado. Boa sorte na sua - curta - jornada...", "Heeya! Você encontrou o diário! Agora, mãos a obra! Você vai me ajudar a misturar tudo, {nome}!");

        return new Npc("Freddie", 100, 100, 0, 20, 0, MissoesDoJogo.CriaMissaoCientista(), dialogo);
    }
    public static Npc CriaPadre()
    {
        Dialogo dialogo = new Dialogo("Espera, não atire! Sou o padre dessa igreja!", " Sou o padre John! Bom ver que existem mais sobreviventes... qual é seu nome, jovem?", "Ótimo te conhecer, jovem {nome}!", "No início de tudo, as pessoas vieram se abrigar na igreja, e ficamos bem por um tempo graças aos recursos guardados. Mas depois de um tempo, as pessoas enlouqueceram e fugiram... Agora, só resta eu.", null, "Uma das pessoas levou meu cachorro Billy e eu não tenho condições de ir procura-lo, mas sei que ele está na floresta. Encontre meu cachorro Billy e eu te darei uma comida enlatada como agradecimento!", "Muito obrigado, boa sorte, {nome}...", "O quê? Ah, certo, você está em seu direito de recusar... acho que nunca mais verei meu Billy...", "Ah, meu pequeno Billy! Tão bom ver você bem!! Muito obrigado, jovem {nome}. Aqui está meu agradecimento!");

        return new Npc("John", 100, 100, 0, 10, 0, MissoesDoJogo.CriaMissaoPadre(), dialogo);
    }
    public static Npc CriaCachorro()
    {
        Dialogo dialogo = new Dialogo("Auauau!", "Auauau...?", null, "Auauauauau...", null, "Auau.", "Auuu!!", null, null);

        return new Npc("Billy", 40, 40, 0, 10, 0, null, dialogo);
    }
    public static Npc CriaEnfermeira()
    {
        Dialogo dialogo = new Dialogo("Oh, outro sobrevivente! Olá!", "Me chamo Grace e sou a única enfermeira desse hospital. Como você se chama?", "É tão bom ver alguém que não está morto, {nome}...", "Quando tudo aconteceu, o hospital estava um caos! Pacientes se transformando e atacando os médicos... fiz o que pude para cuidar dos doentes, mas não foi o suficiente... e agora me machuquei com um pedaço de ferro solto.", null, "Preciso dos remédios que estão no armário principal, mas não consigo encontrar as chaves, e os corredores estão cheios de mortos-vivos... Consegue encontrar a chave e trazer os remédios para mim? Irei tratar de todas as suas feridas se conseguir fazer isso.", "Obrigada, {nome}! Tome cuidado.", "Oh? Certo... boa sorte em sua jornada.", "Você trouxe os remédios, obrigada, {nome}! Agora, mostre-me onde estão seus machucados para que eu possa te ajudar...");

        return new Npc("Grace", 100, 100, 0, 10, 0, MissoesDoJogo.CriaMissaoEnfermeira(), dialogo);
    } 
    public static Npc CriaProfessora()
    {
        Dialogo dialogo = new Dialogo("Ah, você também está vivo! Espere um momento!", "Por favor, me ajude! Sou a professora Sarah, qual é seu nome?", "Por favor, {nome}, preciso que você vá buscar uma das minhas alunas!", "Tudo aconteceu tão rápido... em um momento, estávamos tendo aula normalmente e no outro haviam garras arranhando a porta da sala! E a partir daí, foi de mal para pior! Perdi todos os meus alunos...", null, "Minha única aluna restante se prendeu em uma sala de aula e eu não consigo chegar até ela para tira-la de lá! O nome dela é Mary, ela está com tanto medo... encontre a chave das salas de aula na sala dos professores e traga a pequena Mary para mim. Tenho um kit médico guardado, posso te entrega-lo como agradecimeto.", "Sério? Muito obrigada, {nome}! Que a sorte te acompanhe!", "Oh? Como você pode negar? Ela é apenas uma criança! Ugh, eu devia ter imaginado... apenas saia daqui!", "Mary, querida! Você está viva, isso é ótimo! Não precisa mais ter medo... muito obrigada, {nome}! Você salvou a vida dela, eu não poderia ser mais grata. Aqui está o kit médico que prometi, e boa sorte em sua jornada!");

        return new Npc("Sarah", 100, 100, 0, 20, 0, MissoesDoJogo.CriaMissaoProfessora(), dialogo);
    }
    public static Npc CriaCrianca()
    {
        Dialogo dialogo = new Dialogo("Ahh!! Não se aproxime!", "Ah! Você é uma pessoa normal igual a mim? Eu estou com tanto medo daqueles monstros!!", "Ah, a tia Sarah te mandou aqui? Que bom, eu estava tão assustada que me tranquei nessa sala!!", "Todos os meus coleguinhas começaram a ficar agressivos e então eu soltei a mão da tia Sarah e sai correndo com medo... ", null, null, "Você vai me levar até a tia Sarah? Obrigada!!", null, null);

        return new Npc("Mary", 60, 60, 0, 10, 0, null, dialogo);
    }
}