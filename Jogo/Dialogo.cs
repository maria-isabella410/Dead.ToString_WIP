namespace rpgDialogo;

public class Dialogo
{
    public String Saudacao;
    public String Cumprimento;
    public String? Introducao;
    public String Historia;
    public String? HistoriaContinuacao;
    public String? Missao;
    public String? DespedidaMissaoAceitada;
    public String? DespedidaMissaoRecusada;
    public String? AgradecimentoMissao;
    public String? MissaoConcluida;

    public Dialogo(String saudacao, String cumprimento, String? introducao, String historia, String? historiacontinuacao, String? missao, String? despedidamissaoaceitada, String? despedidamissaorecusada, String? agrecimentomissao, String? missaococluida)
    {
        this.Saudacao = saudacao;
        this.Cumprimento = cumprimento;
        this.Introducao = introducao;
        this.Historia = historia;
        this.HistoriaContinuacao = historiacontinuacao;
        this.Missao = missao;
        this.DespedidaMissaoAceitada= despedidamissaoaceitada;
        this.DespedidaMissaoRecusada = despedidamissaorecusada;
        this.AgradecimentoMissao = agrecimentomissao;
        this.MissaoConcluida = missaococluida;
    }
}