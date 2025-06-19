using System;
using System.Collections;
using System.Collections.Generic;

namespace WebAPIClinicas.Models;

public partial class Funcionario
{
    public int Funcionarioid { get; set; }

    public string Nomecompleto { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public DateOnly Datanascimento { get; set; }

    public string Cargo { get; set; } = null!;

    public int Clinicaid { get; set; }

    public BitArray Ativo { get; set; } = null!;

    public virtual Clinica Clinica { get; set; } = null!;

    public virtual ICollection<Medico> Medicos { get; set; } = new List<Medico>();
}
