using rpgArma;
using rpgChave;
using rpgConsumivel;
using rpgItem;
using rpgMunicao;
using rpgPorta;
using rpgTipoArma;
using rpgTipoChave;
using rpgTipoMunicao;

namespace rpgItensDoJogo;

public class ItensDoJogo
{
    //armas
    public static Arma CriarPistola()
    {
        return new Arma("Pistola", "Uma arma eficiente contra inimigos. (Causa 25 de dano)", 25, TipoArma.Pistola, TipoMunicao.MunicaoPistola, 12, 12);
    }
    public static Arma CriarShotgun()
    {
        return new Arma("Shotgun", "Uma arma poderosa que faz um bom estrago. (Causa 50 de dano)", 50, TipoArma.Shotgun, TipoMunicao.MunicaoShotgun, 8, 8);
    }
    public static Arma CriarFaca()
    {
        return new Arma("Faca", "Uma arma pequena, mas eficiente. (Causa 10 de dano)", 10, TipoArma.Faca, null, null, null);
    }

    //consumiveis
    public static Consumivel CriarBandagem()
    {
        return new Consumivel("Bandagem", "Recupera um pouco da sua vida. (Cura 20)", 20);
    }
    public static Consumivel CriarKitMed()
    {
        return new Consumivel("Kit Médico", "Recupera grande parte da sua vida. (Cura 70)", 70);
    }
    public static Consumivel CriarSpray()
    {
        return new Consumivel("Spray", "Recupera boa parte sua vida. (Cura 40)", 40);
    }
    public static Consumivel CriarAgua()
    {
        return new Consumivel("Garrafa de Água", "Mata sua sede. (Cura 25)", 25);
    }
    public static Consumivel CriarComidaEnlatada()
    {
        return new Consumivel("Comida enlatada", "Uma comida feita para durar bastante. (Cura 25)", 25);
    }
    public static Consumivel CriarAntidoto()
    {
        return new Consumivel("Antídoto", "A esperança da humanidade.", 100);
    }

    //chaves
    public static Chave CriarChaveSalaDeArmas()
    {
        return new Chave("Chave da sala de armas", "A chave que o policial Ethan estava procurando. Com ela, você consegue desbloquear a sala de armas.", TipoChave.SalaDeArmas);
    }
    public static Chave CriarChaveSalaDeAula()
    {
        return new Chave("Chave da sala de aula", "A chave que abre as salas de aula da escola. Com ela você consegue explorar mais lugares e procurar a garotinha Mary.", TipoChave.SalaDeAula);
    }
    public static Chave CriarChaveSalaBiblioteca()
    {
        return new Chave("Chave da biblioteca", "A chave abre a sala de arquivos confidenciais da biblioteca. Com ela, você consegue encontrar os arquivos que o cientista Freddie precisa.", TipoChave.SalaBiblioteca);
    }
    public static Chave CriarChaveEstoqueHospital()
    {
        return new Chave("Chave do estoque do hospital", "A chave que abre a sala de estoque do hospital. Com ela, você consegue encontrar diversos itens de cura.", TipoChave.EstoqueHospital);
    }
    public static Chave CriarChaveLaboratorio()
    {
        return new Chave("Chave do hall do laboratório", "A chave que dá acesso às áreas restritas do laboratório. Com ela, você consegue chegar à área de experimentos e ajudar o cientista Freddie a concluir a pesquisa dele.", TipoChave.Laboratorio);
    }
    
    //itens comuns
    public static Item CriarMapaDaCidade()
    {
        return new Item("Mapa da cidade", "Explorar a cidade se torna uma tarefa mais fácil.");
    }
    public static Item CriarMochila()
    {
        return new Item("Mochila", "Permite carregar um número maior de itens.");
    }
    public static Item CriarPeDeCabra()
    {
        return new Item("Pé de cabra", "Portas emperradas não serão mais um problema.");
    }
    public static Item CriarColete()
    {
        return new Item("Colete balístico", "Graças ao material resistente, os ataques têm menos efeito.");
    }
    public static Item CriarLanterna()
    {
        return new Item("Lanterna", "Ideal para locais escuros.");
    }
    public static Item CriarPilhas()
    {
        return new Item("Pilhas para lanterna", "Para manter sua lanterna funcionando.");
    }

    //munição
    public static Municao CriarMunicaoPistola()
    {
        return new Municao("Munição de pistola", "Um pente com 12 balas.", TipoMunicao.MunicaoPistola, 12);
    }
    public static Municao CriarMunicaoShotgun()
    {
        return new Municao("Munição de shotgun", "8 cartuchos.", TipoMunicao.MunicaoShotgun, 8);
    }

    //itens de missao
    public static Item CriarDiario()
    {
        return new Item("Diário do Mark", "Onde o parceiro do cientista Freddie escreveu todas as descobertas sobre o vírus.");
    }
    public static Item CriarColeira()
    {
        return new Item("Coleira do Billy", "Uma coleira vermelha com o nome 'Billy' escrito.");
    }
}