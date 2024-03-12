using GerenciadorHospital.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciadorHospital.Data.Map
{
    public class RegistroConsultaMap : IEntityTypeConfiguration<RegistroConsultaModel>
    {
        public void Configure(EntityTypeBuilder<RegistroConsultaModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.PacienteId);
            builder.HasOne(x => x.Paciente);
        }
    }
}
