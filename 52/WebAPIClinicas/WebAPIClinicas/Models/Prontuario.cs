using System;
using System.Collections.Generic;

namespace WebAPIClinicas.Models;

public partial class Prontuario
{
    public int Prontuarioid { get; set; }

    public int Agendamentoid { get; set; }

    public int Pacienteid { get; set; }

    public string? Historicodoenca { get; set; }

    public string Diagnostico { get; set; } = null!;

    public string? Prescricaomedicamentos { get; set; }

    public string? Observacoes { get; set; }

    public virtual Agendamento Agendamento { get; set; } = null!;

    public virtual Paciente Paciente { get; set; } = null!;
}
