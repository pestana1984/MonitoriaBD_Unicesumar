using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebAPIClinicas.Models;

namespace WebAPIClinicas.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Agendamento> Agendamentos { get; set; }

    public virtual DbSet<Clinica> Clinicas { get; set; }

    public virtual DbSet<Endereco> Enderecos { get; set; }

    public virtual DbSet<Funcionario> Funcionarios { get; set; }

    public virtual DbSet<Medico> Medicos { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<Pagamento> Pagamentos { get; set; }

    public virtual DbSet<Prontuario> Prontuarios { get; set; }

    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code.
    //You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration
    //- see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings,
    //see https://go.microsoft.com/fwlink/?LinkId=723263.
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Server=dpg-d10qjb6mcj7s73bvle8g-a.virginia-postgres.render.com;Port=5432;Database=apimonitoria;Username=monitoria52;Password=5rIeWvThLrXgvcWZK7eAACsaAjcWwNw3");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("pg_stat_statements");

        modelBuilder.Entity<Agendamento>(entity =>
        {
            entity.HasKey(e => e.Agendamentoid).HasName("agendamentos_pkey");

            entity.ToTable("agendamentos");

            entity.Property(e => e.Agendamentoid).HasColumnName("agendamentoid");
            entity.Property(e => e.Clinicaid).HasColumnName("clinicaid");
            entity.Property(e => e.Datahoraconsulta).HasColumnName("datahoraconsulta");
            entity.Property(e => e.Medicoid).HasColumnName("medicoid");
            entity.Property(e => e.Pacienteid).HasColumnName("pacienteid");
            entity.Property(e => e.Statusconsulta)
                .HasMaxLength(255)
                .HasColumnName("statusconsulta");

            entity.HasOne(d => d.Clinica).WithMany(p => p.Agendamentos)
                .HasForeignKey(d => d.Clinicaid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("agendamentos_clinicaid_fkey");

            entity.HasOne(d => d.Medico).WithMany(p => p.Agendamentos)
                .HasForeignKey(d => d.Medicoid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("agendamentos_medicoid_fkey");

            entity.HasOne(d => d.Paciente).WithMany(p => p.Agendamentos)
                .HasForeignKey(d => d.Pacienteid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("agendamentos_pacienteid_fkey");
        });

        modelBuilder.Entity<Clinica>(entity =>
        {
            entity.HasKey(e => e.Clinicaid).HasName("clinicas_pkey");

            entity.ToTable("clinicas");

            entity.HasIndex(e => e.Cnpj, "clinicas_cnpj_key").IsUnique();

            entity.Property(e => e.Clinicaid).HasColumnName("clinicaid");
            entity.Property(e => e.Cnpj)
                .HasMaxLength(255)
                .HasColumnName("cnpj");
            entity.Property(e => e.Emailcontato)
                .HasMaxLength(255)
                .HasColumnName("emailcontato");
            entity.Property(e => e.Enderecoid).HasColumnName("enderecoid");
            entity.Property(e => e.Nomefantasia)
                .HasMaxLength(255)
                .HasColumnName("nomefantasia");
            entity.Property(e => e.Telefonecontato)
                .HasMaxLength(255)
                .HasColumnName("telefonecontato");

            entity.HasOne(d => d.Endereco).WithMany(p => p.Clinicas)
                .HasForeignKey(d => d.Enderecoid)
                .HasConstraintName("clinicas_enderecoid_fkey");
        });

        modelBuilder.Entity<Endereco>(entity =>
        {
            entity.HasKey(e => e.Enderecoid).HasName("pk_endereco");

            entity.HasIndex(e => e.Enderecoid, "enderecos_enderecoid_key").IsUnique();

            entity.Property(e => e.Enderecoid).HasColumnName("enderecoid");
            entity.Property(e => e.Bairro)
                .HasMaxLength(255)
                .HasColumnName("bairro");
            entity.Property(e => e.Cep)
                .HasMaxLength(255)
                .HasColumnName("cep");
            entity.Property(e => e.Cidade)
                .HasMaxLength(255)
                .HasColumnName("cidade");
            entity.Property(e => e.Estado)
                .HasMaxLength(2)
                .HasColumnName("estado");
            entity.Property(e => e.Logradouro)
                .HasMaxLength(255)
                .HasColumnName("logradouro");
            entity.Property(e => e.Numero).HasColumnName("numero");
        });

        modelBuilder.Entity<Funcionario>(entity =>
        {
            entity.HasKey(e => e.Funcionarioid).HasName("funcionarios_pkey");

            entity.ToTable("funcionarios");

            entity.HasIndex(e => e.Cpf, "funcionarios_cpf_key").IsUnique();

            entity.Property(e => e.Funcionarioid).HasColumnName("funcionarioid");
            entity.Property(e => e.Ativo)
                .HasColumnType("bit(1)")
                .HasColumnName("ativo");
            entity.Property(e => e.Cargo)
                .HasMaxLength(255)
                .HasColumnName("cargo");
            entity.Property(e => e.Clinicaid).HasColumnName("clinicaid");
            entity.Property(e => e.Cpf)
                .HasMaxLength(255)
                .HasColumnName("cpf");
            entity.Property(e => e.Datanascimento).HasColumnName("datanascimento");
            entity.Property(e => e.Nomecompleto)
                .HasMaxLength(255)
                .HasColumnName("nomecompleto");

            entity.HasOne(d => d.Clinica).WithMany(p => p.Funcionarios)
                .HasForeignKey(d => d.Clinicaid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("funcionarios_clinicaid_fkey");
        });

        modelBuilder.Entity<Medico>(entity =>
        {
            entity.HasKey(e => e.Medicoid).HasName("medicos_pkey");

            entity.ToTable("medicos");

            entity.Property(e => e.Medicoid).HasColumnName("medicoid");
            entity.Property(e => e.Especialidade)
                .HasMaxLength(255)
                .HasColumnName("especialidade");
            entity.Property(e => e.Funcionarioid).HasColumnName("funcionarioid");
            entity.Property(e => e.Numerocrm).HasColumnName("numerocrm");

            entity.HasOne(d => d.Funcionario).WithMany(p => p.Medicos)
                .HasForeignKey(d => d.Funcionarioid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("medicos_funcionarioid_fkey");
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.Pacienteid).HasName("pacientes_pkey");

            entity.ToTable("pacientes");

            entity.HasIndex(e => e.Cpf, "pacientes_cpf_key").IsUnique();

            entity.Property(e => e.Pacienteid).HasColumnName("pacienteid");
            entity.Property(e => e.Cpf)
                .HasMaxLength(255)
                .HasColumnName("cpf");
            entity.Property(e => e.Datanascimento).HasColumnName("datanascimento");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Nomecompleto)
                .HasMaxLength(255)
                .HasColumnName("nomecompleto");
            entity.Property(e => e.Nomecontatoemergencia)
                .HasMaxLength(255)
                .HasColumnName("nomecontatoemergencia");
            entity.Property(e => e.Telefone)
                .HasMaxLength(255)
                .HasColumnName("telefone");
            entity.Property(e => e.Telefonecontatoemergencia)
                .HasMaxLength(255)
                .HasColumnName("telefonecontatoemergencia");
        });

        modelBuilder.Entity<Pagamento>(entity =>
        {
            entity.HasKey(e => e.Pagamentoid).HasName("pagamentos_pkey");

            entity.ToTable("pagamentos");

            entity.Property(e => e.Pagamentoid).HasColumnName("pagamentoid");
            entity.Property(e => e.Agendamentoid).HasColumnName("agendamentoid");
            entity.Property(e => e.Datapagamento).HasColumnName("datapagamento");
            entity.Property(e => e.Meiopagamento)
                .HasMaxLength(255)
                .HasColumnName("meiopagamento");
            entity.Property(e => e.Statuspagamento)
                .HasMaxLength(255)
                .HasColumnName("statuspagamento");
            entity.Property(e => e.Valorconsulta).HasColumnName("valorconsulta");

            entity.HasOne(d => d.Agendamento).WithMany(p => p.Pagamentos)
                .HasForeignKey(d => d.Agendamentoid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pagamentos_agendamentoid_fkey");
        });

        modelBuilder.Entity<Prontuario>(entity =>
        {
            entity.HasKey(e => e.Prontuarioid).HasName("prontuarios_pkey");

            entity.ToTable("prontuarios");

            entity.Property(e => e.Prontuarioid).HasColumnName("prontuarioid");
            entity.Property(e => e.Agendamentoid).HasColumnName("agendamentoid");
            entity.Property(e => e.Diagnostico)
                .HasMaxLength(255)
                .HasColumnName("diagnostico");
            entity.Property(e => e.Historicodoenca)
                .HasMaxLength(255)
                .HasColumnName("historicodoenca");
            entity.Property(e => e.Observacoes)
                .HasMaxLength(255)
                .HasColumnName("observacoes");
            entity.Property(e => e.Pacienteid).HasColumnName("pacienteid");
            entity.Property(e => e.Prescricaomedicamentos)
                .HasMaxLength(255)
                .HasColumnName("prescricaomedicamentos");

            entity.HasOne(d => d.Agendamento).WithMany(p => p.Prontuarios)
                .HasForeignKey(d => d.Agendamentoid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("prontuarios_agendamentoid_fkey");

            entity.HasOne(d => d.Paciente).WithMany(p => p.Prontuarios)
                .HasForeignKey(d => d.Pacienteid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("prontuarios_pacienteid_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
