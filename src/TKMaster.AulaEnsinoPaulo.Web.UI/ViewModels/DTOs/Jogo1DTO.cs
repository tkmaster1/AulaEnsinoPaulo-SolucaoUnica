namespace TKMaster.SolucaoUnica.Web.UI.ViewModels.DTOs
{
    public class Jogo1DTO
    {
        public int Codigo { get; set; }

        public decimal GolsaFavor { get; set; }

        public decimal GolsContra { get; set; }

        public int Ano { get; set; }

        public int CodigoCategoria { get; set; }

        public virtual CategoriaDTO Categoria { get; set; }
    }
}
