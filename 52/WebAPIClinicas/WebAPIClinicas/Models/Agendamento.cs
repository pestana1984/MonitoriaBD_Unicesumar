namespace WebAPIClinicas.Models
{
    public class Agendamento
    {
        public int AgendamentoID {get; set;}
        public Paciente Paciente {get; set;}
	    public Medico Medico {get; set;}
        public Clinica Clinica {get; set;}
	    public DateTime DataHoraConsulta {get; set;}
        public string StatusConsulta { get; set; }
    }
}
