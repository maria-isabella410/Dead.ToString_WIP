using rpgMapa;
using rpgPortasDoJogo;
using rpgSala;

namespace rpgSalasDoJogo;

public class SalasDoJogo
{
    private Mapa Mapa {get; set;}
    private Random random {get; set;}

    public SalasDoJogo()
    {
        random = new Random();
        Mapa = new Mapa(random);
    }

    //salas trancadas
    public Sala criarSalaDeArmas()
    {
        return new Sala("Sala de armas", "Uma porta reforçada dá acesso a suportes de metal com escopetas, munições e coletes táticos. O arsenal que o policial Ethan precisava para resistir.", Mapa.delegacia, PortasDoJogo.CriarPortaSalaDeArmas());
    }
    public Sala criarSalaDeAula()
    {
        return new Sala("Sala de aula", "Carteiras empilhadas contra a porta e desenhos infantis na parede. No fundo do cômodo, a pequena Mary se esconde encolhida, assustada com o barulho dos infectados.", Mapa.escola, PortasDoJogo.CriarPortaSalaDeAula());
    }
    public Sala criarSalaBiblioteca()
    {
        return new Sala("Sala da biblioteca", "Prateleiras altas repletas de pastas confidenciais e documentos antigos. Em uma das mesas, há arquivos cruciais para as pesquisas do cientista Freddie.", Mapa.biblioteca, PortasDoJogo.CriarPortaSalaBiblioteca());
    }
    public Sala criarEstoqueHospital()
    {
        return new Sala("Estoque do hospital", "Prateleiras organizadas e caixas lacradas contendo antissépticos, gazes, seringas e itens de cura essenciais para socorrer os feridos.", Mapa.hospital, PortasDoJogo.CriarPortaArmarioHospital());
    }
    public Sala criarSalaLaboratorio()
    {
        return new Sala("Sala do laboratório", "Tubos de ensaio quebrados, centrífugas ainda ligadas e equipamentos de ponta. É aqui que o antídoto definitivo pode ser finalizado.", Mapa.laboratorio, PortasDoJogo.CriarPortaSalaLaboratorio());
    }  

    //salas comuns

    //delegacia
    public Sala criarRecepcaoDelegacia()
    {
        return new Sala("Recepção", "A recepção da delegacia. Está virada de cabeça para baixo, com papéis jogados e sangue espalhado pelo chão...", Mapa.delegacia, null);
    }      
    public Sala criarVestiarioDelegacia()
    {
        return new Sala("Vestiário", "Armários de metal arrombados e fardamentos rasgados pelo chão. Um forte cheiro de suor e mofo impregna o ar.", Mapa.delegacia, null);
    } 

    //biblioteca
    public Sala criarRecepcaoBiblioteca()
    {
        return new Sala("Recepção", "Apesar do sangue manchando as paredes, a recepção antiquada ainda tem seu charme.", Mapa.biblioteca, null);
    } 
    public Sala criarSalaEstudosBiblioteca()
    {
        return new Sala("Sala de estudos", "Feita para estudantes aproveitarem melhor o silêncio da biblioteca.", Mapa.biblioteca, null);
    } 

    //mercado
    public Sala criarCorredoresMercado()
    {
        return new Sala("Corredores", "Prateleiras tombadas e embalagens rasgadas cobrem o chão. O cheiro de comida estragada é insuportável.", Mapa.mercado, null);
    }      
    public Sala criarEstoqueMercado()
    {
        return new Sala("Estoque", "Caixas de papelão rasgadas e pallets vazios. Quem passou por aqui levou quase tudo.", Mapa.mercado, null);
    }     
    public Sala criarEscritorioGerenteMercado()
    {
        return new Sala("Escritório do gerente", "Documentos espalhados sobre a mesa de madeira e monitores quebrados.", Mapa.mercado, null);
    }     

    //escola
    public Sala criarPatioEscola()
    {
        return new Sala("Pátio", "Mochilas infantis e brinquedos espalhados no gramado cinzento, manchado por poças de sangue seco.", Mapa.escola, null);
    }     
    public Sala criarCorredoresEscola()
    {
        return new Sala("Corredores", "Armários amassados e pichações de socorro nas paredes.", Mapa.escola, null);
    }     
    public Sala criarRefeitorioEscola()
    {
        return new Sala("Refeitório", "Mesas compridas viradas como barricadas improvisadas.", Mapa.escola, null);
    }     
    public Sala criarEnfermariaEscola()
    {
        return new Sala("Enfermaria", "Macas dobráveis com lençóis manchados e frascos de antisséptico vazios espalhados pelo piso de linóleo.", Mapa.escola, null);
    }     

    //laboratorio
    public Sala criarHallEntradaLaboratorio()
    {
        return new Sala("Hall de entrada", "Luzes de emergência piscando em vermelho. O vidro da catraca de acesso está completamente estilhaçado.", Mapa.laboratorio, null);
    }     
    public Sala criarSalaDeSegurancaLaboratorio()
    {
        return new Sala("Sala de segurança", "Múltiplos monitores exibindo estática e botões de alarme piscando.", Mapa.laboratorio, null);
    }      

    //casa abandonada
    public Sala criarSalaCasa()
    {
        return new Sala("Sala", "Móveis cobertos por lençóis encardidos e uma camada espessa de poeira. Fotos de família continuam na parede.", Mapa.casaAbandonada, null);
    }     
    public Sala criarQuartoCasa()
    {
        return new Sala("Quarto", "A cama está desarrumada e as gavetas das cômodas foram arrancadas e viradas no chão.", Mapa.casaAbandonada, null);
    }     
    public Sala criarCozinhaCasa()
    {
        return new Sala("Cozinha", "Pratos quebrados na pia e moscas sobre os restos da última refeição que nunca foi terminada.", Mapa.casaAbandonada, null);
    }     
    public Sala criarPoraoCasa()
    {
        return new Sala("Porão", "Um cômodo escuro e úmido, abarrotado de caixas velhas. A luz que vem da escada mal consegue iluminar os cantos.", Mapa.casaAbandonada, null);
    }     

    //igreja
    public Sala criarPresbiterioIgreja()
    {
        return new Sala("Presbitério", "Bancos de madeira alinhados em direção ao altar, com velas queimadas até o fim e bíblias rasgadas.", Mapa.igreja, null);
    }     
    public Sala criarSacristiaIgreja()
    {
        return new Sala("Sacristia", "Armários de madeira nobre abertos, com túnicas sagradas jogadas no chão e cálices de metal amassados.", Mapa.igreja, null);
    }      

    //posto de gasolina
    public Sala criarLojaConvenienciaPosto()
    {
        return new Sala("Loja de conveniência", "Geladeiras abertas e prateleiras vazias. O balcão do caixa está manchado de sangue.", Mapa.postoDeGasolina, null);
    }     
    public Sala criarPatioPosto()
    {
        return new Sala("Pátio", "Bombas de combustível desligadas e veículos abandonados com as portas abertas.", Mapa.postoDeGasolina, null);
    }     
    public Sala criarGaragemPosto()
    {
        return new Sala("Garagem", "Carros erguidos nos elevadores hidráulicos e ferramentas espalhadas pela bancada. Manchas recentes de óleo cobrem o chão.", Mapa.postoDeGasolina, null);
    }     

    //hospital
    public Sala criarRecepcaoHospital()
    {
        return new Sala("Recepção", "Cadeiras de rodas abandonadas e fichas médicas espalhadas. A fita de isolamento ainda cerca o balcão.", Mapa.hospital, null);
    }     
    public Sala criarUTIHospital()
    {
        return new Sala("UTI", "Monitores desligados e macas cobertas de sangue seco. O cheiro de produtos químicos ainda é forte.", Mapa.hospital, null);
    }     
    public Sala criarNecroterioHospital()
    {
        return new Sala("Necrotério", "Gavetas de aço inoxidável abertas e fétidas. A temperatura ambiente subiu bastante desde que a energia caiu.", Mapa.hospital, null);
    }                                                                                                               
}