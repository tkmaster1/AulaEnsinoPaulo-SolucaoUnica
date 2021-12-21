using System;

namespace TKMaster.SolucaoUnica.Web.UI.Models
{
    /// <summary>
    ///  1º passso criação das entidades: Artilharia
    ///  - coloquei as colunas dela e vincular ao jogador
    /// </summary>
    public class Artilharia : Entity
    {
        public int CodigoJogador { get; set; }

        public int Ano { get; set; }

        public Int16 CodigoCategoria { get; set; }

        public int NumeroGols { get; set; }

        public int NumeroAssistencia { get; set; }

        public virtual Jogador Jogador { get; set; }
    }
}
