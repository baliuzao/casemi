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
    
    public partial class PagamentoTipos
    {
        public PagamentoTipos()
        {
            this.ContasPagar = new HashSet<ContasPagar>();
        }
    
        public int TipoPagamentoID { get; set; }
        public string Nome { get; set; }
    
        public virtual ICollection<ContasPagar> ContasPagar { get; set; }
    }
}
