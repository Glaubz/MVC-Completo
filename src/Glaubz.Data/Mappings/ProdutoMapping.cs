using System;
using Glaubz.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Glaubz.Data.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(produto => produto.Id);
            
            builder.Property(produto => produto.Nome)
                .HasColumnType("VARCHAR(100)")
                .IsRequired();
            
            builder.Property(produto => produto.Descricao)
                .HasColumnType("VARCHAR(150)")
                .IsRequired();
            
            builder.Property(produto => produto.Imagem)
                .HasColumnType("VARCHAR(100)")
                .IsRequired();
        }
    }
}
