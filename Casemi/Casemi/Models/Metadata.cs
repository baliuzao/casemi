using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Casemi.Models
{


    public partial class PessoasMetadata
    {
        [HiddenInput(DisplayValue = false)]
        public System.Guid PessoaID { get; set; }

        [Required]
        public string Nome { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "e-Mail")]
        public string Email { get; set; }

        [Display(Name = "Observação")]
        [DataType(DataType.MultilineText)]
        public string Observacao { get; set; }

        [Required]
        public bool Ativo { get; set; }

        public string TipoPessoa { get; set; }


        public virtual PessoaAssociado PessoaAssociado { get; set; }
        public virtual ICollection<PessoaContatos> PessoaContatos { get; set; }
        public virtual ICollection<PessoaDependentes> PessoaDependentes { get; set; }
        public virtual ICollection<PessoaDocumentos> PessoaDocumentos { get; set; }
        public virtual ICollection<PessoaEnderecos> PessoaEnderecos { get; set; }
        public virtual PessoaFisica PessoaFisica { get; set; }
        public virtual PessoaJuridica PessoaJuridica { get; set; }
        public virtual ICollection<PessoasPessoaTipos> PessoasPessoaTipos { get; set; }
        public virtual ICollection<PessoaTelefones> PessoaTelefones { get; set; }
    }

    public class PessoaFisicaMetadata
    {
        [HiddenInput(DisplayValue = false)]
        public System.Guid PessoaID { get; set; }

        [Display(Name = "CPF")]
        //[RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "Formato do CPF Inválido. O formato deve ser 000.000.000-00")]
        public string CPF { get; set; }

        [Display(Name = "Sexo")]
        public string Sexo { get; set; }

        [Display(Name = "Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> DataDeNascimento { get; set; }

        [Display(Name = "Naturalidade")]
        public string Naturalidade { get; set; }

        [Display(Name = "Pai")]
        public string NomeDoPai { get; set; }

        [Display(Name = "Mãe")]
        public string NomeDaMae { get; set; }

        public virtual Pessoas Pessoas { get; set; }
    }

    public class PessoaJuridicaMetadata
    {
        [HiddenInput(DisplayValue = false)]
        public System.Guid PessoaID { get; set; }

        [Display(Name = "CNPJ")]
        [RegularExpression(@"^\d{2}.?\d{3}.?\d{3}/?\d{4}-?\d{2}$", ErrorMessage = "Formato do CNPJ Inválido. O formato deve ser 00.000.000/0000-00")]
        public string CNPJ { get; set; }

        [Display(Name = "Inscrição Municipal")]
        public string InscricaoMunicipal { get; set; }

        [Display(Name = "Inscrição Estadual")]
        public string InscricaoEstadual { get; set; }

        public virtual Pessoas Pessoas { get; set; }
    }

    public class PessoaAssociadoMetadata
    {
        [HiddenInput(DisplayValue = false)]
        public System.Guid PessoaID { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Matrícula")]
        public string Matricula { get; set; }

        [Required]
        [Display(Name = "Código")]
        public string CodigoAssociado { get; set; }

        [Display(Name = "Cód. Antigo")]
        public string CodigoAssociadoAntigo { get; set; }

        [Display(Name = "Departamento")]
        public Nullable<System.Guid> DepartamentoID { get; set; }

        [Display(Name = "Profissão")]
        public string Profissao { get; set; }

        [Display(Name = "Renda Mensal")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public Nullable<decimal> RendaMensal { get; set; }

        [Display(Name = "Crédito")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Range(0, 999999)]
        public Nullable<decimal> LimiteDeCredito { get; set; }

        [Display(Name = "Associado Desde")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> AssociadoDesde { get; set; }


        [Display(Name = "Amiseg")]
        public Nullable<bool> AssociadoAmiseg { get; set; }

        [Display(Name = "Amiseg Desde")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> AssociadoAmisegDesde { get; set; }

        [Display(Name = "Aposentado")]
        public Nullable<bool> Aposentado { get; set; }

        [Display(Name = "Afastado")]
        public Nullable<bool> Afastado { get; set; }

        public virtual Pessoas Pessoas { get; set; }
    }

    public class PessoaDependentesMetadata
    {
        [HiddenInput(DisplayValue = false)]
        public System.Guid PessoaDependenteID { get; set; }

        [HiddenInput(DisplayValue = false)]
        public System.Guid PessoaID { get; set; }

        [Required]
        [Display(Name = "Código")]
        public string CodigoAssociado { get; set; }

        [Display(Name = "Cód. Antigo")]
        public string CodigoAssociadoAntigo { get; set; }

        [Display(Name = "Nome")]
        [Required]
        public string Nome { get; set; }

        [Display(Name = "Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public System.DateTime DataDeNascimento { get; set; }

        [Display(Name = "Tipo")]
        [Required]
        public System.Guid DependenteTipoID { get; set; }

        [Display(Name = "Associado Desde")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> AssociadoDesde { get; set; }

        [Display(Name = "Observação")]
        [DataType(DataType.MultilineText)]
        public string Observacao { get; set; }

        [Display(Name = "Ativo")]
        public Nullable<bool> Ativo { get; set; }

        public virtual DependenteTipos DependenteTipos { get; set; }
        public virtual Pessoas Pessoas { get; set; }
    }

    public class ProdutosMetadata
    {
        [Required]
        [HiddenInput]
        public System.Guid ProdutoID { get; set; }

        [Required]
        [Display(Name = "Cód. Barras")]
        [DataType(DataType.Text)]
        public string CodigoDeBarras { get; set; }

        [Required]
        [Display(Name = "Cód. Interno")]
        [DataType(DataType.Text)]
        public string CodigoInterno { get; set; }

        [Required]
        [Display(Name = "Nome")]
        [DataType(DataType.Text)]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Un. Compra")]
        public Nullable<System.Guid> CompraUnidadeDeMedidaID { get; set; }

        [Required]
        [Display(Name = "un. Venda")]
        public Nullable<System.Guid> VendaUnidadeDeMedidaID { get; set; }

        [Required]
        [Display(Name = "Preço de Compra")]
        [DataType(DataType.Currency)]
        public Nullable<decimal> PrecoDeCompra { get; set; }

        [Required]
        [Display(Name = "Preço de Venda")]
        [DataType(DataType.Currency)]
        public Nullable<decimal> PrecoDeVenda { get; set; }

        [Display(Name = "Estocado em")]
        [DataType(DataType.Text)]
        public string EstoqueLocal { get; set; }

        [Required]
        [Display(Name = "Em Mãos")]
        public Nullable<double> EstoqueQuantidadeAtual { get; set; }

        [Required]
        [Display(Name = "Qtd. Mínima")]
        public Nullable<double> EstoqueQuantidadeMinima { get; set; }

        [Required]
        [Display(Name = "Qtd. Máxima")]
        public Nullable<double> EstoqueQuantidadeMaxima { get; set; }

        [Required]
        [Display(Name = "Grupo")]
        public Nullable<System.Guid> ProdutoGrupoID { get; set; }

        public virtual ProdutoGrupos ProdutoGrupos { get; set; }
        public virtual UnidadesDeMedida UnidadesDeMedida { get; set; }
        public virtual UnidadesDeMedida UnidadesDeMedida1 { get; set; }
    }

    public class OrdensServicoMetadata
    {
        [Required]
        public System.Guid OrdemServicoID { get; set; }
        [Required]
        [Display(Name = "Código")]
        [DataType(DataType.Text)]
        public string Codigo { get; set; }
        [Required]
        [Display(Name = "Aberta em")]
        [DataType(DataType.DateTime)]
        public Nullable<System.DateTime> AberturaDataHora { get; set; }
        [Required]
        [Display(Name = "Aberta por")]
        public Nullable<System.Guid> AberturaUsuarioID { get; set; }

        [Display(Name = "Fechada em")]
        [DataType(DataType.DateTime)]
        public Nullable<System.DateTime> FechamentoDataHora { get; set; }
        [Display(Name = "Fechada por")]
        public Nullable<System.Guid> FechamentoUsuarioID { get; set; }
        [Display(Name = "Fornecedor")]
        public Nullable<System.Guid> FornecedorID { get; set; }
        [Required]
        [Display(Name = "Associado")]
        public Nullable<System.Guid> AssociadoID { get; set; }

        [Display(Name = "Dependente")]
        public Nullable<System.Guid> DependenteID { get; set; }


        [Required]
        [Display(Name = "Serviço")]
        public Nullable<System.Guid> ServicoID { get; set; }
        [Display(Name = "Valor")]
        [DataType(DataType.Currency)]
        public Nullable<decimal> Valor { get; set; }
        [DataType(DataType.MultilineText)]
        public string Observacao { get; set; }
        [Required]
        public Nullable<bool> Encerrada { get; set; }

        public virtual Pessoas Pessoas { get; set; }
        public virtual Pessoas Pessoas1 { get; set; }
        public virtual Servicos Servicos { get; set; }
    }


    public class ServicosMetadata
    {
        [HiddenInput(DisplayValue = false)]
        public System.Guid ServicoID { get; set; }

        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "Desconto")]
        [DataType(DataType.Currency)]
        [Range(0, 100)]
        public double DescontoParaAssociados { get; set; }

        public virtual ICollection<OrdensServico> OrdensServico { get; set; }
    }
}