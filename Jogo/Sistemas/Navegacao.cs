using rpgJogador;
using rpgLocal;
using rpgSala;
using rpgChave;
using rpgValidacaoInput;

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
        Console.WriteLine("Para onde deseja ir?");

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
            Console.Write("--> ");
            string entrada = Console.ReadLine() ?? "";

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
                        Console.WriteLine("\nDireção inválida! Digite apenas N, L, O ou S.");

                        continue;
                    }
                }
            }
            
            Console.WriteLine("\nEntrada inválida! Digite apenas letras (sem números ou símbolos).");
        }

        opcoesDirecao escolhaDirecao = (opcoesDirecao)direcaoEscolhida;

        switch (escolhaDirecao)
        {
            case opcoesDirecao.Norte:
                if(jogador.LocalAtual.Norte != null)
                {
                    jogador.LocalAtual = jogador.LocalAtual.Norte;
                    jogador.SalaAtual = null;

                    jogador.LocalAtual.FoiVisitado = true;

                    Console.WriteLine($"\nAgora, você está em: < {jogador.LocalAtual.Nome} >");
                    Console.WriteLine($"< {jogador.LocalAtual.Descricao} >\n");
                }                        

            break;
            case opcoesDirecao.Leste:
                if(jogador.LocalAtual.Leste != null)
                {
                    jogador.LocalAtual = jogador.LocalAtual.Leste;
                    jogador.SalaAtual = null;

                    jogador.LocalAtual.FoiVisitado = true;

                    Console.WriteLine($"\nAgora, você está em: < {jogador.LocalAtual.Nome} >");
                    Console.WriteLine($"< {jogador.LocalAtual.Descricao} >\n");
                }                     
                
            break;
            case opcoesDirecao.Oeste:
                if(jogador.LocalAtual.Oeste != null)
                {
                    jogador.LocalAtual = jogador.LocalAtual.Oeste;
                    jogador.SalaAtual = null;

                    jogador.LocalAtual.FoiVisitado = true;

                    Console.WriteLine($"\nAgora, você está em: < {jogador.LocalAtual.Nome} >");
                    Console.WriteLine($"< {jogador.LocalAtual.Descricao} >\n");
                }           
                
            break;
            case opcoesDirecao.Sul:
                if(jogador.LocalAtual.Sul != null)
                {
                    jogador.LocalAtual = jogador.LocalAtual.Sul;
                    jogador.SalaAtual = null;

                    jogador.LocalAtual.FoiVisitado = true;

                    Console.WriteLine($"\nAgora, você está em: < {jogador.LocalAtual.Nome} >");
                    Console.WriteLine($"< {jogador.LocalAtual.Descricao} >\n");
                }           
        
            break;
        }

        if(jogador.LocalAtual.Salas != null)
        {
            EscolherSala();
        }
    } 
    public void EscolherSala()
    {
        //Console.WriteLine($"[DEBUG] {jogador.LocalAtual.Nome} tem {jogador.LocalAtual.Salas.Count} salas");
        
        if(jogador.SalaAtual != null)
        {
            Console.WriteLine($"\nSala atual: {jogador.SalaAtual.Nome}");
            Console.WriteLine($"< {jogador.SalaAtual.Descricao} >\n");
        } 

        Console.WriteLine("Para onde deseja ir? (0 para Voltar)");

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

            int escolhaSala = validacaoInput.OpcaoValidada(salasDisponiveis.Count);            

            if(escolhaSala == 0)
            {
                break;
            }

            Sala salaEscolhida = salasDisponiveis[escolhaSala - 1];


            if(salaEscolhida.PortaTrancada != null && !salaEscolhida.PortaTrancada.Aberta)
            {
                List<Chave> chaves = jogador.Inventario.ListarChaves();

                Console.WriteLine($"\nVocê não pode entrar nessa sala sem a {salaEscolhida.PortaTrancada.ChaveNecessaria.Nome}.");

                foreach(Chave chave in chaves)
                {
                    if(chave.Tipo == salaEscolhida.PortaTrancada.ChaveNecessaria.Tipo)
                    {
                        Console.WriteLine("\nVocê consegue abrir a porta.");
                        Console.WriteLine($"\nAgora, você tem acesso a {salaEscolhida.Nome}.");

                        salaEscolhida.PortaTrancada.Aberta = true;

                        jogador.Inventario.DescartarItem(chave);

                        Console.WriteLine($"\n{chave.Nome} foi descartada.\n");

                        break;
                    }
                }
                if (!salaEscolhida.PortaTrancada.Aberta)
                {
                    Console.WriteLine("\nVocê não tem a chave necessária para abrir essa porta.");

                    break;
                } 
            }
            jogador.SalaAtual = salaEscolhida;

            Console.WriteLine($"\nAgora, você está em: < {jogador.SalaAtual.Nome} >");
            Console.WriteLine($"< {jogador.SalaAtual.Descricao} >\n");                
        
            break;
        }                 
    }       
}