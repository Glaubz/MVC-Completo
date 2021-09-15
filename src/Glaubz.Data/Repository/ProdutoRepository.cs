using Glaubz.Business.Interfaces;
using Glaubz.Business.Models;
using Glaubz.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Glaubz.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(MVC_CompletoContext context) : base(context) { }

        public async Task<Produto> ObterProdutoFornecedor(Guid id)
        {
            return await Db.Produtos.AsNoTracking()
                              .Include(produto => produto.Fornecedor)
                              .FirstOrDefaultAsync(produto=>produto.Id == id);
        }

        public async Task<IEnumerable<Produto>> ObterProdutosFornecedores()
        {
            return await Db.Produtos.AsNoTracking()
                                    .Include(produto => produto.Fornecedor)
                                    .OrderBy(produto => produto.Nome)
                                    .ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId)
        {
            return await Buscar(produto => produto.FornecedorId == fornecedorId);
        }
    }
}
