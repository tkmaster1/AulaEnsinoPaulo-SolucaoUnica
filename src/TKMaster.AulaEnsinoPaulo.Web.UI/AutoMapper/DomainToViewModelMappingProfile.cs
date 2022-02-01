using AutoMapper;
using TKMaster.SolucaoUnica.Web.UI.Models;
using TKMaster.SolucaoUnica.Web.UI.ViewModels;
using TKMaster.SolucaoUnica.Web.UI.ViewModels.DTOs;

namespace TKMaster.SolucaoUnica.Web.UI.AutoMapper
{
    /// <summary>
    /// 4.1ª Etapa, criação das classes de mapeamento: DomainToViewModelMappingProfile
    /// </summary>
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Equipe, EquipeViewModel>()
                .ForMember(dest => dest.CodigoCidade, m => m.MapFrom(a => a.Cidade.Codigo));

            CreateMap<Categoria, CategoriaViewModel>().ReverseMap();
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();

            CreateMap<Cidade, CidadeViewModel>().ReverseMap();

            CreateMap<Jogo1, Jogo1DTO>().ReverseMap();
            CreateMap<Jogo1DTO, Jogo1ViewModel>().ReverseMap();

            CreateMap<Jogador, JogadorViewModel>()
                .ForMember(dest => dest.CodigoCidade, m => m.MapFrom(a => a.Cidade.Codigo));

            CreateMap<Artilharia, ArtilhariaViewModel>()
                .ForMember(dest => dest.CodigoJogador, m => m.MapFrom(a => a.Jogador.Codigo));
        }
    }
}
