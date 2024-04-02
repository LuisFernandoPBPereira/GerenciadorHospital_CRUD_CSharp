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
            builder.Property(x => x.DataConsulta);
            builder.Property(x => x.PacienteId);
            builder.Property(x => x.Valor);
            builder.Property(x => x.DataRetorno);
            builder.Property(x => x.EstadoConsulta);
            builder.Property(x => x.MedicoId);
            builder.Property(x => x.LaudoId);
            builder.Property(x => x.ExameId);
            builder.HasOne(x => x.Paciente);
            builder.HasOne(x => x.Medico);
            builder.HasOne(x => x.Laudo);
            builder.HasOne(x => x.Exame);
        }
    }
}
