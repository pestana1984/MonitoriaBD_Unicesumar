using System;
using System.Collections.Generic;

namespace WebAPIClinicas.Models;

public partial class Clinica
{
    public int Clinicaid { get; set; }

    public string Nomefantasia { get; set; } = null!;

    public string Cnpj { get; set; } = null!;

    public int? Enderecoid { get; set; }

    public string? Telefonecontato { get; set; }

    public string? Emailcontato { get; set; }

    public virtual ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();

    public virtual Endereco? Endereco { get; set; }

    public virtual ICollection<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();
}
