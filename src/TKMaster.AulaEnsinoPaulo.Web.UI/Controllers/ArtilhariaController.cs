using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TKMaster.SolucaoUnica.Web.UI.Data;
using TKMaster.SolucaoUnica.Web.UI.Models;
using TKMaster.SolucaoUnica.Web.UI.ViewModels;

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

            var retorno = await ListarTodos();
            return View(retorno);
        }

        #endregion

        #region Methods Públicos

        public async Task<List<ArtilhariaViewModel>> ListarTodos()
        {
            var response = await _context.Artilharias
                                         .Include(c => c.Jogador)
                                         .Include(c => c.Categoria).ToListAsync();

            return _mapper.Map<List<ArtilhariaViewModel>>(response ?? new List<Artilharia>());
        }

        public async Task<IActionResult> ListarJogadores()
        {
            var response = await _context.Jogadores.ToListAsync();
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
            var response = await _context.Categorias.ToListAsync();
            var retorno = _mapper.Map<List<CategoriaViewModel>>(response?.OrderBy(x => x.Nome).ToList() ?? new List<Categoria>());
            ViewBag.Categoria = new SelectList(retorno.Select(a => new { a.Codigo, a.Nome }).Distinct(), "Codigo", "Nome");

            return Ok(true);
        }

        public IActionResult ListarAnos()
        {
            var listYears = new Dictionary<int, string>();
            DateTime startYear = DateTime.Now.AddYears(-20);
            while (startYear.Year <= DateTime.Now.AddYears(10).Year)
            {
                listYears.Add(startYear.Year, startYear.Year.ToString());
                startYear = startYear.AddYears(1);
            }
            ViewBag.Years = new SelectList(listYears, "Key", "Value");

            return Ok(true);
        }

        //[HttpPost]
        //public async Task<IActionResult> PesquisarArtilharia([FromBody] RequestFiltroArtilharia filtro)
        //{

        //}

        #endregion
    }
}
