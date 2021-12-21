using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TKMaster.SolucaoUnica.Web.UI.Models;

namespace TKMaster.SolucaoUnica.Web.UI.Configurations.EntityConfig
{
    public class CidadeConfiguration : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            builder.ToTable("Cidade");

            builder
                .Property(c => c.Codigo)
                .HasColumnName("Id");

            builder
                .HasKey(c => c.Codigo);

            builder
                .Property(c => c.Nome)
                .IsRequired()
                .HasColumnName("Descricao");
        }
    }
}
