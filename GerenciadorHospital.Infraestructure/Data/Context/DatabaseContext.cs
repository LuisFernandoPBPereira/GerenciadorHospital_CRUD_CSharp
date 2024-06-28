using GerenciadorHospital.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorHospital.Infraestructure.Data.Context;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions options) : base(options){}

    #region DbSet das Models
    public DbSet<PacienteModel> Pacientes { get; set; }
    public DbSet<MedicoModel> Medicos { get; set; }
    public DbSet<ConvenioModel> Convenios { get; set; }
    public DbSet<TipoExameModel> TiposExames { get; set; }
    public DbSet<RegistroConsultaModel> RegistrosConsultas { get; set; }
    public DbSet<LaudoModel> Laudos { get; set; }
    public DbSet<MedicamentoPacienteModel> MedicamentosPaciente { get; set; }
    public DbSet<UsuarioModel> Usuarios { get; set; }
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
