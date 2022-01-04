using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TKMaster.SolucaoUnica.Web.UI.Models;

namespace TKMaster.SolucaoUnica.Web.UI.Configurations.EntityConfig
{
    /// <summary>
    /// 2ª Etapa: Configurar a entidade criada
    /// </summary>
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("categoria");

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
