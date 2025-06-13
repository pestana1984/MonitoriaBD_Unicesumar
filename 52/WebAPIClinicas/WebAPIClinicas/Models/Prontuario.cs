namespace WebAPIClinicas.Models
{
    public class Prontuario
    {
        public int ProntuarioID { get; set; }
        public Agendamento Agendamento {get; set;}
	    public Paciente Paciente {get; set;}
        public string HistoricoDoenca {get; set;}
	    public string Diagnostico {get; set;}
        public string PrescricaoMedicamentos {get; set;}
	    public string Observacoes {get; set;}
    }
}
