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
    
    public partial class PessoaFisica
    {
        public System.Guid PessoaID { get; set; }
        public string CPF { get; set; }
        public string Sexo { get; set; }
        public Nullable<System.DateTime> DataDeNascimento { get; set; }
        public string Naturalidade { get; set; }
        public string NomeDoPai { get; set; }
        public string NomeDaMae { get; set; }
    
        public virtual Pessoas Pessoas { get; set; }
    }
}