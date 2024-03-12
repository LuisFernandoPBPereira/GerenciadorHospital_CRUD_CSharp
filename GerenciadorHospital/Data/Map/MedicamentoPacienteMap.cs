using GerenciadorHospital.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciadorHospital.Data.Map
{
    public class MedicamentoPacienteMap : IEntityTypeConfiguration<MedicamentoPacienteModel>
    {
        public void Configure(EntityTypeBuilder<MedicamentoPacienteModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Composicao).IsRequired().HasMaxLength(150);
            builder.Property(x => x.DataFabricacao).IsRequired();
            builder.Property(x => x.DataValidade).IsRequired();
            builder.Property(x => x.PacienteId).IsRequired();
            builder.HasOne(x => x.Paciente);
        }
    }
}
