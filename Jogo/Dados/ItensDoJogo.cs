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
        return new Arma("Pistola", "Uma arma eficiente contra inimigos. (Causa 10 de dano)", 10, TipoArma.Pistola, TipoMunicao.MunicaoPistola, 12, 12, ["Você dispara com a pistola e acerta o peito do zombie", "Você atira com precisão e acerta o rosto do zombie", "Você desfere um disparo rápido com a pistola no tronco do zombie", "Você dispara rapidamente com a pistola e atinge o ombro do zombie", "Você acerta um tiro direto com a pistola no peito do zombie"]);
    }
    public static Arma CriarShotgun()
    {
        return new Arma("Shotgun", "Uma arma poderosa que faz um bom estrago. (Causa 20 de dano)", 20, TipoArma.Shotgun, TipoMunicao.MunicaoShotgun, 8, 8, ["Você dispara a shotgun à queima-roupa e atinge o peito do zombie", "Você atira com a shotgun e joga o zombie para trás com o impacto", "Você puxa o gatilho da shotgun e acerta um tiro pesado no tronco do zombie", "Você acerta um disparo devastador de shotgun no peito do zombie", "Você atira com a shotgun e atinge a lateral do zombie com força total"]);
    }
    public static Arma CriarFaca()
    {
        return new Arma("Faca", "Uma arma pequena. (Causa 5 de dano)", 5, TipoArma.Faca, null, null, null, ["Você acerta um golpe seco com a faca na lateral da cabeça do zombie", "Você avança com firmeza e crava a lâmina da faca na testa do zombie", "Você acerta o crânio do zombie com um golpe direto da faca", "Você golpeia o topo da cabeça do zombie com firmeza usando a faca", "Você atinge a têmpora do zombie com um golpe firme da faca"]);
    }

    //consumiveis
    public static Consumivel CriarBandagem()
    {
        return new Consumivel("Bandagem", "Recupera um pouco da sua vida. (Cura 12 HP)", TipoItem.ConsumivelGeral, 12);
    }
    public static Consumivel CriarKitMed()
    {
        return new Consumivel("Kit Médico", "Recupera grande parte da sua vida. (Cura 35 HP)", TipoItem.ConsumivelGeral, 35);
    }
    public static Consumivel CriarSpray()
    {
        return new Consumivel("Spray", "Recupera boa parte sua vida. (Cura 22 HP)", TipoItem.ConsumivelGeral, 22);
    }
    public static Consumivel CriarAgua()
    {
        return new Consumivel("Garrafa de Água", "Mata sua sede. (Cura 8 HP)", TipoItem.ConsumivelGeral, 8);
    }
    public static Consumivel CriarComidaEnlatada()
    {
        return new Consumivel("Comida enlatada", "Uma comida feita para durar bastante. (Cura 15 HP)", TipoItem.ConsumivelGeral, 15);
    }
    public static Consumivel CriarAntidoto()
    {
        return new Consumivel("Antídoto", "A esperança da humanidade.", TipoItem.ConsumivelAntidoto, 100);
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
    public static Chave CriarChaveAreaExperimentos()
    {
        return new Chave("Chave do hall do laboratório", "A chave que dá acesso às áreas restritas do laboratório.\nCom ela, você consegue chegar à área de experimentos e ajudar o cientista Freddie a concluir a pesquisa dele.", TipoChave.Laboratorio);
    }
    
    //itens comuns
    public static Item CriarMapaDaCidade()
    {
        return new Item("Mapa da cidade", "Explorar a cidade se torna uma tarefa mais fácil. (Não ocupa espaço no inventário)", TipoItem.Mapa);
    }
    public static Item CriarMochila()
    {
        return new Item("Mochila", "Permite carregar um número maior de itens. (Inventário 10 -> 15)", TipoItem.Mochila);
    }
    public static Item CriarPeDeCabra()
    {
        return new Item("Pé de cabra", "Portas emperradas não serão mais um problema.", TipoItem.PeDeCabra);
    }
    public static Item CriarColete()
    {
        return new Item("Colete balístico", "Graças ao material resistente, os ataques têm menos efeito.", TipoItem.Colete);
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
        return new Item("Diário do Mark", "Onde o parceiro do cientista Freddie escreveu todas as descobertas sobre o vírus.", TipoItem.Diario);
    }
    public static Item CriarCaixaBandagens()
    {
       return new Item("Caixa de bandagens", "Uma caixa com 3 bandagens. Que sorte.", TipoItem.CaixaBandagem);
    }
}