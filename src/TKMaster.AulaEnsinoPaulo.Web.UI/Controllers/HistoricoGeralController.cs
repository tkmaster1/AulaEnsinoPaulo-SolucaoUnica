using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TKMaster.SolucaoUnica.Web.UI.Controllers
{
    public class HistoricoGeralController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
