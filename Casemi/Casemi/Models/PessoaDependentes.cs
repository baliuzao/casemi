//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Casemi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PessoaDependentes
    {
        public PessoaDependentes()
        {
            this.OrdensServico = new HashSet<OrdensServico>();
        }
    
        public System.Guid PessoaDependenteID { get; set; }
        public System.Guid PessoaID { get; set; }
        public string Nome { get; set; }
        public Nullable<System.DateTime> DataDeNascimento { get; set; }
        public Nullable<System.Guid> DependenteTipoID { get; set; }
        public Nullable<System.DateTime> AssociadoDesde { get; set; }
        public string Observacao { get; set; }
        public string CodigoAssociado { get; set; }
        public string CodigoAssociadoAntigo { get; set; }
        public bool Ativo { get; set; }
    
        public virtual DependenteTipos DependenteTipos { get; set; }
        public virtual Pessoas Pessoas { get; set; }
        public virtual ICollection<OrdensServico> OrdensServico { get; set; }
    }
}
