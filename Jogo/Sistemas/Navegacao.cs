using rpgJogador;
using rpgLocal;
using rpgSala;
using rpgChave;
using rpgValidacaoInput;
using rpgPorta;
using rpgItem;
using rpgItensDoJogo;

namespace rpgNavegacao;

class Navegacao
{
    private Jogador jogador;
    private ValidacaoInput validacaoInput = new ValidacaoInput();
    
    public Navegacao(Jogador jogador)
    {
        this.jogador = jogador;
    }
    private enum opcoesDirecao
    {
        Norte = 'N',
        Leste = 'L',
        Oeste = 'O',
        Sul = 'S'
    }
    public void MostrarDirecoes(Local local)
    {
        Console.WriteLine("Para onde deseja ir?\n");

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
    }    
    public void IrParaOutroLocal()
    {
        MostrarDirecoes(jogador.LocalAtual);

        char direcaoEscolhida;

        while (true)
        {
            Console.Write("\n--> ");
            string entrada = Console.ReadLine() ?? "";
            Console.Write("\n");

            if (!string.IsNullOrEmpty(entrada))
            {
                char primeiroCaractere = char.ToUpper(entrada[0]);

                if (char.IsLetter(primeiroCaractere))
                {
                    direcaoEscolhida = primeiroCaractere;

                    if(direcaoEscolhida == 'N' || direcaoEscolhida == 'L' || direcaoEscolhida == 'O' || direcaoEscolhida == 'S')
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nDireção inválida! Digite apenas N, L, O ou S.\n");

                        continue;
                    }
                }
            }
            
            Console.WriteLine("Entrada inválida! Digite apenas letras (sem números ou símbolos).");
        }

        opcoesDirecao escolhaDirecao = (opcoesDirecao)direcaoEscolhida;

        switch (escolhaDirecao)
        {
            case opcoesDirecao.Norte:
                if(jogador.LocalAtual.Norte != null)
                {
                    TentarEntrarNoLocal(jogador.LocalAtual.Norte);
                }                        

            break;
            case opcoesDirecao.Leste:
                if(jogador.LocalAtual.Leste != null)
                {
                    TentarEntrarNoLocal(jogador.LocalAtual.Leste);
                }
                
            break;
            case opcoesDirecao.Oeste:
                if(jogador.LocalAtual.Oeste != null)
                {
                    TentarEntrarNoLocal(jogador.LocalAtual.Oeste);
                }
                
            break;
            case opcoesDirecao.Sul:
                if(jogador.LocalAtual.Sul != null)
                {
                    TentarEntrarNoLocal(jogador.LocalAtual.Sul);
                }
        
            break;
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

                    Console.WriteLine($"Com o {item.Nome}, você conseguiu abrir a porta! Agora você tem acesso a {destino.Nome}.");

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

        if(jogador.LocalAtual.Salas.Count > 0) EscolherSala();
    }
    public void EscolherSala()
    {
        //Console.WriteLine($"[DEBUG] {jogador.LocalAtual.Nome} tem {jogador.LocalAtual.Salas.Count} salas");
        
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

                List<Chave> chaves = jogador.Inventario.ListarChaves();

                Boolean abriuPorta = false;

                foreach(Chave chave in chaves)
                {
                    if(portaAtual.Abrir(chave))
                    {
                        Console.WriteLine("Você consegue abrir a porta.");

                        Console.WriteLine($"\nAgora, você tem acesso a {salaEscolhida.Nome}.\n");

                        portaAtual.Aberta = true;

                        jogador.Inventario.DescartarItem(chave);

                        Console.WriteLine($"{chave.Nome} foi descartada.");

                        abriuPorta = true;

                        return;
                    }
                }

                if (!abriuPorta &&portaAtual.ChaveNecessaria != null)
                {
                    Console.WriteLine($"Você não pode entrar nessa sala sem a {portaAtual.ChaveNecessaria.Nome}.");
                    return;
                }
            }
            jogador.SalaAtual = salaEscolhida;

            Console.WriteLine($"Agora, você está em: < {jogador.SalaAtual.Nome} >");
            Console.WriteLine($"< {jogador.SalaAtual.Descricao} >");                
        
            break;
        }                 
    }       
}