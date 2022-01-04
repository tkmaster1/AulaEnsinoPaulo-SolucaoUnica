using System.Collections.Generic;

namespace TKMaster.SolucaoUnica.Web.UI.ViewModels
{
    /// <summary>
    /// 4ª Etapa: criar a ViewModel
    /// </summary>
    public class CategoriaViewModel
    {
        public int Codigo { get; set; }

        public string Nome { get; set; }

        public virtual List<ArtilhariaViewModel> Artilharias { get; set; }
    }
}
