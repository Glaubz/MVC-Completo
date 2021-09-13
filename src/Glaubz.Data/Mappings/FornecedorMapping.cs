using Glaubz.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Glaubz.Data.Mappings
{
    public class FornecedorMapping : EnderecoMapping, IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.HasKey(fornecedor => fornecedor.Id);

            builder.Property(fornecedor => fornecedor.Nome)
                .HasColumnType("VARCHAR(120)")
                .IsRequired();

            builder.Property(fornecedor => fornecedor.Documento)
                .HasColumnType("VARCHAR(14)")
                .IsRequired(); ;

            builder.HasOne(fornecedor => fornecedor.Endereco)
                .WithOne(endereco => endereco.Fornecedor);

            builder.HasMany(fornecedor => fornecedor.Produtos)
                .WithOne(produto => produto.Fornecedor)
                .HasForeignKey(produto=>produto.FornecedorId);

            builder.ToTable("Fornecedores");
        }
    }
}
