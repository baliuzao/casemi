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
    
    public partial class PessoaAssociado
    {
        public System.Guid PessoaID { get; set; }
        public string Matricula { get; set; }
        public string CodigoAssociado { get; set; }
        public string CodigoAssociadoAntigo { get; set; }
        public Nullable<System.Guid> DepartamentoID { get; set; }
        public string Profissao { get; set; }
        public Nullable<decimal> RendaMensal { get; set; }
        public Nullable<decimal> LimiteDeCredito { get; set; }
        public Nullable<System.DateTime> AssociadoDesde { get; set; }
        public bool AssociadoAmiseg { get; set; }
        public Nullable<System.DateTime> AssociadoAmisegDesde { get; set; }
        public bool Aposentado { get; set; }
        public bool Afastado { get; set; }
    
        public virtual Departamentos Departamentos { get; set; }
        public virtual Pessoas Pessoas { get; set; }
    }
}
