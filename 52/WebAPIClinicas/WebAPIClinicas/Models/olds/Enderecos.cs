using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIClinicas.Models.olds
{
    [Table("Enderecos")]
    public class Enderecos
    {
        [Key]
        [Column("enderecoid")]
        public int EnderecoId { get; set; }
        public string Logradouro {get; set;}
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}