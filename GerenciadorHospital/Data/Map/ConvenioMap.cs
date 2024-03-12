using GerenciadorHospital.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciadorHospital.Data.Map
{
    public class ConvenioMap : IEntityTypeConfiguration<ConvenioModel>
    {
        public void Configure(EntityTypeBuilder<ConvenioModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Preco).IsRequired().HasMaxLength(45);
        }
    }
}
