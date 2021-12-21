using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TKMaster.SolucaoUnica.Web.UI.Models;

namespace TKMaster.SolucaoUnica.Web.UI.Configurations.EntityConfig
{
    public class EquipeConfiguration : IEntityTypeConfiguration<Equipe>
    {
        public void Configure(EntityTypeBuilder<Equipe> builder)
        {
            builder.ToTable("Equipe");

            builder
                .Property(c => c.Codigo)
                .HasColumnName("Id");

            builder
                .HasKey(c => c.Codigo);

            builder
                .Property(c => c.Nome)
                .IsRequired()
                .HasColumnName("Descricao");

            builder
               .Property(p => p.CodigoCidade)
               .HasColumnName("IdCidade");

            builder
               .HasOne(c => c.Cidade)
               .WithMany(e=> e.Equipes)
               .HasForeignKey(p => p.CodigoCidade);
        }
    }
}
