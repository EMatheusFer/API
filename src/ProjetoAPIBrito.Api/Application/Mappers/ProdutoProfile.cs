using AutoMapper;
using ProjetoAPIBrito.Api.Application.DTOs.Produto;
using ProjetoAPIBrito.Api.Domain.Models;

namespace ProjetoAPIBrito.Api.Application.Mappers
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {

            CreateMap<ProdutoInserirRequestDTO, Produto>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.DataInativacao, opt => opt.Ignore());


            CreateMap<Produto, ProdutoResponseDTO>();

            CreateMap<ProdutoAtualizarRequestDTO, Produto>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Ativo, opt => opt.Ignore())
                .ForMember(dest => dest.DataInativacao, opt => opt.Ignore());
        }
    }
}