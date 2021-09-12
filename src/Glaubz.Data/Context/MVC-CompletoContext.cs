using System;
using Microsoft.EntityFrameworkCore;
using Glaubz.Business.Models;

namespace Glaubz.Data.Context
{
    public class MVC_CompletoContext : DbContext
    {
        public MVC_CompletoContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
    }
}
