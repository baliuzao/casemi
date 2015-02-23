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
    
    public partial class OrdensServico
    {
        public System.Guid OrdemServicoID { get; set; }
        public string Codigo { get; set; }
        public Nullable<System.DateTime> AberturaDataHora { get; set; }
        public Nullable<System.Guid> AberturaUsuarioID { get; set; }
        public Nullable<System.DateTime> FechamentoDataHora { get; set; }
        public Nullable<System.Guid> FechamentoUsuarioID { get; set; }
        public Nullable<System.Guid> FornecedorID { get; set; }
        public Nullable<System.Guid> AssociadoID { get; set; }
        public Nullable<System.Guid> ServicoID { get; set; }
        public Nullable<decimal> Valor { get; set; }
        public string Observacao { get; set; }
        public Nullable<bool> Encerrada { get; set; }
    
        public virtual Pessoas Pessoas { get; set; }
        public virtual Pessoas Pessoas1 { get; set; }
        public virtual Servicos Servicos { get; set; }
    }
}