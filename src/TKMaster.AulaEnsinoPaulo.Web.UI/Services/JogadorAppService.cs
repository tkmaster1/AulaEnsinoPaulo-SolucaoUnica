using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TKMaster.SolucaoUnica.Web.UI.Data;
using TKMaster.SolucaoUnica.Web.UI.Models;

namespace TKMaster.SolucaoUnica.Web.UI.Services
{
    public class JogadorAppService
    {
        #region Properties

        private readonly ApplicationDbContext _context;

        #endregion

        #region Constructor

        public JogadorAppService(ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<Jogador>> ListarTodos()
        {
            return await _context.Jogadores.ToListAsync();
        }

        #endregion
    }
}
