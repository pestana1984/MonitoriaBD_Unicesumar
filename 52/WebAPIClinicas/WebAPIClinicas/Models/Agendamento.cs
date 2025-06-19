using System;
using System.Collections.Generic;

namespace WebAPIClinicas.Models;

public partial class Agendamento
{
    public int Agendamentoid { get; set; }

    public int Pacienteid { get; set; }

    public int Medicoid { get; set; }

    public int Clinicaid { get; set; }

    public DateOnly Datahoraconsulta { get; set; }

    public string Statusconsulta { get; set; } = null!;

    public virtual Clinica Clinica { get; set; } = null!;

    public virtual Medico Medico { get; set; } = null!;

    public virtual Paciente Paciente { get; set; } = null!;

    public virtual ICollection<Pagamento> Pagamentos { get; set; } = new List<Pagamento>();

    public virtual ICollection<Prontuario> Prontuarios { get; set; } = new List<Prontuario>();
}
