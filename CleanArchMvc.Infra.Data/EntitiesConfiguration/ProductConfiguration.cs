﻿using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchMvc.Infra.Data.EntitiesConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id).HasName("PK_Products");

            builder.Property(n => n.Name).HasMaxLength(100).IsRequired();
            builder.Property(d => d.Description).HasMaxLength(200).IsRequired();

            builder.Property(p => p.Price).HasPrecision(10, 2);

            builder.HasOne(c => c.Category).WithMany(p => p.Products).
                HasConstraintName("FK_Category_Products").HasForeignKey(e => e.CategoryId);
        }
    }
}
