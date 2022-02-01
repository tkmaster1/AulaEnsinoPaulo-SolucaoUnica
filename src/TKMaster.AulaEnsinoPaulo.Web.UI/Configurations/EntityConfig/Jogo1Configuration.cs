using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TKMaster.SolucaoUnica.Web.UI.Models;

namespace TKMaster.SolucaoUnica.Web.UI.Configurations.EntityConfig
{
    public class Jogo1Configuration : IEntityTypeConfiguration<Jogo1>
    {
        public void Configure(EntityTypeBuilder<Jogo1> builder)
        {
            builder.ToTable("jogo1");

            builder
                .Property(c => c.Codigo)
                .HasColumnName("Id");

            builder
                .HasKey(c => c.Codigo);

            builder
                .Property(c => c.DataJogo)
                .IsRequired()
                .HasColumnName("DataJogo");

            builder
                .Property(c => c.GolsaFavor)
                .IsRequired()
                .HasColumnName("GolsaFavor");

            builder
                .Property(c => c.GolsContra)
                .IsRequired()
                .HasColumnName("GolsContra");

            builder
                .Property(c => c.CodigoCategoria)
                .HasColumnName("IdCategoria");

            builder
                .Ignore(p => p.Nome);

            builder
                .HasOne(c => c.Categoria)
                .WithMany(j => j.Jogos)
                .HasForeignKey(c => c.CodigoCategoria);
        }
    }
}
