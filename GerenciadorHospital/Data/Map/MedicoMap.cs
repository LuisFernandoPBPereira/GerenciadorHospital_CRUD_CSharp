using GerenciadorHospital.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciadorHospital.Data.Map
{
    public class MedicoMap : IEntityTypeConfiguration<MedicoModel>
    {
        public void Configure(EntityTypeBuilder<MedicoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Cpf).IsRequired();
            builder.Property(x => x.Senha).IsRequired();
            builder.Property(x => x.Crm);
        }
    }
}
