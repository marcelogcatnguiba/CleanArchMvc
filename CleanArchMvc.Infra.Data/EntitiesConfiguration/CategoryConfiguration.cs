using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchMvc.Infra.Data.EntitiesConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(t => t.Id).HasName("PK_Category");

            builder.Property(p => p.Name).HasMaxLength(50).IsRequired();

            //Verifica o HasData e inseri ao criar o banco se não existir
            builder.HasData(
                new Category(1, "Material Escolar"),
                new Category(2, "Eletronicos"),
                new Category(3, "Acessorios")
                );
        }
    }
}
