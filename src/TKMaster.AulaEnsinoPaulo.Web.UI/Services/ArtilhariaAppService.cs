using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TKMaster.SolucaoUnica.Web.UI.Data;
using TKMaster.SolucaoUnica.Web.UI.Models;
using TKMaster.SolucaoUnica.Web.UI.ViewModels.Request;

namespace TKMaster.SolucaoUnica.Web.UI.Services
{
    public class ArtilhariaAppService
    {
        #region Properties

        private readonly ApplicationDbContext _context;

        #endregion

        #region Constructor

        public ArtilhariaAppService(ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<Artilharia>> PesquisarComFiltro(RequestFiltroArtilharia request)
        {
            var query = await _context.Artilharias
                                      .Include(j => j.Jogador)
                                      .Include(c => c.Categoria)
                                      .ToListAsync();

            if (request.CodigoJogador > 0)
            {
                query = query.Where(x => x.CodigoJogador == request.CodigoJogador).ToList();
            }

            if (request.CodigoCategoria > 0)
            {
                query = query.Where(x => x.CodigoCategoria == request.CodigoCategoria).ToList();
            }

            if (request.Ano > 0)
            {
                query = query.Where(x => x.Ano == request.Ano).ToList();
            }

            return query;
        }

        #endregion
    }
}
