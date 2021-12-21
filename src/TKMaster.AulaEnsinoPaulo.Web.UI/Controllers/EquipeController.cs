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
    public class EquipeController : Controller
    {
        #region Properties

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        public EquipeController(ApplicationDbContext context, IMapper mapper)
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

        public async Task<List<EquipeViewModel>> ListarTodos()
        {
            var response = await _context.Equipes.Include(c => c.Cidade).ToListAsync();
            return _mapper.Map<List<EquipeViewModel>>(response ?? new List<Equipe>());
        }

        #endregion
    }
}
