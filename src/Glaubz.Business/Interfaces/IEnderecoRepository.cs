using Glaubz.Business.Models;
using System;
using System.Threading.Tasks;

namespace Glaubz.Business.Interfaces
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId);
    }
}
