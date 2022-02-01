using System.Collections.Generic;
using System.Linq;
using TKMaster.SolucaoUnica.Web.UI.Data;
using TKMaster.SolucaoUnica.Web.UI.ViewModels.DTOs;
using TKMaster.SolucaoUnica.Web.UI.ViewModels.Request;

namespace TKMaster.SolucaoUnica.Web.UI.Services
{
    public class JogoAppService
    {
        #region Properties

        private readonly ApplicationDbContext _context;

        #endregion

        #region Constructor

        public JogoAppService(ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Methdos

        public IEnumerable<Jogo1DTO> FiltroJogos(RequestFiltroJogos requestFiltro)
        {
            var query = _context.Jogos.AsEnumerable()
                                      .GroupBy(x => new { x.DataJogo, x.Codigo, x.CodigoCategoria, x.GolsaFavor, x.GolsContra })
                                      .Select(g =>
                                       new Jogo1DTO
                                       {
                                           Codigo = g.Key.Codigo,
                                           CodigoCategoria = g.FirstOrDefault(x => x.CodigoCategoria > 0).CodigoCategoria,
                                           GolsaFavor = g.Sum(s => s.GolsaFavor),
                                           GolsContra = g.Sum(s => s.GolsContra),
                                           Ano = g.Key.DataJogo.Year
                                       }).OrderBy(x => x.Ano)
                                       .ToList();

            if (requestFiltro.CodigoCategoria > 0)
                query = query.Where(x => x.CodigoCategoria == requestFiltro.CodigoCategoria).ToList();

            return query;
        }

        #endregion
    }
}
