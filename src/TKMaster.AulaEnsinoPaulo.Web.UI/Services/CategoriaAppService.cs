using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TKMaster.SolucaoUnica.Web.UI.Data;
using TKMaster.SolucaoUnica.Web.UI.Models;

namespace TKMaster.SolucaoUnica.Web.UI.Services
{
    public class CategoriaAppService
    {
        #region Properties

        private readonly ApplicationDbContext _context;

        #endregion

        #region Constructor

        public CategoriaAppService(ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<Categoria>> ListarTodos()
        {
            return await _context.Categorias.ToListAsync();
        }

        #endregion
    }
}
