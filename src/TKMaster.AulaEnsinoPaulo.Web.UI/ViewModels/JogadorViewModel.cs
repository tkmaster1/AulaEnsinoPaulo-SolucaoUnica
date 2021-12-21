using System;
using System.Collections.Generic;

namespace TKMaster.SolucaoUnica.Web.UI.ViewModels
{
    public class JogadorViewModel
    {
        public int Codigo { get; set; }

        public string Nome { get; set; }

        public string Apelido { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Telefone1 { get; set; }

        public string Telefone2 { get; set; }

        public string Email { get; set; }

        public string Foto { get; set; }

        public DateTime? DataFalecimento { get; set; }

        public int CodigoCidade { get; set; }

        public virtual CidadeViewModel Cidade { get; set; }

        public virtual List<ArtilhariaViewModel> Artilharias { get; set; }
    }
}
