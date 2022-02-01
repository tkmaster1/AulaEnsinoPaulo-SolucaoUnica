using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TKMaster.SolucaoUnica.Web.UI.Data;
using TKMaster.SolucaoUnica.Web.UI.Models;
using TKMaster.SolucaoUnica.Web.UI.Services;
using TKMaster.SolucaoUnica.Web.UI.ViewModels;
using TKMaster.SolucaoUnica.Web.UI.ViewModels.DTOs;
using TKMaster.SolucaoUnica.Web.UI.ViewModels.Request;

namespace TKMaster.SolucaoUnica.Web.UI.Controllers
{
    public class JogoController : Controller
    {
        #region Properties

        public readonly ApplicationDbContext _context;
        public readonly IMapper _mapper;

        #endregion

        #region Constructor

        public JogoController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #endregion

        #region Views

        public async Task<IActionResult> Index()
        {
            await ListarCategoria();
            return View();
        }

        #endregion

        #region Methods

        public async Task<IActionResult> ListarCategoria()
        {
            var categoriaAppService = new CategoriaAppService(_context);

            var response = await categoriaAppService.ListarTodos();
            var retorno = _mapper.Map<List<CategoriaViewModel>>(response?.OrderBy(x => x.Nome).ToList() ?? new List<Categoria>());

            ViewBag.Categoria = new SelectList(retorno.Select(x => new { x.Codigo, x.Nome }).Distinct(), "Codigo", "Nome");

            return Ok(true);
        }

        public JsonResult FiltroJogos(RequestFiltroJogos filtroJogos)
        {
            var jogosService = new JogoAppService(_context);

            var retorno = jogosService.FiltroJogos(filtroJogos);

            var response = _mapper.Map<List<Jogo1ViewModel>>(retorno ?? new List<Jogo1DTO>());

            return Json(response);
        }

        #endregion
    }
}
