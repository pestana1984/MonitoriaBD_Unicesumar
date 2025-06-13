namespace WebAPIClinicas.Models
{
    public class Paciente
    {
        public int PacienteID {get; set;}
        public string NomeCompleto {get; set;}
        public DateOnly DataNascimento {get; set;}
        public string CPF {get; set;}
        public string Telefone {get; set;}
	    public string Email {get; set;}
	    public string NomeContatoEmergencia {get; set;}
        public string TelefoneContatoEmergencia { get; set; }
    }
}
