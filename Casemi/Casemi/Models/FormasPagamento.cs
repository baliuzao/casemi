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
    
    public partial class FormasPagamento
    {
        public FormasPagamento()
        {
            this.FormasPagamentoParcelas = new HashSet<FormasPagamentoParcelas>();
        }
    
        public int FormaPagamentoID { get; set; }
        public string Nome { get; set; }
    
        public virtual ICollection<FormasPagamentoParcelas> FormasPagamentoParcelas { get; set; }
    }
}