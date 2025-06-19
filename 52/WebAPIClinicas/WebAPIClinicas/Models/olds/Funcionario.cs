namespace WebAPIClinicas.Models.olds
{
    public class Funcionario
    {
        public int FuncionarioID { get; set; }
        public string NomeCompleto { get; set; }
        public string CPF { get; set; }
        public DateOnly DataNascimento { get; set; }
        public string Cargo { get; set; }
        public Clinica Clinica { get; set; }
        public bool Ativo { get; set; }
    }
}
