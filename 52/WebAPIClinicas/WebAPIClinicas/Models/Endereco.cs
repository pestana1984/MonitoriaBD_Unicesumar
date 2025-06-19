using System;
using System.Collections.Generic;

namespace WebAPIClinicas.Models;

public partial class Endereco
{
    public int Enderecoid { get; set; }

    public string Logradouro { get; set; } = null!;

    public int Numero { get; set; }

    public string Bairro { get; set; } = null!;

    public string Cep { get; set; } = null!;

    public string Cidade { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public virtual ICollection<Clinica> Clinicas { get; set; } = new List<Clinica>();
}
