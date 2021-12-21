using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TKMaster.SolucaoUnica.Web.UI.Data;
using TKMaster.SolucaoUnica.Web.UI.Models;
using TKMaster.SolucaoUnica.Web.UI.ViewModels;

namespace TKMaster.SolucaoUnica.Web.UI.Controllers
{
    /// <summary>
    /// 5º passo, criação das controllers
    /// </summary>
    public class ArtilhariaController : Controller
    {
        #region Properties

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        public ArtilhariaController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #endregion

        #region Views

        public async Task<IActionResult> Index()
        {
            var retorno = await ListarTodos();
            return View(retorno);
        }

        #endregion

        #region Methods Públicos

        public async Task<List<ArtilhariaViewModel>> ListarTodos()
        {
            var response = await _context.Artilharias.Include(c => c.Jogador).ToListAsync();
            return _mapper.Map<List<ArtilhariaViewModel>>(response ?? new List<Artilharia>());
        }

        #endregion
    }
}
