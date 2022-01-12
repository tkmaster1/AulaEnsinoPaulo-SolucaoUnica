using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TKMaster.SolucaoUnica.Web.UI.Data;
using TKMaster.SolucaoUnica.Web.UI.Models;
using TKMaster.SolucaoUnica.Web.UI.Services;
using TKMaster.SolucaoUnica.Web.UI.ViewModels;
using TKMaster.SolucaoUnica.Web.UI.ViewModels.Request;

namespace TKMaster.SolucaoUnica.Web.UI.Controllers
{
    /// <summary>
    /// 5ª Etapa, criação das controllers
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

        /// <summary>
        /// Mostra as consultas na view (Tela)
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            await ListarJogadores();
            await ListarCategorias();
            ListarAnos();

            return View();
        }

        #endregion

        #region Methods Públicos

        public async Task<IActionResult> ListarJogadores()
        {
            var jogadorAppService = new JogadorAppService(_context);

            var response = await jogadorAppService.ListarTodos();
            var retorno = _mapper.Map<List<JogadorViewModel>>(response?.OrderBy(x => x.Nome).ToList() ?? new List<Jogador>());
            ViewBag.Jogador = new SelectList(retorno.Select(a => new { a.Codigo, a.Nome }).Distinct(), "Codigo", "Nome");

            return Ok(true);
        }

        /// <summary>
        /// Criar a chamada das consultas no banco para mostrar na tela
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> ListarCategorias()
        {
            var categoriaAppService = new CategoriaAppService(_context);
            var response = await categoriaAppService.ListarTodos();
            var retorno = _mapper.Map<List<CategoriaViewModel>>(response?.OrderBy(x => x.Nome).ToList() ?? new List<Categoria>());
            ViewBag.Categoria = new SelectList(retorno.Select(a => new { a.Codigo, a.Nome }).Distinct(), "Codigo", "Nome");

            return Ok(true);
        }

        public IActionResult ListarAnos()
        {
            var listYears = new Dictionary<int, string>();
            DateTime startYear = DateTime.Now.AddYears(-22);
            while (startYear.Year <= DateTime.Now.AddYears(10).Year)
            {
                listYears.Add(startYear.Year, startYear.Year.ToString());
                startYear = startYear.AddYears(1);
            }
            ViewBag.Years = new SelectList(listYears, "Key", "Value");

            return Ok(true);
        }

        [HttpPost]
        public async Task<IActionResult> PesquisarArtilharia([FromBody] RequestFiltroArtilharia filtro)
        {
            var artilhariaAppService = new ArtilhariaAppService(_context);

            var retorno = await artilhariaAppService.PesquisarComFiltro(filtro);

            var response = _mapper.Map<List<ArtilhariaViewModel>>(retorno ?? new List<Artilharia>());

            return PartialView("_Lista", response);
        }

        #endregion
    }
}
