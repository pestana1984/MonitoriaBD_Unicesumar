using System;
using System.Collections.Generic;

namespace WebAPIClinicas.Models;

public partial class Medico
{
    public int Medicoid { get; set; }

    public string Especialidade { get; set; } = null!;

    public long Numerocrm { get; set; }

    public int Funcionarioid { get; set; }

    public virtual ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();

    public virtual Funcionario Funcionario { get; set; } = null!;
}
