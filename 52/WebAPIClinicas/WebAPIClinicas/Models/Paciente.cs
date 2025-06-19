using System;
using System.Collections.Generic;

namespace WebAPIClinicas.Models;

public partial class Paciente
{
    public int Pacienteid { get; set; }

    public string Nomecompleto { get; set; } = null!;

    public DateOnly Datanascimento { get; set; }

    public string Cpf { get; set; } = null!;

    public string? Telefone { get; set; }

    public string? Email { get; set; }

    public string Nomecontatoemergencia { get; set; } = null!;

    public string Telefonecontatoemergencia { get; set; } = null!;

    public virtual ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();

    public virtual ICollection<Prontuario> Prontuarios { get; set; } = new List<Prontuario>();
}
