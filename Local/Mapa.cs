using rpgLocal;
using rpgNpcsDoJogo;
using rpgItensDoJogo;
using rpgZombiesDoJogo;
using rpgJogador;
using rpgPortasDoJogo;

namespace rpgMapa;

public class Mapa
{
    public List<Local> Locais {get; set;}
    public Local ruaPrincipal {get; private set;}
    public Local mercado {get; private set;}
    public Local igreja {get; private set;}
    public Local casaAbandonada {get; private set;}
    public Local hospital {get; private set;}
    public Local delegacia {get; private set;}
    public Local postoDeGasolina {get; private set;}
    public Local escola {get; private set;}
    public Local floresta {get; private set;}
    public Local biblioteca {get; private set;}
    public Local laboratorio {get; private set;}
    private Random random {get; set;}


    public Mapa(Random random)
    {
        Locais = new List<Local>();
        this.random = new Random();

        CriarLocais();
        ConectarLocais();
        AdicionarItens();
        AdicionarNpcs();
        AdicionarZombies();
    }
    private bool Chance(int porcentagem)
    {
        return random.Next(100) < porcentagem;
    }

    private void CriarLocais()
    {
     //locais
        ruaPrincipal = new Local("Rua principal", "A rua que conecta os principais pontos da cidade.");
        mercado = new Local("Mercado", "Um mercado todo bagunçado, aparentemente foi para onde muitas pessoas vieram no início do surto. Talvez você encontre coisas úteis aqui.");
        igreja = new Local("Igreja", "Uma igreja local, mas está toda ensanguentada e com as janelas quebradas. Deve ter sido um abrigo no início do surto.");
        casaAbandonada = new Local("Casa Abandonada", "Uma casa velha e quebrada, mas nas situações atuais, pode ser um bom abrigo. Ou não.");
        hospital = new Local("Hospital", "Um grande hospital que ajudou muitos feridos no início do surto e suportou por muito tempo. Mas até mesmo as coisas boas têm seu fim.");
        delegacia = new Local("Delegacia", "A delegacia municipal, parece relativamente segura, com as janelas blindadas e ainda intactas. Talvez você encontre armas e munição.");
        postoDeGasolina = new Local("Posto de Gasolina", "Um posto de galosina pequeno com uma lojinha de conveniencia. Tome cuidado por onde esbarra, pois há muitos carros abandonados e os alarmes podem soar.");
        escola = new Local("Escola", "Uma escola estudual, sempre vivída com crianças. Mas hoje, cos portões estão abertos e há diversos corpos no pátio. Talvez você encontre algum sobrevivente.");
        floresta = new Local("Floresta", "Uma grande floresta na extremidade da cidade. É uma boa rota de fuga, mas saiba onde você está, pois é fácil se perder.");
        biblioteca = new Local("Biblioteca", "A biblioteca central da cidade, com diversas enciclopédias. Talvez você descubra algo interessante nos livros.");
        laboratorio = new Local("Laboratório", "O laboratório federal, onde os principais estudos eram feitos. O que ele guarda pode mudar tudo.");

        Locais.Add(ruaPrincipal);
        Locais.Add(mercado);
        Locais.Add(igreja);
        Locais.Add(floresta);
        Locais.Add(casaAbandonada);
        Locais.Add(hospital);
        Locais.Add(delegacia);
        Locais.Add(postoDeGasolina);   
        Locais.Add(escola);
        Locais.Add(biblioteca);
        Locais.Add(laboratorio);
    }
    private void ConectarLocais()
    {
        //futuramente adicionar parametros no metodo para ser mais otimizado, mas no momento vai ficar assim especialmente para melhor visualização da logica do mapa :)

        //floresta
        floresta.Sul = igreja;

        //igreja
        igreja.Norte = floresta;
        igreja.Sul = ruaPrincipal;

        //rua principal
        ruaPrincipal.Norte = igreja;
        ruaPrincipal.Sul = delegacia;
        ruaPrincipal.Leste = escola;
        ruaPrincipal.Oeste = mercado;

        //mercado
        mercado.Leste = ruaPrincipal;
        mercado.Sul = casaAbandonada;

        //delegacia
        delegacia.Norte = ruaPrincipal;
        delegacia.Sul = postoDeGasolina;

        //escola
        escola.Oeste = ruaPrincipal;
        escola.Sul = biblioteca;

        //casa abandonada
        casaAbandonada.Norte = mercado;
        casaAbandonada.Leste = hospital;
        
        //posto de gasolina
        postoDeGasolina.Norte = delegacia;
        postoDeGasolina.Sul = hospital;

        //biblioteca
        biblioteca.Norte = escola;
        biblioteca.Oeste = hospital;

        //hospital
        hospital.Norte = postoDeGasolina;
        hospital.Sul = laboratorio;
        hospital.Leste = biblioteca;
        hospital.Oeste = casaAbandonada;

        //laboratorio
        laboratorio.Norte = hospital;
    }
    private void AdicionarItens()
    {
        //floresta
        if(Chance(20))
        {
            floresta.AdicionarItens(ItensDoJogo.CriarAgua());
        }
        if(Chance(15))
        {
            floresta.AdicionarItens(ItensDoJogo.CriarBandagem());
        }
        if(Chance(50))
        {
            floresta.AdicionarItens(ItensDoJogo.CriarMunicaoPistola());
        }

        //rua principal
        ruaPrincipal.AdicionarItens(ItensDoJogo.CriarAgua());
        ruaPrincipal.AdicionarItens(ItensDoJogo.CriarBandagem());
        ruaPrincipal.AdicionarItens(ItensDoJogo.CriarFaca());

        if(Chance(40))
        {
            ruaPrincipal.AdicionarItens(ItensDoJogo.CriarComidaEnlatada());    
        }
        if(Chance(5))
        {
            ruaPrincipal.AdicionarItens(ItensDoJogo.CriarMochila());    
        }
    }
    private void AdicionarNpcs()
    {
        floresta.AdicionarNpc(NpcsDoJogo.CriaCachorro());        
    }
    private void AdicionarZombies()
    {
        //rua principal
        ruaPrincipal.AdicionarZombie(ZombiesDoJogo.CriaZombieComumFraco());

        //floresta
        floresta.AdicionarZombie(ZombiesDoJogo.CriaZombieComumFraco());

        if(Chance(20))
        {
            floresta.AdicionarZombie(ZombiesDoJogo.CriaZombieJumper());
        }        
    }
    public void MostrarMapa()
    {
        Console.WriteLine(@"
                           Floresta
                              │
                              │
                           Igreja
                              │
                              │
                    Rua Principal
                    /     │      \
                   /      │       \
            Mercado   Delegacia   Escola
               │          │          │
               │      Posto de       │
               │      Gasolina       │
               │          │          │
        Casa Abandonada   │     Biblioteca
               │          │          │
               └────── Hospital ─────┘
                          │
                          │
                     Laboratório
        ");
    }
    public void MostrarLocalAtual(Jogador jogador)
    {
        Console.WriteLine("Atualmente, você está em: ");
        Local.DescreverLocal(jogador.LocalAtual);
    }
}