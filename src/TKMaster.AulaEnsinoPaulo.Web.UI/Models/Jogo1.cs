using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TKMaster.SolucaoUnica.Web.UI.Models
{
    public class Jogo1 : Entity
    {
        public DateTime DataJogo { get; set; }

        public int CodigoCategoria { get; set; }

        public int GolsaFavor { get; set; }

        public int GolsContra { get; set; }

        public virtual Categoria Categoria { get; set; }

        [NotMapped]
        public int Ano
        {
            get
            {
                return DataJogo.Year;
            }
        }
    }
}
