using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TKMaster.SolucaoUnica.Web.UI.Models;

namespace TKMaster.SolucaoUnica.Web.UI.Configurations.EntityConfig
{
    /// <summary>
    /// 2º passso, criação configurações das entidades: JogadorConfiguration
    /// </summary>
    /// <param name="builder"></param>
    public class JogadorConfiguration : IEntityTypeConfiguration<Jogador>
    {       
        public void Configure(EntityTypeBuilder<Jogador> builder)
        {
            builder.ToTable("Jogador");

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
                .Property(c => c.Apelido)
                .IsRequired()
                .HasColumnName("Apelido");

            builder
                .Property(c => c.DataNascimento)
                .IsRequired()
                .HasColumnName("DataNascimento");

            builder
                .Property(c => c.DataFalecimento)
                .HasColumnName("DataFalecimento");

            builder
                .Property(c => c.Foto)
                .HasColumnName("Foto");

            builder
                .Property(c => c.Email)
                .IsRequired()
                .HasColumnName("Email");

            builder
                .Property(c => c.Telefone1)
                .HasColumnName("Telefone1");

            builder
                .Property(c => c.Telefone2)
                .HasColumnName("Telefone2");

            builder
                .Property(p => p.CodigoCidade)
                .HasColumnName("IdCidade");

            builder
                .HasOne(c => c.Cidade)
                .WithMany(j => j.Jogadores)
                .HasForeignKey(j => j.CodigoCidade);
        }
    }
}
