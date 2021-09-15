using AutoMapper;
using Glaubz.App.ViewModels;
using Glaubz.Business.Models;

namespace Glaubz.App.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            //O CreateMap faz com que o item à esquerda(origem) seja transformado no item à direita (destino). O Reverse Map faz com que o processo seja realizado inversamente também.
            //O CreateMap é um mapeamento mais simples, em caso de algum objeto conter parametrização é preciso um mapeamento mais complexo.
            CreateMap<Produto, ProdutoViewModel>().ReverseMap(); 
            CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
        }
    }
}
