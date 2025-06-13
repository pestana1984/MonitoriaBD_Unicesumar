namespace WebAPIClinicas.Models
{
    public class Medico
    {
        public int MedicoID { get; set; }        
        public string Especialidade { get; set; }
        public int NumeroCRM { get; set; }       
	    public Funcionario Funcionario { get; set; }
    }
}
