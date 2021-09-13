using Glaubz.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Glaubz.Data.Mappings
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {

        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(fornecedor => fornecedor.Id);

            builder.Property(fornecedor => fornecedor.Logradouro)
                .HasColumnType("VARCHAR(200)")
                .IsRequired();

            builder.Property(fornecedor => fornecedor.Numero)
                .HasColumnType("VARCHAR(50)")
                .IsRequired();

            builder.Property(fornecedor => fornecedor.Complemento)
                .HasColumnType("VARCHAR(8)");

            builder.Property(fornecedor => fornecedor.CEP)
                .HasColumnType("VARCHAR(250)")
                .IsRequired();

            builder.Property(fornecedor => fornecedor.Bairro)
                .HasColumnType("VARCHAR(100)")
                .IsRequired();

            builder.Property(fornecedor => fornecedor.Cidade)
                .HasColumnType("VARCHAR(100)")
                .IsRequired();

            builder.Property(fornecedor => fornecedor.Estado)
                .HasColumnType("VARCHAR(50)")
                .IsRequired();

            builder.ToTable("Enderecos");
        }
    }
}