﻿using GerenciadorHospital.Models;
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
            builder.Property(x => x.PacienteId);
            builder.HasOne(x => x.Paciente);
        }
    }
}
