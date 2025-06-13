namespace WebAPIClinicas.Models
{
    public class Pagamento
    {
        public int PagamentoID { get; set;}
        public Agendamento Agendamento { get; set;}
	    public double ValorConsulta { get; set;}
        public string MeioPagamento { get; set;}
	    public DateOnly DataPagamento { get; set;}
        public string StatusPagamento { get; set; }
    }
}
