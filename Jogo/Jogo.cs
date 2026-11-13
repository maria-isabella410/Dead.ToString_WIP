using rpgExploracao;
using rpgInteracaoInventario;
using rpgJogador;
using rpgMapa;
using rpgMenuPrincipal;
using rpgNavegacao;
using rpgStatusDisplay;

namespace rpgJogo;

public class Jogo
{
    private Jogador Jogador = null!;
    private Boolean emExecucao; 
    private Mapa Mapa = null!;
    private Random random = new Random();
    private MenuPrincipal menuPrincipal = null!;
    private Exploracao exploracao = null!;
    private InteracaoInventario interacaoInventario = null!;
    private StatusDisplay statusDisplay = null!;
    private Navegacao navegacao = null!;
    public void Iniciar()
    {
        emExecucao = true;

        Mapa = new Mapa(random);

        Console.WriteLine("\nOlá, jogador! Seja bem-vindo(a) ao << Dead.ToString() >> !");
        Console.WriteLine("Durante essa jornada, qual será seu nome?\n");

        string nomeJogador;

        while (true)
        {
            Console.Write("--> ");
            nomeJogador = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(nomeJogador))
            {
                Console.WriteLine("\nO nome não pode estar vazio! Tente novamente.");
                continue;
            }

            bool nomeValido = true;

            foreach(char caractere in nomeJogador)
            {
                if(!char.IsLetter(caractere) && !char.IsWhiteSpace(caractere))
                {
                    nomeValido = false;
                    break;
                }
            }

            if(nomeValido) break;

            Console.WriteLine("\nNome inválido! Utilize apenas letras (sem números ou símbolos). Tente novamente.");
        }

        Jogador = new Jogador(50, 50, 15, 10, 25, null, nomeJogador, Mapa.ruaPrincipal, null);

        menuPrincipal = new MenuPrincipal(Jogador, Mapa);
        interacaoInventario = new InteracaoInventario(Jogador);
        statusDisplay = new StatusDisplay(Jogador);
        navegacao = new Navegacao(Jogador);
        exploracao = new Exploracao(Jogador, random);

        Introducao(Jogador);

        while (emExecucao)
        {
            if(Jogador.FinalizouJogo(Jogador.MatouBoss, Jogador.ConseguiuCura)) emExecucao = false;

            menuPrincipal.MostrarMenuPrincipal();

            opcoesMenu escolha = menuPrincipal.ReceberOpcao();

            switch (escolha)
            {
                case opcoesMenu.Explorar:
                    Boolean jogadorVivo = exploracao.Explorar();

                    if(!jogadorVivo) emExecucao = false;
                break;

                case opcoesMenu.AbrirMapa:
                    menuPrincipal.AbrirMapa();
                break;
                    
                case opcoesMenu.AbrirInventario:
                    interacaoInventario.AbrirInventario();
                break;

                case opcoesMenu.VerificarStatus:
                    statusDisplay.MostrarStatus(Jogador);
                break;

                case opcoesMenu.IrParaOutroLocal:
                    navegacao.IrParaOutroLocal();
                break;

                case opcoesMenu.EncerrarJogo:
                    emExecucao = false;
                break;         
            }
        }

        Encerrar();

        return;
    }

    public void Introducao(Jogador Jogador)
    {        
        Console.WriteLine("\nO mundo como conhecíamos acabou...");
        Console.WriteLine("Mortos-vivos tomaram as ruas da cidade, devorando todos as pessoas que encontravam!");
        Console.WriteLine("Algumas pessoas conseguiram escapar e se esconderam em abrigos improvisados, mas os recursos são escassos e as ruas são perigosas...");
        Console.WriteLine($"Você, {Jogador.Nome}, é uma dessas pessoas. Você sobreviveu até aqui, porém, mais do que sobreviver, você quer descobrir o que causou tudo isso e como resolver!");
        Console.WriteLine("Busque recursos, ajude outros sobreviventes, encontre respostas e claro, sobreviva.\n");

        Mapa.MostrarLocalAtual(Jogador);
    }
    public void Encerrar()
    {
        Console.WriteLine("\nJogo finalizado...\n");
    }
}