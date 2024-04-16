using GerenciadorHospital.Data.Map;
using GerenciadorHospital.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorHospital.Data
{
    public class BancoContext : IdentityDbContext<UsuarioModel>
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options) { }

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

        #region OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PacienteMap());
            modelBuilder.ApplyConfiguration(new MedicoMap());
            modelBuilder.ApplyConfiguration(new ConvenioMap());
            modelBuilder.ApplyConfiguration(new TipoExameMap());
            modelBuilder.ApplyConfiguration(new RegistroConsultaMap());
            modelBuilder.ApplyConfiguration(new LaudoMap());
            modelBuilder.ApplyConfiguration(new MedicamentoPacienteMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());

            base.OnModelCreating(modelBuilder);
        }
        #endregion
    }
}
