﻿using GerenciadorHospital.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciadorHospital.Data.Map
{
    public class PacienteMap : IEntityTypeConfiguration<PacienteModel>
    {
        public void Configure(EntityTypeBuilder<PacienteModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Cpf).IsRequired();
            builder.Property(x => x.Endereco).IsRequired().HasMaxLength(255);
            builder.Property(x => x.DataNasc).IsRequired();
            builder.Property(x => x.TemConvenio).IsRequired();
            builder.Property(x => x.ImgCarteiraDoConvenio).IsRequired();
            builder.Property(x => x.ImgDocumento).IsRequired();
            builder.Property(x => x.MedicamentoId);
            builder.HasOne(x => x.Medicamento);
            builder.Property(x => x.ConvenioId);
            builder.HasOne(x => x.Convenio);

        }
    }
}
