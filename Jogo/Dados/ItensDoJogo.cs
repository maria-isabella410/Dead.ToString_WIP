using rpgArma;
using rpgChave;
using rpgConsumivel;
using rpgItem;
using rpgMunicao;
using rpgPorta;
using rpgTipoArma;
using rpgTipoChave;
using rpgTipoMunicao;
using rpgTipoItem;

namespace rpgItensDoJogo;

public class ItensDoJogo
{
    //armas
    public static Arma CriarPistola()
    {
        return new Arma("Pistola", "Uma arma eficiente contra inimigos. (Causa 10 de dano)\n", 10, TipoArma.Pistola, TipoMunicao.MunicaoPistola, 12, 12);
    }
    public static Arma CriarShotgun()
    {
        return new Arma("Shotgun", "Uma arma poderosa que faz um bom estrago. (Causa 20 de dano)\n", 20, TipoArma.Shotgun, TipoMunicao.MunicaoShotgun, 8, 8);
    }
    public static Arma CriarFaca()
    {
        return new Arma("Faca", "Uma arma pequena. (Causa 5 de dano)\n", 5, TipoArma.Faca, null, null, null);
    }

    //consumiveis
    public static Consumivel CriarBandagem()
    {
        return new Consumivel("Bandagem", "Recupera um pouco da sua vida. (Cura 5 HP)\n", 20);
    }
    public static Consumivel CriarKitMed()
    {
        return new Consumivel("Kit Médico", "Recupera grande parte da sua vida. (Cura 20 HP)\n", 70);
    }
    public static Consumivel CriarSpray()
    {
        return new Consumivel("Spray", "Recupera boa parte sua vida. (Cura 10 HP)\n", 40);
    }
    public static Consumivel CriarAgua()
    {
        return new Consumivel("Garrafa de Água", "Mata sua sede. (Cura 5 HP)\n", 25);
    }
    public static Consumivel CriarComidaEnlatada()
    {
        return new Consumivel("Comida enlatada", "Uma comida feita para durar bastante. (Cura 10 HP)\n", 25);
    }
    public static Consumivel CriarAntidoto()
    {
        return new Consumivel("Antídoto", "A esperança da humanidade.\n", 100);
    }

    //chaves
    public static Chave CriarChaveSalaDeArmas()
    {
        return new Chave("Chave da sala de armas", "A chave que o policial Ethan estava procurando. Com ela, você consegue desbloquear a sala de armas.\n", TipoChave.SalaDeArmas);
    }
    public static Chave CriarChaveSalaDeAula()
    {
        return new Chave("Chave da sala de aula", "A chave que abre as salas de aula da escola. Com ela você consegue explorar mais lugares e procurar a garotinha Mary.\n", TipoChave.SalaDeAula);
    }
    public static Chave CriarChaveSalaBiblioteca()
    {
        return new Chave("Chave da biblioteca", "A chave abre a sala de arquivos confidenciais da biblioteca. Com ela, você consegue encontrar os arquivos que o cientista Freddie precisa.\n", TipoChave.SalaBiblioteca);
    }
    public static Chave CriarChaveEstoqueHospital()
    {
        return new Chave("Chave do estoque do hospital", "A chave que abre a sala de estoque do hospital. Com ela, você consegue encontrar diversos itens de cura.\n", TipoChave.EstoqueHospital);
    }
    public static Chave CriarChaveAreaExperimentos()
    {
        return new Chave("Chave do hall do laboratório", "A chave que dá acesso às áreas restritas do laboratório.\nCom ela, você consegue chegar à área de experimentos e ajudar o cientista Freddie a concluir a pesquisa dele.\n", TipoChave.Laboratorio);
    }
    
    //itens comuns
    public static Item CriarMapaDaCidade()
    {
        return new Item("Mapa da cidade", "Explorar a cidade se torna uma tarefa mais fácil. (Não ocupa espaço no inventário)\n", TipoItem.Mapa);
    }
    public static Item CriarMochila()
    {
        return new Item("Mochila", "Permite carregar um número maior de itens. (Inventário 10 -> 15)\n", TipoItem.Mochila);
    }
    public static Item CriarPeDeCabra()
    {
        return new Item("Pé de cabra", "Portas emperradas não serão mais um problema.\n", TipoItem.PeDeCabra);
    }
    public static Item CriarColete()
    {
        return new Item("Colete balístico", "Graças ao material resistente, os ataques têm menos efeito.\n", TipoItem.Colete);
    }

    //munição
    public static Municao CriarMunicaoPistola()
    {
        return new Municao("Munição de pistola", "Um pente com 12 balas.\n", TipoMunicao.MunicaoPistola, 12);
    }
    public static Municao CriarMunicaoShotgun()
    {
        return new Municao("Munição de shotgun", "8 cartuchos.\n", TipoMunicao.MunicaoShotgun, 8);
    }

    //itens de missao
    public static Item CriarDiario()
    {
        return new Item("Diário do Mark", "Onde o parceiro do cientista Freddie escreveu todas as descobertas sobre o vírus.\n", TipoItem.Diario);
    }
    public static Item CriarCaixaBandagens()
    {
       return new Item("Caixa de bandagens", "Uma caixa com 3 bandagens. Que sorte.\n", TipoItem.CaixaBandagem);
    }
}