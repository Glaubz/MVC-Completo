using Glaubz.Business.Interfaces;
using Glaubz.Business.Models;
using Glaubz.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Glaubz.Data.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(MVC_CompletoContext context) : base(context)
        {

        }

        public async Task<Fornecedor> ObterFornecedorEndereco(Guid id)
        {
            return await Db.Fornecedores.AsNoTracking()
                                        .Include(fornecedor=>fornecedor.Endereco)
                                        .FirstOrDefaultAsync(fornecedor => fornecedor.Id == id);
        }

        public async Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id)
        {
            return await Db.Fornecedores.AsNoTracking()
                                        .Include(fornecedor=>fornecedor.Produtos)
                                        .Include(fornecedor => fornecedor.Endereco)
                                        .FirstOrDefaultAsync(fornecedor => fornecedor.Id == id);
        }
    }
}
