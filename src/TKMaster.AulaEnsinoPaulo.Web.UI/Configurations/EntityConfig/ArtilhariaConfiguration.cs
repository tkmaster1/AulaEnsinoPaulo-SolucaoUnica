using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TKMaster.SolucaoUnica.Web.UI.Models;

namespace TKMaster.SolucaoUnica.Web.UI.Configurations.EntityConfig
{
    /// <summary>
    /// 2º passso, criação configurações das entidades: ArtilhariaConfiguration
    /// </summary>
    public class ArtilhariaConfiguration : IEntityTypeConfiguration<Artilharia>
    {
        public void Configure(EntityTypeBuilder<Artilharia> builder)
        {
            builder.ToTable("Artilharia");

            builder
                .Property(c => c.Codigo)
                .HasColumnName("Id");

            builder
                .HasKey(c => c.Codigo);

            builder
                .Property(c => c.Ano)
                .IsRequired()
                .HasColumnName("Ano");

            builder
                .Property(c => c.NumeroGols)
                .IsRequired()
                .HasColumnName("NumeroGols");

            builder
                .Property(c => c.NumeroAssistencia)
                .IsRequired()
                .HasColumnName("NumeroAssistencia");

            builder
                .Property(c => c.CodigoCategoria)
                .IsRequired()
                .HasColumnName("IdCategoria");

            builder
                .Property(p => p.CodigoJogador)
                .IsRequired()
                .HasColumnName("IdJogador");

            builder
                .Ignore(c => c.Nome);

            builder
                .HasOne(c => c.Jogador)
                .WithMany(j => j.Artilharias)
                .HasForeignKey(j => j.CodigoJogador);
        }
    }
}
