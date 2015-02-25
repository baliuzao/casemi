using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Casemi.Models
{
    public class OrdemServicoEdit
    {
        public System.Guid OrdemServicoID { get; set; }
        public string Codigo { get; set; }
        public Nullable<System.DateTime> AberturaDataHora { get; set; }
        public Nullable<System.Guid> AberturaUsuarioID { get; set; }
        public Nullable<System.DateTime> FechamentoDataHora { get; set; }
        public Nullable<System.Guid> FechamentoUsuarioID { get; set; }

        [Required]
        [Display(Name = "Fornecedor")]
        public Nullable<System.Guid> FornecedorID { get; set; }
        public string FornecedorNome { get; set; }

        [Required]
        [Display(Name = "Associado")]
        public Nullable<System.Guid> AssociadoID { get; set; }


        public string AssociadoNome { get; set; }

        [Required]
        [Display(Name = "Serviço")]
        public Nullable<System.Guid> ServicoID { get; set; }
        public string ServicoNome { get; set; }

        [Required]
        [Display(Name = "Valor")]
        [DataType(DataType.Currency)]
        public Nullable<decimal> Valor { get; set; }

        [Display(Name = "Observação")]
        [DataType(DataType.MultilineText)]
        public string Observacao { get; set; }

        [Display(Name = "Encerrada")]
        public Nullable<bool> Encerrada { get; set; }

        public virtual Pessoas Pessoas { get; set; }
        public virtual Pessoas Pessoas1 { get; set; }
        public virtual Servicos Servicos { get; set; }
    }
}