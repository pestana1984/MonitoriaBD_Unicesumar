using System;
using System.Collections.Generic;

namespace WebAPIClinicas.Models;

public partial class Pagamento
{
    public int Pagamentoid { get; set; }

    public int Agendamentoid { get; set; }

    public decimal Valorconsulta { get; set; }

    public string? Meiopagamento { get; set; }

    public DateOnly? Datapagamento { get; set; }

    public string Statuspagamento { get; set; } = null!;

    public virtual Agendamento Agendamento { get; set; } = null!;
}
