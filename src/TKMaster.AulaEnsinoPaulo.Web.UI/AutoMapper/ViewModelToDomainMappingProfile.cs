using AutoMapper;
using TKMaster.SolucaoUnica.Web.UI.Models;
using TKMaster.SolucaoUnica.Web.UI.ViewModels;
using TKMaster.SolucaoUnica.Web.UI.ViewModels.DTOs;

namespace TKMaster.SolucaoUnica.Web.UI.AutoMapper
{
    /// <summary>
    /// 4.2ª Etapa, criação das classes de mapeamento: ViewModelToDomainMappingProfile
    /// </summary>
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<EquipeViewModel, Equipe>()
                .ForMember(dest => dest.CodigoCidade, m => m.MapFrom(a => a.Cidade.Codigo));

            CreateMap<CategoriaViewModel, Categoria>().ReverseMap();
            CreateMap<CategoriaDTO, Categoria>().ReverseMap();

            CreateMap<CidadeViewModel, Cidade>().ReverseMap();

            CreateMap<Jogo1DTO, Jogo1>().ReverseMap();
            CreateMap<Jogo1ViewModel, Jogo1DTO>().ReverseMap();

            CreateMap<JogadorViewModel, Jogador>()
                .ForMember(dest => dest.CodigoCidade, m => m.MapFrom(a => a.Cidade.Codigo));

            CreateMap<ArtilhariaViewModel, Artilharia>()
                .ForMember(dest => dest.CodigoJogador, m => m.MapFrom(a => a.Jogador.Codigo));
        }
    }
}
