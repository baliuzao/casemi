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
    
    public partial class PessoasPessoaTipos
    {
        public System.Guid PessoaPessoaTipoID { get; set; }
        public System.Guid PessoaID { get; set; }
        public System.Guid PessoaTipoID { get; set; }
    
        public virtual Pessoas Pessoas { get; set; }
        public virtual PessoaTipos PessoaTipos { get; set; }
    }
}