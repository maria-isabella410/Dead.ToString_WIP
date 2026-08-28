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

        //igreja
        igreja.AdicionarItens(ItensDoJogo.CriarComidaEnlatada());

        if(Chance(50))
        {
            igreja.AdicionarItens(ItensDoJogo.CriarBandagem());
        }
        if(Chance(40))
        {
            igreja.AdicionarItens(ItensDoJogo.CriarAgua());
        }
        if(Chance(10))
        {
            igreja.AdicionarItens(ItensDoJogo.CriarKitMed());
        }
        if(Chance(50))
        {
            igreja.AdicionarItens(ItensDoJogo.CriarMunicaoPistola());
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

        //delegacia
        delegacia.AdicionarItens(ItensDoJogo.CriarPistola());
        delegacia.AdicionarItens(ItensDoJogo.CriarChaveSalaDeArmas());

        if(Chance(80))
        {
            delegacia.AdicionarItens(ItensDoJogo.CriarMunicaoPistola());
        }
        if(Chance(40))
        {
            delegacia.AdicionarItens(ItensDoJogo.CriarMunicaoShotgun());
        }
        if(Chance(30))
        {
            delegacia.AdicionarItens(ItensDoJogo.CriarBandagem());
        }

        //posto de gasolina
        postoDeGasolina.AdicionarItens(ItensDoJogo.CriarAgua());
        postoDeGasolina.AdicionarItens(ItensDoJogo.CriarMapaDaCidade());

        if(Chance(40))
        {
            postoDeGasolina.AdicionarItens(ItensDoJogo.CriarComidaEnlatada());
        }
        if(Chance(30))
        {
            postoDeGasolina.AdicionarItens(ItensDoJogo.CriarBandagem());
        }
        if(Chance(30))
        {
            postoDeGasolina.AdicionarItens(ItensDoJogo.CriarSpray());
        }
        if(Chance(50))
        {
            postoDeGasolina.AdicionarItens(ItensDoJogo.CriarMunicaoPistola());
        }

        //mercado
        mercado.AdicionarItens(ItensDoJogo.CriarAgua());
        mercado.AdicionarItens(ItensDoJogo.CriarComidaEnlatada());
        mercado.AdicionarItens(ItensDoJogo.CriarBandagem());

        if(Chance(30))
        {
            mercado.AdicionarItens(ItensDoJogo.CriarComidaEnlatada());
        }
        if(Chance(30))
        {
            mercado.AdicionarItens(ItensDoJogo.CriarAgua());
        }
        if(Chance(70))
        {
            mercado.AdicionarItens(ItensDoJogo.CriarBandagem());
        }
        if(Chance(30))
        {
            mercado.AdicionarItens(ItensDoJogo.CriarKitMed());
        }
        if(Chance(25))
        {
            mercado.AdicionarItens(ItensDoJogo.CriarSpray());
        }
        if(Chance(50))
        {
            mercado.AdicionarItens(ItensDoJogo.CriarMunicaoPistola());
        }
        if(Chance(40))
        {
            mercado.AdicionarItens(ItensDoJogo.CriarMunicaoShotgun());
        }

        //casa abandonada
        casaAbandonada.AdicionarItens(ItensDoJogo.CriarAgua());

        if(Chance(40))
        {
            casaAbandonada.AdicionarItens(ItensDoJogo.CriarBandagem());
        }
        if(Chance(35))
        {
            casaAbandonada.AdicionarItens(ItensDoJogo.CriarComidaEnlatada());
        }
        if(Chance(25))
        {
            casaAbandonada.AdicionarItens(ItensDoJogo.CriarSpray());
        }
        if(Chance(30))
        {
            casaAbandonada.AdicionarItens(ItensDoJogo.CriarMunicaoPistola());
        }
        if(Chance(20))
        {
            casaAbandonada.AdicionarItens(ItensDoJogo.CriarMunicaoShotgun());
        }

        //escola
        escola.AdicionarItens(ItensDoJogo.CriarChaveSalaDeAula());

        if(Chance(40))
        {
            escola.AdicionarItens(ItensDoJogo.CriarBandagem());
        }
        if(Chance(20))
        {
            escola.AdicionarItens(ItensDoJogo.CriarComidaEnlatada());
        }
        if(Chance(20))
        {
            escola.AdicionarItens(ItensDoJogo.CriarAgua());
        }

        //biblioteca
        biblioteca.AdicionarItens(ItensDoJogo.CriarChaveSalaBiblioteca());
        biblioteca.AdicionarItens(ItensDoJogo.CriarDiario());

        if(Chance(20))
        {
            biblioteca.AdicionarItens(ItensDoJogo.CriarAgua());
        }
        if(Chance(20))
        {
            biblioteca.AdicionarItens(ItensDoJogo.CriarBandagem());
        }

        //hospital
        hospital.AdicionarItens(ItensDoJogo.CriarChaveEstoqueHospital());
        hospital.AdicionarItens(ItensDoJogo.CriarKitMed());
        hospital.AdicionarItens(ItensDoJogo.CriarSpray());

        if(Chance(80))
        {
            hospital.AdicionarItens(ItensDoJogo.CriarBandagem());
        }
        if(Chance(50))
        {
            hospital.AdicionarItens(ItensDoJogo.CriarSpray());
        }
        if(Chance(40))
        {
            hospital.AdicionarItens(ItensDoJogo.CriarAgua());
        }
        if(Chance(30))
        {
            hospital.AdicionarItens(ItensDoJogo.CriarKitMed());
        }
        if(Chance(40))
        {
            hospital.AdicionarItens(ItensDoJogo.CriarMunicaoPistola());
        }
        if(Chance(30))
        {
            hospital.AdicionarItens(ItensDoJogo.CriarMunicaoShotgun());
        }

        //laboratorio
        laboratorio.AdicionarItens(ItensDoJogo.CriarAntidoto());

        if(Chance(40))
        {
            laboratorio.AdicionarItens(ItensDoJogo.CriarSpray());
        }
        if(Chance(30))
        {
            laboratorio.AdicionarItens(ItensDoJogo.CriarKitMed());
        }

    }
    private void AdicionarNpcs()
    {
        igreja.AdicionarNpc(NpcsDoJogo.CriaPadre());
        floresta.AdicionarNpc(NpcsDoJogo.CriaCachorro());
        delegacia.AdicionarNpc(NpcsDoJogo.CriaPolicial());
        escola.AdicionarNpc(NpcsDoJogo.CriaProfessora());
        escola.AdicionarNpc(NpcsDoJogo.CriaCrianca());
        hospital.AdicionarNpc(NpcsDoJogo.CriaEnfermeira()); 
        laboratorio.AdicionarNpc(NpcsDoJogo.CriaCientista());
    }
    private void AdicionarZombies()
    {
        //rua principal
        ruaPrincipal.AdicionarZombie(ZombiesDoJogo.CriaZombieComumFraco());


        //igreja
        igreja.AdicionarZombie(ZombiesDoJogo.CriaZombieComumFraco());

        if(Chance(10))
        {
            igreja.AdicionarZombie(ZombiesDoJogo.CriaZombieJumper());
        }


        //floresta
        floresta.AdicionarZombie(ZombiesDoJogo.CriaZombieComumFraco());

        if(Chance(20))
        {
            floresta.AdicionarZombie(ZombiesDoJogo.CriaZombieJumper());
        }


        //mercado
        mercado.AdicionarZombie(ZombiesDoJogo.CriaZombieComumFraco());
        mercado.AdicionarZombie(ZombiesDoJogo.CriaZombieComumForte());

        if(Chance(40))
        {
            mercado.AdicionarZombie(ZombiesDoJogo.CriaZombieComumForte());
        }
        if(Chance(5))
        {
            mercado.AdicionarZombie(ZombiesDoJogo.CriaZombieTank());
        }

        //casa abandonada
        casaAbandonada.AdicionarZombie(ZombiesDoJogo.CriaZombieComumForte());

        if(Chance(40))
        {
            casaAbandonada.AdicionarZombie(ZombiesDoJogo.CriaZombieComumFraco());
        }

        //delegacia
        delegacia.AdicionarZombie(ZombiesDoJogo.CriaZombieComumForte());
        delegacia.AdicionarZombie(ZombiesDoJogo.CriaZombieComumFraco());

        if(Chance(20))
        {
            delegacia.AdicionarZombie(ZombiesDoJogo.CriaZombieComumFraco());
        }

        //posto de gasolina
        postoDeGasolina.AdicionarZombie(ZombiesDoJogo.CriaZombieJumper());
        postoDeGasolina.AdicionarZombie(ZombiesDoJogo.CriaZombieComumFraco());

        if(Chance(50))
        {
            postoDeGasolina.AdicionarZombie(ZombiesDoJogo.CriaZombieComumForte());
        }

        //escola
        escola.AdicionarZombie(ZombiesDoJogo.CriaZombieTank());
        escola.AdicionarZombie(ZombiesDoJogo.CriaZombieComumForte());
        escola.AdicionarZombie(ZombiesDoJogo.CriaZombieComumFraco());

        if(Chance(20))
        {
            escola.AdicionarZombie(ZombiesDoJogo.CriaZombieComumFraco());
        }

        //hospital
        hospital.AdicionarZombie(ZombiesDoJogo.CriaZombieComumForte());
        hospital.AdicionarZombie(ZombiesDoJogo.CriaZombieComumForte());
        hospital.AdicionarZombie(ZombiesDoJogo.CriaZombieComumFraco());

        if(Chance(40))
        {
            hospital.AdicionarZombie(ZombiesDoJogo.CriaZombieJumper());
        }
        if(Chance(60))
        {
            hospital.AdicionarZombie(ZombiesDoJogo.CriaZombieComumFraco());
        }

        //biblioteca
        biblioteca.AdicionarZombie(ZombiesDoJogo.CriaZombieComumFraco());


        //laboratorio
        laboratorio.AdicionarZombie(ZombiesDoJogo.CriaZombieComumForte());
        laboratorio.AdicionarZombie(ZombiesDoJogo.CriaZombieComumFraco());
        laboratorio.AdicionarZombie(ZombiesDoJogo.CriaZombieFinal());

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