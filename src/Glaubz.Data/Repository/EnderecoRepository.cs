using Glaubz.Business.Interfaces.Repository;
using Glaubz.Business.Models;
using Glaubz.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Glaubz.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(MVC_CompletoContext context) : base(context)
        {

        }

        public async Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId)
        {
            return await Db.Enderecos.AsNoTracking()
                                     .FirstOrDefaultAsync(endereco => endereco.FornecedorId == fornecedorId);
        }
    }
}
