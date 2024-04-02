using GerenciadorHospital.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciadorHospital.Data.Map
{
    public class TipoExameMap : IEntityTypeConfiguration<TipoExameModel>
    {
        public void Configure(EntityTypeBuilder<TipoExameModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.PacienteId);
            builder.Property(x => x.MedicoId);

            builder.HasOne(x => x.Medico);
            builder.HasOne(x => x.Paciente);
        }
    }
}
