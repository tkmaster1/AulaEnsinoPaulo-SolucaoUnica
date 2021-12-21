namespace TKMaster.SolucaoUnica.Web.UI.Models
{
    public class Equipe : Entity
    {
        public int CodigoCidade { get; set; }

        public virtual Cidade Cidade { get; set; }
    }
}
