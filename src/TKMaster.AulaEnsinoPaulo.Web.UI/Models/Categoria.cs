using System.Collections.Generic;

namespace TKMaster.SolucaoUnica.Web.UI.Models
{
    /// <summary>
    /// 1ª Etapa: Criação da Entidade (representação da tabela no banco de dados)
    /// </summary>
    public class Categoria : Entity
    {
        public virtual List<Artilharia> Artilharias { get; set; }

        public virtual List<Jogo1> Jogos { get; set; }
    }
}
