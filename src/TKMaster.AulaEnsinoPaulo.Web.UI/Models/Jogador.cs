using System;
using System.Collections.Generic;

namespace TKMaster.SolucaoUnica.Web.UI.Models
{
    /// <summary>
    /// 1º passso criação das entidades: Jogador
    /// </summary>
    public class Jogador : Entity
    {
        public string Apelido { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Telefone1 { get; set; }

        public string Telefone2 { get; set; }

        public string Email { get; set; }

        public string Foto { get; set; }

        public DateTime? DataFalecimento { get; set; }

        public int CodigoCidade { get; set; }

        public virtual Cidade Cidade { get; set; }

        public virtual List<Artilharia> Artilharias { get; set; }

    }
}
