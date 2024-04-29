using GerenciadorHospital.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciadorHospital.Data.Map
{
    public class LaudoMap : IEntityTypeConfiguration<LaudoModel>
    {
        public void Configure(EntityTypeBuilder<LaudoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(255);
            builder.Property(x => x.DataCriacao);
            builder.Property(x => x.CaminhoImagemLaudo);
            builder.Property(x => x.PacienteId);
            builder.Property(x => x.MedicoId);
            builder.Property(x => x.MedicamentoId);
            builder.Property(x => x.RegistroConsultaModelId);
            builder.HasOne(x => x.Paciente);
            builder.HasOne(x => x.Medico);
            builder.HasOne(x => x.Medicamento);
        }
    }
}
