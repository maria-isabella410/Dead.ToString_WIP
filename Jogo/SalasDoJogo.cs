using rpgMapa;
using rpgPortasDoJogo;
using rpgSala;
using rpgNpcsDoJogo;
using rpgItensDoJogo;
using rpgZombiesDoJogo;

namespace rpgSalasDoJogo;

public class SalasDoJogo
{  
    public Random random {get; private set;}
    public Mapa Mapa {get; private set;}

    //delegacia
    private Sala recepcaoDelegacia;
    private Sala vestiarioDelegacia;
    private Sala salaDeArmas;

    //biblioteca
    private Sala recepcaoBiblioteca;
    private Sala salaEstudosBiblioteca;
    private Sala salaDeArquivosBiblioteca;

    //mercado
    private Sala corredoresMercado;
    private Sala estoqueMercado;
    private Sala escritorioGerenteMercado;

    //escola
    private Sala patioEscola;
    private Sala corredoresEscola;
    private Sala refeitorioEscola;
    private Sala enfermariaEscola;
    private Sala salaDeAula;

    //laboratório
    private Sala hallEntradaLaboratorio;
    private Sala salaDeSegurancaLaboratorio;
    private Sala areaExperimentosLaboratorio;

    //casa abandonada
    private Sala salaCasa;
    private Sala quartoCasa;
    private Sala cozinhaCasa;
    private Sala poraoCasa;

    //igreja
    private Sala presbiterioIgreja;
    private Sala sacristiaIgreja;

    //posto de gasolina
    private Sala lojaConvenienciaPosto;
    private Sala patioPosto;
    private Sala garagemPosto;

    //hospital
    private Sala recepcaoHospital;
    private Sala utiHospital;
    private Sala necroterioHospital;
    private Sala estoqueHospital;

    public SalasDoJogo(Mapa mapa, Random random){
        this.random = random;
        this.Mapa = mapa;

        CriarInstanciaSalas(mapa);
        AdicionarSalas(mapa);
        AdicionarNpcs(mapa);
        AdicionarItens(mapa);
        AdicionarZombies(mapa);
    }

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

    private bool Chance(int porcentagem)
    {
        return random.Next(100) < porcentagem;
    }
    public void CriarInstanciaSalas(Mapa mapa)
    {
        salaDeArmas = criarSalaDeArmas(mapa);
        salaDeAula = criarSalaDeAula(mapa);
        salaDeArquivosBiblioteca = criarSalaDeArquivosBiblioteca(mapa);
        estoqueHospital = criarEstoqueHospital(mapa);
        areaExperimentosLaboratorio = criarAreaExperimentosLaboratorio(mapa);

        recepcaoDelegacia = criarRecepcaoDelegacia(mapa);
        vestiarioDelegacia = criarVestiarioDelegacia(mapa);

        recepcaoBiblioteca = criarRecepcaoBiblioteca(mapa);
        salaEstudosBiblioteca = criarSalaEstudosBiblioteca(mapa);

        corredoresMercado = criarCorredoresMercado(mapa);
        estoqueMercado = criarEstoqueMercado(mapa);
        escritorioGerenteMercado = criarEscritorioGerenteMercado(mapa);

        patioEscola = criarPatioEscola(mapa);
        corredoresEscola = criarCorredoresEscola(mapa);
        refeitorioEscola = criarRefeitorioEscola(mapa);
        enfermariaEscola = criarEnfermariaEscola(mapa);

        hallEntradaLaboratorio = criarHallEntradaLaboratorio(mapa);
        salaDeSegurancaLaboratorio = criarSalaDeSegurancaLaboratorio(mapa);

        salaCasa = criarSalaCasa(mapa);
        quartoCasa = criarQuartoCasa(mapa);
        cozinhaCasa = criarCozinhaCasa(mapa);
        poraoCasa = criarPoraoCasa(mapa);

        presbiterioIgreja = criarPresbiterioIgreja(mapa);
        sacristiaIgreja = criarSacristiaIgreja(mapa);

        lojaConvenienciaPosto = criarLojaConvenienciaPosto(mapa);
        patioPosto = criarPatioPosto(mapa);
        garagemPosto = criarGaragemPosto(mapa);

        recepcaoHospital = criarRecepcaoHospital(mapa);
        utiHospital = criarUTIHospital(mapa);
        necroterioHospital = criarNecroterioHospital(mapa);
    }

    //add salas
    private void AdicionarSalas(Mapa mapa)
    {
        //delegacia
        mapa.delegacia.AdicionarSala(recepcaoDelegacia);
        mapa.delegacia.AdicionarSala(vestiarioDelegacia);
        mapa.delegacia.AdicionarSala(salaDeArmas);

        //biblioteca
        mapa.biblioteca.AdicionarSala(recepcaoBiblioteca);
        mapa.biblioteca.AdicionarSala(salaEstudosBiblioteca);
        mapa.biblioteca.AdicionarSala(salaDeArquivosBiblioteca);

        //mercado
        mapa.mercado.AdicionarSala(corredoresMercado);
        mapa.mercado.AdicionarSala(estoqueMercado);  
        mapa.mercado.AdicionarSala(escritorioGerenteMercado);

        //escola
        mapa.escola.AdicionarSala(patioEscola);
        mapa.escola.AdicionarSala(corredoresEscola);
        mapa.escola.AdicionarSala(refeitorioEscola);
        mapa.escola.AdicionarSala(enfermariaEscola);
        mapa.escola.AdicionarSala(salaDeAula);        

        //laboratorio
        mapa.laboratorio.AdicionarSala(hallEntradaLaboratorio);
        mapa.laboratorio.AdicionarSala(salaDeSegurancaLaboratorio);
        mapa.laboratorio.AdicionarSala(areaExperimentosLaboratorio);

        //casa abandonada
        mapa.casaAbandonada.AdicionarSala(salaCasa);
        mapa.casaAbandonada.AdicionarSala(quartoCasa);
        mapa.casaAbandonada.AdicionarSala(cozinhaCasa);
        mapa.casaAbandonada.AdicionarSala(poraoCasa);

        //igreja
        mapa.igreja.AdicionarSala(presbiterioIgreja);
        mapa.igreja.AdicionarSala(sacristiaIgreja);

        //posto de gasolina
        mapa.postoDeGasolina.AdicionarSala(lojaConvenienciaPosto);
        mapa.postoDeGasolina.AdicionarSala(patioPosto);
        mapa.postoDeGasolina.AdicionarSala(garagemPosto);

        //hospital
        mapa.hospital.AdicionarSala(recepcaoHospital);
        mapa.hospital.AdicionarSala(utiHospital);
        mapa.hospital.AdicionarSala(necroterioHospital);
        mapa.hospital.AdicionarSala(estoqueHospital);
    }

    //add itens, npcs e zombies
    private void AdicionarNpcs(Mapa mapa)
    {
        presbiterioIgreja.AdicionarNpc(NpcsDoJogo.CriaPadre());

        recepcaoDelegacia.AdicionarNpc(NpcsDoJogo.CriaPolicial());

        corredoresEscola.AdicionarNpc(NpcsDoJogo.CriaProfessora());

        salaDeAula.AdicionarNpc(NpcsDoJogo.CriaCrianca());

        utiHospital.AdicionarNpc(NpcsDoJogo.CriaEnfermeira()); 

        salaDeSegurancaLaboratorio.AdicionarNpc(NpcsDoJogo.CriaCientista());
    }      
    private void AdicionarItens(Mapa mapa)
    {
        //delegacia
        recepcaoDelegacia.AdicionarItens(ItensDoJogo.CriarPistola());
        salaDeArmas.AdicionarItens(ItensDoJogo.CriarColete());

        if(Chance(80))
        {
            recepcaoDelegacia.AdicionarItens(ItensDoJogo.CriarMunicaoPistola());
        }
        if(Chance(40))
        {
            salaDeArmas.AdicionarItens(ItensDoJogo.CriarMunicaoShotgun());
        }
        if(Chance(30))
        {
            vestiarioDelegacia.AdicionarItens(ItensDoJogo.CriarBandagem());
        }        

        //biblioteca
        salaEstudosBiblioteca.AdicionarItens(ItensDoJogo.CriarChaveSalaBiblioteca());
        salaDeArquivosBiblioteca.AdicionarItens(ItensDoJogo.CriarDiario());

        if(Chance(20))
        {
            salaEstudosBiblioteca.AdicionarItens(ItensDoJogo.CriarAgua());
        }
        if(Chance(20))
        {
            recepcaoBiblioteca.AdicionarItens(ItensDoJogo.CriarBandagem());
        }
        if(Chance(20))
        {
            recepcaoBiblioteca.AdicionarItens(ItensDoJogo.CriarBandagem());
        }        

        //mercado
        corredoresMercado.AdicionarItens(ItensDoJogo.CriarAgua());
        corredoresMercado.AdicionarItens(ItensDoJogo.CriarComidaEnlatada());

        if(Chance(70))
        {
            estoqueMercado.AdicionarItens(ItensDoJogo.CriarComidaEnlatada());
        }
        if(Chance(70))
        {
            estoqueMercado.AdicionarItens(ItensDoJogo.CriarAgua());
        }
        if(Chance(30))
        {
            estoqueMercado.AdicionarItens(ItensDoJogo.CriarKitMed());
        }        
        if(Chance(40))
        {
            corredoresMercado.AdicionarItens(ItensDoJogo.CriarBandagem());
        }
        if(Chance(25))
        {
            escritorioGerenteMercado.AdicionarItens(ItensDoJogo.CriarSpray());
        }
        if(Chance(50))
        {
            escritorioGerenteMercado.AdicionarItens(ItensDoJogo.CriarMunicaoPistola());
        }
        if(Chance(40))
        {
            escritorioGerenteMercado.AdicionarItens(ItensDoJogo.CriarMunicaoShotgun());
        }        

        //escola
        enfermariaEscola.AdicionarItens(ItensDoJogo.CriarChaveSalaDeAula());
        corredoresEscola.AdicionarItens(ItensDoJogo.CriarComidaEnlatada());

        if(Chance(60))
        {
            enfermariaEscola.AdicionarItens(ItensDoJogo.CriarBandagem());
        }
        if(Chance(20))
        {
            enfermariaEscola.AdicionarItens(ItensDoJogo.CriarAgua());
        }
        if(Chance(30))
        {
            corredoresEscola.AdicionarItens(ItensDoJogo.CriarComidaEnlatada());
        }
        if(Chance(20))
        {
            corredoresEscola.AdicionarItens(ItensDoJogo.CriarMunicaoPistola());
        }
        if(Chance(20))
        {
            patioEscola.AdicionarItens(ItensDoJogo.CriarAgua());
        }

        //laboratorio
        areaExperimentosLaboratorio.AdicionarItens(ItensDoJogo.CriarAntidoto());

        if(Chance(40))
        {
            hallEntradaLaboratorio.AdicionarItens(ItensDoJogo.CriarSpray());
        }
        if(Chance(30))
        {
            hallEntradaLaboratorio.AdicionarItens(ItensDoJogo.CriarKitMed());
        }   
        if(Chance(40))
        {
            salaDeSegurancaLaboratorio.AdicionarItens(ItensDoJogo.CriarSpray());
        }
        if(Chance(30))
        {
            salaDeSegurancaLaboratorio.AdicionarItens(ItensDoJogo.CriarKitMed());
        } 
        if(Chance(30))
        {
            salaDeSegurancaLaboratorio.AdicionarItens(ItensDoJogo.CriarMunicaoShotgun());
        }     

        //casa abandonada
        salaCasa.AdicionarItens(ItensDoJogo.CriarAgua());

        if(Chance(60))
        {
            cozinhaCasa.AdicionarItens(ItensDoJogo.CriarBandagem());
        }
        if(Chance(85))
        {
            cozinhaCasa.AdicionarItens(ItensDoJogo.CriarComidaEnlatada());
        }
        if(Chance(30))
        {
            quartoCasa.AdicionarItens(ItensDoJogo.CriarSpray());
        }
        if(Chance(60))
        {
            poraoCasa.AdicionarItens(ItensDoJogo.CriarMunicaoPistola());
        }
        if(Chance(40))
        {
            poraoCasa.AdicionarItens(ItensDoJogo.CriarMunicaoShotgun());
        }        

        //igreja
        presbiterioIgreja.AdicionarItens(ItensDoJogo.CriarComidaEnlatada());
        
        if(Chance(50))
        {
            sacristiaIgreja.AdicionarItens(ItensDoJogo.CriarBandagem());
        }
        if(Chance(40))
        {
            sacristiaIgreja.AdicionarItens(ItensDoJogo.CriarAgua());
        }
        if(Chance(10))
        {
            sacristiaIgreja.AdicionarItens(ItensDoJogo.CriarKitMed());
        }
        if(Chance(50))
        {
            presbiterioIgreja.AdicionarItens(ItensDoJogo.CriarMunicaoPistola());
        }    

        //posto de gasolina
        lojaConvenienciaPosto.AdicionarItens(ItensDoJogo.CriarAgua());
        patioPosto.AdicionarItens(ItensDoJogo.CriarMapaDaCidade());
        garagemPosto.AdicionarItens(ItensDoJogo.CriarPeDeCabra());

        if(Chance(90))
        {
            lojaConvenienciaPosto.AdicionarItens(ItensDoJogo.CriarComidaEnlatada());
        }
        if(Chance(50))
        {
            lojaConvenienciaPosto.AdicionarItens(ItensDoJogo.CriarBandagem());
        }
        if(Chance(30))
        {
            patioPosto.AdicionarItens(ItensDoJogo.CriarSpray());
        }
        if(Chance(60))
        {
            garagemPosto.AdicionarItens(ItensDoJogo.CriarMunicaoPistola());
        }        

        //hospital
        recepcaoHospital.AdicionarItens(ItensDoJogo.CriarChaveEstoqueHospital());
        estoqueHospital.AdicionarItens(ItensDoJogo.CriarCaixaBandagens());

        if(Chance(50))
        {
            necroterioHospital.AdicionarItens(ItensDoJogo.CriarSpray());
        }
        if(Chance(50))
        {
            necroterioHospital.AdicionarItens(ItensDoJogo.CriarSpray());
        }
        if(Chance(40))
        {
            utiHospital.AdicionarItens(ItensDoJogo.CriarAgua());
        }
        if(Chance(90))
        {
            utiHospital.AdicionarItens(ItensDoJogo.CriarSpray());
        }
        if(Chance(90))
        {
            utiHospital.AdicionarItens(ItensDoJogo.CriarBandagem());
        }
        if(Chance(30))
        {
            utiHospital.AdicionarItens(ItensDoJogo.CriarMunicaoShotgun());
        }             
        if(Chance(40))
        {
            recepcaoHospital.AdicionarItens(ItensDoJogo.CriarMunicaoPistola());
        }   
    }
    private void AdicionarZombies(Mapa mapa)
    {
        //delegacia
        recepcaoDelegacia.AdicionarZombie(ZombiesDoJogo.CriaZombieComumForte());
        vestiarioDelegacia.AdicionarZombie(ZombiesDoJogo.CriaZombieComumFraco());

        if(Chance(50))
        {
            vestiarioDelegacia.AdicionarZombie(ZombiesDoJogo.CriaZombieComumFraco());
        }

        //igreja
        sacristiaIgreja.AdicionarZombie(ZombiesDoJogo.CriaZombieComumFraco());

        if(Chance(50))
        {
            presbiterioIgreja.AdicionarZombie(ZombiesDoJogo.CriaZombieComumFraco());
        }
        if(Chance(10))
        {
            sacristiaIgreja.AdicionarZombie(ZombiesDoJogo.CriaZombieJumper());
        }        

        //posto de gasolina
        patioPosto.AdicionarZombie(ZombiesDoJogo.CriaZombieComumFraco());
        lojaConvenienciaPosto.AdicionarZombie(ZombiesDoJogo.CriaZombieJumper());        
        garagemPosto.AdicionarZombie(ZombiesDoJogo.CriaZombieComumFraco());

        if(Chance(50))
        {
            garagemPosto.AdicionarZombie(ZombiesDoJogo.CriaZombieComumForte());
        }        

        //mercado
        corredoresMercado.AdicionarZombie(ZombiesDoJogo.CriaZombieComumFraco());
        corredoresMercado.AdicionarZombie(ZombiesDoJogo.CriaZombieComumForte());

        if(Chance(40))
        {
            corredoresMercado.AdicionarZombie(ZombiesDoJogo.CriaZombieComumForte());
        }
        if(Chance(5))
        {
            escritorioGerenteMercado.AdicionarZombie(ZombiesDoJogo.CriaZombieTank());
        }        

        //casa abandonada
        poraoCasa.AdicionarZombie(ZombiesDoJogo.CriaZombieComumForte());

        if(Chance(40))
        {
            quartoCasa.AdicionarZombie(ZombiesDoJogo.CriaZombieComumFraco());
        }        
        if(Chance(40))
        {
            cozinhaCasa.AdicionarZombie(ZombiesDoJogo.CriaZombieComumFraco());
        }         

        //escola
        refeitorioEscola.AdicionarZombie(ZombiesDoJogo.CriaZombieTank());
        enfermariaEscola.AdicionarZombie(ZombiesDoJogo.CriaZombieComumForte());
        patioEscola.AdicionarZombie(ZombiesDoJogo.CriaZombieComumFraco());

        if(Chance(20))
        {
            patioEscola.AdicionarZombie(ZombiesDoJogo.CriaZombieComumFraco());
        }        

        //biblioteca
        recepcaoBiblioteca.AdicionarZombie(ZombiesDoJogo.CriaZombieComumFraco());        

        //hospital
        recepcaoHospital.AdicionarZombie(ZombiesDoJogo.CriaZombieComumForte());
        utiHospital.AdicionarZombie(ZombiesDoJogo.CriaZombieComumForte());
        necroterioHospital.AdicionarZombie(ZombiesDoJogo.CriaZombieComumFraco());
        necroterioHospital.AdicionarZombie(ZombiesDoJogo.CriaZombieComumForte());

        if(Chance(40))
        {
            utiHospital.AdicionarZombie(ZombiesDoJogo.CriaZombieJumper());
        }
        if(Chance(60))
        {
            necroterioHospital.AdicionarZombie(ZombiesDoJogo.CriaZombieComumFraco());
        }        

        //laboratorio
        salaDeSegurancaLaboratorio.AdicionarZombie(ZombiesDoJogo.CriaZombieComumForte());
        salaDeSegurancaLaboratorio.AdicionarZombie(ZombiesDoJogo.CriaZombieJumper());
        hallEntradaLaboratorio.AdicionarZombie(ZombiesDoJogo.CriaZombieComumFraco());
        hallEntradaLaboratorio.AdicionarZombie(ZombiesDoJogo.CriaZombieComumFraco());
        areaExperimentosLaboratorio.AdicionarZombie(ZombiesDoJogo.CriaZombieFinal());    
    }                                                                                
}