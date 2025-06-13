namespace WebAPIClinicas.Models
{
    public class Clinica
    {
        public int ClinicaID;
        public string NomeFantasia { get; set; } = string.Empty;
        public string CNPJ { get; set; } = string.Empty;
        public string TelefoneContato { get; set; } = string.Empty;
	    public string EmailContato { get; set; } = string.Empty;
        public Endereco Endereco { get; set; }
    }
}
