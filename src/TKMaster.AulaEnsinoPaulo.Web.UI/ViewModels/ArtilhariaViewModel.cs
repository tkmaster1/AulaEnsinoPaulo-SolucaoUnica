namespace TKMaster.SolucaoUnica.Web.UI.ViewModels
{
    public class ArtilhariaViewModel
    {
        public int Codigo { get; set; }

        public int CodigoJogador { get; set; }

        public int Ano { get; set; }

        public int CodigoCategoria { get; set; }

        public int NumeroGols { get; set; }

        public int NumeroAssistencia { get; set; }

        public virtual CategoriaViewModel Categoria { get; set; }

        public virtual JogadorViewModel Jogador { get; set; }
    }
}
