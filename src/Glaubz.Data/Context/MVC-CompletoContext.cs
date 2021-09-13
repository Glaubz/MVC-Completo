using Microsoft.EntityFrameworkCore;
using Glaubz.Business.Models;
using System.Linq;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //linha para que seja identificado todo mapeamento do MVC_CompletoContext
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MVC_CompletoContext).Assembly);

            //linha para que tire a deleção em Cascata
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
    }
}
