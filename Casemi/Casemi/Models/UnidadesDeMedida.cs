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
    
    public partial class UnidadesDeMedida
    {
        public UnidadesDeMedida()
        {
            this.Produtos = new HashSet<Produtos>();
            this.Produtos1 = new HashSet<Produtos>();
        }
    
        public System.Guid UnidadeDeMedidaID { get; set; }
        public string Nome { get; set; }
    
        public virtual ICollection<Produtos> Produtos { get; set; }
        public virtual ICollection<Produtos> Produtos1 { get; set; }
    }
}
