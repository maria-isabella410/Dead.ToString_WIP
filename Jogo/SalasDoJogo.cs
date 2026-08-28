using rpgMapa;
using rpgPortasDoJogo;
using rpgSala;

namespace rpgSalasDoJogo;

public class SalasDoJogo
{
    //salas trancadas
    public static Sala criarSalaDeArmas(Mapa mapa)
    {
        return new Sala("Sala de armas", "Uma porta reforçada dá acesso a suportes de metal com escopetas, munições e coletes táticos. O arsenal que o policial Ethan precisava para resistir.", mapa.delegacia, PortasDoJogo.CriarPortaSalaDeArmas(mapa));
    }
    public static Sala criarSalaDeAula(Mapa mapa)
    {
        return new Sala("Sala de aula", "Carteiras empilhadas contra a porta e desenhos infantis na parede. No fundo do cômodo, a pequena Mary se esconde encolhida, assustada com o barulho dos infectados.", mapa.escola, PortasDoJogo.CriarPortaSalaDeAula(mapa));
    }
    public static Sala criarSalaDeArquivosBiblioteca(Mapa mapa)
    {
        return new Sala("Sala de arquivos", "Prateleiras altas repletas de pastas confidenciais e documentos antigos. Em uma das mesas, há arquivos cruciais para as pesquisas do cientista Freddie.", mapa.biblioteca, PortasDoJogo.CriarPortaSalaArquivos(mapa));
    }
    public static Sala criarEstoqueHospital(Mapa mapa)
    {
        return new Sala("Estoque do hospital", "Prateleiras organizadas e caixas lacradas contendo antissépticos, gazes, seringas e itens de cura essenciais para socorrer os feridos.", mapa.hospital, PortasDoJogo.CriarPortaEstoqueHospital(mapa));
    }
    public static Sala criarAreaExperimentosLaboratorio(Mapa mapa)
    {
        return new Sala("Sala do laboratório", "Tubos de ensaio quebrados, centrífugas ainda ligadas e equipamentos de ponta. É aqui que o antídoto definitivo pode ser finalizado.", mapa.laboratorio, PortasDoJogo.CriarPortaAreaExperimentos(mapa));
    }  

    //salas comuns

    //delegacia
    public static Sala criarRecepcaoDelegacia(Mapa mapa)
    {
        return new Sala("Recepção", "A recepção da delegacia. Está virada de cabeça para baixo, com papéis jogados e sangue espalhado pelo chão...", mapa.delegacia, null);
    }      
    public static Sala criarVestiarioDelegacia(Mapa mapa)
    {
        return new Sala("Vestiário", "Armários de metal arrombados e fardamentos rasgados pelo chão. Um forte cheiro de suor e mofo impregna o ar.", mapa.delegacia, null);
    } 

    //biblioteca
    public static Sala criarRecepcaoBiblioteca(Mapa mapa)
    {
        return new Sala("Recepção", "Apesar do sangue manchando as paredes, a recepção antiquada ainda tem seu charme.", mapa.biblioteca, null);
    } 
    public static Sala criarSalaEstudosBiblioteca(Mapa mapa)
    {
        return new Sala("Sala de estudos", "Feita para estudantes aproveitarem melhor o silêncio da biblioteca.", mapa.biblioteca, null);
    } 

    //mercado
    public static Sala criarCorredoresMercado(Mapa mapa)
    {
        return new Sala("Corredores", "Prateleiras tombadas e embalagens rasgadas cobrem o chão. O cheiro de comida estragada é insuportável.", mapa.mercado, null);
    }      
    public static Sala criarEstoqueMercado(Mapa mapa)
    {
        return new Sala("Estoque", "Caixas de papelão rasgadas e pallets vazios. Quem passou por aqui levou quase tudo.", mapa.mercado, null);
    }     
    public static Sala criarEscritorioGerenteMercado(Mapa mapa)
    {
        return new Sala("Escritório do gerente", "Documentos espalhados sobre a mesa de madeira e monitores quebrados.", mapa.mercado, null);
    }     

    //escola
    public static Sala criarPatioEscola(Mapa mapa)
    {
        return new Sala("Pátio", "Mochilas infantis e brinquedos espalhados no gramado cinzento, manchado por poças de sangue seco.", mapa.escola, null);
    }     
    public static Sala criarCorredoresEscola(Mapa mapa)
    {
        return new Sala("Corredores", "Armários amassados e pichações de socorro nas paredes.", mapa.escola, null);
    }     
    public static Sala criarRefeitorioEscola(Mapa mapa)
    {
        return new Sala("Refeitório", "Mesas compridas viradas como barricadas improvisadas.", mapa.escola, null);
    }     
    public static Sala criarEnfermariaEscola(Mapa mapa)
    {
        return new Sala("Enfermaria", "Macas dobráveis com lençóis manchados e frascos de antisséptico vazios espalhados pelo piso de linóleo.", mapa.escola, null);
    }     

    //laboratorio
    public static Sala criarHallEntradaLaboratorio(Mapa mapa)
    {
        return new Sala("Hall de entrada", "Luzes de emergência piscando em vermelho. O vidro da catraca de acesso está completamente estilhaçado.", mapa.laboratorio, null);
    }     
    public static Sala criarSalaDeSegurancaLaboratorio(Mapa mapa)
    {
        return new Sala("Sala de segurança", "Múltiplos monitores exibindo estática e botões de alarme piscando.", mapa.laboratorio, null);
    }      

    //casa abandonada
    public static Sala criarSalaCasa(Mapa mapa)
    {
        return new Sala("Sala", "Móveis cobertos por lençóis encardidos e uma camada espessa de poeira. Fotos de família continuam na parede.", mapa.casaAbandonada, null);
    }     
    public static Sala criarQuartoCasa(Mapa mapa)
    {
        return new Sala("Quarto", "A cama está desarrumada e as gavetas das cômodas foram arrancadas e viradas no chão.", mapa.casaAbandonada, null);
    }     
    public static Sala criarCozinhaCasa(Mapa mapa)
    {
        return new Sala("Cozinha", "Pratos quebrados na pia e moscas sobre os restos da última refeição que nunca foi terminada.", mapa.casaAbandonada, null);
    }     
    public static Sala criarPoraoCasa(Mapa mapa)
    {
        return new Sala("Porão", "Um cômodo escuro e úmido, abarrotado de caixas velhas. A luz que vem da escada mal consegue iluminar os cantos.", mapa.casaAbandonada, null);
    }     

    //igreja
    public static Sala criarPresbiterioIgreja(Mapa mapa)
    {
        return new Sala("Presbitério", "Bancos de madeira alinhados em direção ao altar, com velas queimadas até o fim e bíblias rasgadas.", mapa.igreja, null);
    }     
    public static Sala criarSacristiaIgreja(Mapa mapa)
    {
        return new Sala("Sacristia", "Armários de madeira nobre abertos, com túnicas sagradas jogadas no chão e cálices de metal amassados.", mapa.igreja, null);
    }      

    //posto de gasolina
    public static Sala criarLojaConvenienciaPosto(Mapa mapa)
    {
        return new Sala("Loja de conveniência", "Geladeiras abertas e prateleiras vazias. O balcão do caixa está manchado de sangue.", mapa.postoDeGasolina, null);
    }     
    public static Sala criarPatioPosto(Mapa mapa)
    {
        return new Sala("Pátio", "Bombas de combustível desligadas e veículos abandonados com as portas abertas.", mapa.postoDeGasolina, null);
    }     
    public static Sala criarGaragemPosto(Mapa mapa)
    {
        return new Sala("Garagem", "Carros erguidos nos elevadores hidráulicos e ferramentas espalhadas pela bancada. Manchas recentes de óleo cobrem o chão.", mapa.postoDeGasolina, null);
    }     

    //hospital
    public static Sala criarRecepcaoHospital(Mapa mapa)
    {
        return new Sala("Recepção", "Cadeiras de rodas abandonadas e fichas médicas espalhadas. A fita de isolamento ainda cerca o balcão.", mapa.hospital, null);
    }     
    public static Sala criarUTIHospital(Mapa mapa)
    {
        return new Sala("UTI", "Monitores desligados e macas cobertas de sangue seco. O cheiro de produtos químicos ainda é forte.", mapa.hospital, null);
    }     
    public static Sala criarNecroterioHospital(Mapa mapa)
    {
        return new Sala("Necrotério", "Gavetas de aço inoxidável abertas e fétidas. A temperatura ambiente subiu bastante desde que a energia caiu.", mapa.hospital, null);
    }                                                                                                               
}