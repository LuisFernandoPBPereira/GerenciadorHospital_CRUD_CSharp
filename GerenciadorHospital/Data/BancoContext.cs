using GerenciadorHospital.Data.Map;
using GerenciadorHospital.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorHospital.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options) { }
        
        public DbSet<PacienteModel> Pacientes { get; set; }
        public DbSet<MedicoModel> Medicos { get; set; }
        public DbSet<ConvenioModel> Convenios { get; set; }
        public DbSet<TipoExameModel> TiposExames { get; set; }
        public DbSet<RegistroConsultaModel> RegistrosConsultas { get; set; }
        public DbSet<LaudoModel> Laudos { get; set; }
        public DbSet<MedicamentoPacienteModel> MedicamentosPaciente { get; set; }
        //public DbSet<AdministradorModel> Administradores{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PacienteMap());
            modelBuilder.ApplyConfiguration(new MedicoMap());
            modelBuilder.ApplyConfiguration(new ConvenioMap());
            modelBuilder.ApplyConfiguration(new TipoExameMap());
            modelBuilder.ApplyConfiguration(new RegistroConsultaMap());
            modelBuilder.ApplyConfiguration(new LaudoMap());
            modelBuilder.ApplyConfiguration(new MedicamentoPacienteMap());
            //modelBuilder.ApplyConfiguration(new AdministradorMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
