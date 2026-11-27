using rpgJogador;
using rpgLocal;
using rpgSala;
using rpgChave;
using rpgValidacaoInput;
using rpgPorta;
using rpgItem;
using rpgExploracao;
using rpgPortasDoJogo;

namespace rpgNavegacao;

class Navegacao
{
    private Jogador jogador;
    private Random random;
    private ValidacaoInput validacaoInput = new ValidacaoInput();
    
    public Navegacao(Jogador jogador, Random random)
    {
        this.jogador = jogador;
        this.random = random;
    }
    private enum opcoesDirecao
    {
        Norte = 'N',
        Leste = 'L',
        Oeste = 'O',
        Sul = 'S',
        Voltar = 'V'
    }
    public void MostrarDirecoes(Local local)
    {
        Console.WriteLine($"Para onde deseja ir? (Local atual: {jogador.LocalAtual.Nome})\n");

        Boolean temMapa = jogador.ContemMapa;

        if(local.Norte != null)
        {
            string nomeNorte = (temMapa || local.Norte.FoiVisitado) ? local.Norte.Nome : "??? (Desconhecido)";
            Console.WriteLine($"[N] - {nomeNorte}");
        }
        if(local.Leste != null)
        {
            string nomeLeste = (temMapa || local.Leste.FoiVisitado) ? local.Leste.Nome : "??? (Desconhecido)";
            Console.WriteLine($"[L] - {nomeLeste}");
        }
        if(local.Oeste != null)
        {
            string nomeOeste = (temMapa || local.Oeste.FoiVisitado) ? local.Oeste.Nome : "??? (Desconhecido)";
            Console.WriteLine($"[O] - {nomeOeste}");
        }
        if(local.Sul != null)
        {
            string nomeSul = (temMapa || local.Sul.FoiVisitado) ? local.Sul.Nome : "??? (Desconhecido)";
            Console.WriteLine($"[S] - {nomeSul}");
        }
        Console.WriteLine($"[V] Voltar");
    }    
    public void IrParaOutroLocal()
    {
        MostrarDirecoes(jogador.LocalAtual);

        while (true)
        {
            Console.Write("\n--> ");
            string entrada = Console.ReadLine() ?? "";
            Console.Write("\n");

            if (string.IsNullOrEmpty(entrada) || !char.IsLetter(entrada[0]))
                {
                    Console.WriteLine("Entrada inválida! Digite apenas letras (sem números ou símbolos).");
                    continue;
                }

            char direcaoEscolhida = char.ToUpper(entrada[0]);

            if(direcaoEscolhida != 'N' && direcaoEscolhida != 'L' && direcaoEscolhida != 'O' && direcaoEscolhida != 'S' && direcaoEscolhida != 'V')
            {
                Console.WriteLine("Direção inválida! Digite apenas N, L, O, S ou V.");

                continue;
            }

            opcoesDirecao escolhaDirecao = (opcoesDirecao)direcaoEscolhida;

            switch (escolhaDirecao)
            {
                case opcoesDirecao.Norte:
                    if(jogador.LocalAtual.Norte != null)
                    {
                        TentarEntrarNoLocal(jogador.LocalAtual.Norte);

                        return;
                    }

                    Console.WriteLine("Não há caminho ao Norte.\n");

                    break;
                case opcoesDirecao.Leste:
                    if(jogador.LocalAtual.Leste != null)
                    {
                        TentarEntrarNoLocal(jogador.LocalAtual.Leste);

                        return;
                    }

                    Console.WriteLine("Não há caminho ao Leste.\n");

                    break;                    
                case opcoesDirecao.Oeste:
                    if(jogador.LocalAtual.Oeste != null)
                    {
                        TentarEntrarNoLocal(jogador.LocalAtual.Oeste);
                        
                        return;
                    }
                    Console.WriteLine("Não há caminho ao Oeste.\n");

                    break;
                case opcoesDirecao.Sul:
                    if(jogador.LocalAtual.Sul != null)
                    {
                        TentarEntrarNoLocal(jogador.LocalAtual.Sul);
                        
                        return;
                    }
                    Console.WriteLine("Não há caminho ao Sul.\n");

                    break;                
                case opcoesDirecao.Voltar:
                    Console.WriteLine("Você decidiu permanecer no local atual.");
                return;
            }
        }
    } 
    private void TentarEntrarNoLocal(Local destino)
    {
        Porta? portaDoLocal = destino.PortaTrancada;

        if (portaDoLocal != null && portaDoLocal.ItemNecessario != null && !portaDoLocal.Aberta)
        {
            var itens = jogador.Inventario.ListarItens();
            Boolean abriu = false;

            foreach(Item item in itens)
            {
                if(item.tipoItem == portaDoLocal.ItemNecessario.tipoItem)
                {
                    portaDoLocal.Aberta = true;
                    destino.PortaAberta = true;
                    abriu = true;

                    Console.WriteLine($"Com o {item.Nome}, você conseguiu abrir a porta! Agora você tem acesso a {destino.Nome}.\n");

                    break;
                }
            }

            if (!abriu)
            {
                Console.WriteLine($"A porta da {destino.Nome} está bloqueada. Você precisa do {portaDoLocal.ItemNecessario.Nome} para abrir.\nVocê voltou para o local em que estava anteriormente...");
                
                return;
            }
        }

        jogador.LocalAtual = destino;

        jogador.SalaAtual = null;

        jogador.LocalAtual.FoiVisitado = true;

        Console.WriteLine($"Agora, você está em: < {jogador.LocalAtual.Nome} >");
        Console.WriteLine($"< {jogador.LocalAtual.Descricao} >");

        if (jogador.LocalAtual.Salas.Count > 0)
        {
            var exploracao = new Exploracao(jogador, random);
            exploracao.Explorar();
        }
    }
    public void EscolherSala()
    {       
        if(jogador.SalaAtual != null)
        {
            Console.WriteLine($"Sala atual: {jogador.SalaAtual.Nome}");
            Console.WriteLine($"< {jogador.SalaAtual.Descricao} >");
        } 

        Console.WriteLine("\nPara onde deseja ir?\n");

        List<Sala> salasDisponiveis = jogador.LocalAtual.Salas.Where(sala => sala != jogador.SalaAtual).ToList();

        while (true)
        {        
            for(int i = 0; i < salasDisponiveis.Count; i++)
            {
                Sala sala = salasDisponiveis[i];

                if(sala.PortaTrancada != null && !sala.PortaTrancada.Aberta)
                {
                    Console.WriteLine($"[{i + 1}] {sala.Nome} - Trancada");
                }
                else
                {
                    Console.WriteLine($"[{i + 1}] {sala.Nome}");
                }
            }
            Console.WriteLine("[0] Voltar");            

            int escolhaSala = validacaoInput.OpcaoValidada(salasDisponiveis.Count);            

            if(escolhaSala == 0)
            {
                break;
            }

            Sala salaEscolhida = salasDisponiveis[escolhaSala - 1];

            if(salaEscolhida.PortaTrancada != null && !salaEscolhida.PortaTrancada.Aberta)
            {
                Porta portaAtual = salaEscolhida.PortaTrancada;

                bool ehPortaSalaDeArmas = salaEscolhida.Nome.Equals("Sala de armas", StringComparison.OrdinalIgnoreCase) || (portaAtual.SalaPertencente?.Nome.Equals("Sala de armas", StringComparison.OrdinalIgnoreCase) ?? false);

                if (ehPortaSalaDeArmas && jogador.MissaoAtual?.Id == rpgMissao.IdMissao.Policial)
                {
                    Console.WriteLine("Você não pode abrir essa porta, pois a chave deve ser entregue ao policial Ethan.\n");

                    continue;
                }
                else if (ehPortaSalaDeArmas)
                {
                    Console.WriteLine("Essa sala está trancada.\n");

                    continue;
                }

                List<Chave> chaves = jogador.Inventario.ListarChaves();

                Boolean abriuPorta = false;

                foreach(Chave chave in chaves)
                {
                    if(portaAtual.Abrir(chave))
                    {
                        Console.WriteLine("Você consegue abrir a porta.\n");

                        Console.WriteLine($"Agora, você tem acesso a {salaEscolhida.Nome}.\n");

                        portaAtual.Aberta = true;

                        jogador.Inventario.DescartarItem(chave);

                        Console.WriteLine($"{chave.Nome} foi descartada.\n");

                        abriuPorta = true;

                        break;
                    }
                }

                if (!abriuPorta && portaAtual.ChaveNecessaria != null)
                {
                    Console.WriteLine($"Você não pode entrar nessa sala sem a {portaAtual.ChaveNecessaria.Nome}.\n");

                    continue;
                }
            }
            jogador.SalaAtual = salaEscolhida;

            Console.WriteLine($"Agora, você está em: < {jogador.SalaAtual.Nome} >");
            Console.WriteLine($"< {jogador.SalaAtual.Descricao} >");                
        
            break;
        }                 
    }       
}