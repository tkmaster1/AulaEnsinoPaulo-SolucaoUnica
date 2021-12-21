using System.Collections.Generic;

namespace TKMaster.SolucaoUnica.Web.UI.Models
{
    public class Cidade : Entity
    {
        public virtual List<Equipe> Equipes { get; set; }

        public virtual List<Jogador> Jogadores { get; set; }
    }
}
