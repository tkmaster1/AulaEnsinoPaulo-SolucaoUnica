using AutoMapper;
using TKMaster.SolucaoUnica.Web.UI.Models;
using TKMaster.SolucaoUnica.Web.UI.ViewModels;

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

            CreateMap<CidadeViewModel, Cidade>().ReverseMap();

            CreateMap<JogadorViewModel, Jogador>()
                .ForMember(dest => dest.CodigoCidade, m => m.MapFrom(a => a.Cidade.Codigo));

            CreateMap<ArtilhariaViewModel, Artilharia>()
                .ForMember(dest => dest.CodigoJogador, m => m.MapFrom(a => a.Jogador.Codigo));
        }
    }
}
