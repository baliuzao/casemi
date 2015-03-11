using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Casemi.Models
{
    [MetadataType(typeof(PessoasMetadata))]
    public partial class Pessoas
    {
    }

    [MetadataType(typeof(PessoaAssociadoMetadata))]
    public partial class PessoaAssociado
    {
    }

    [MetadataType(typeof(PessoaFisicaMetadata))]
    public partial class PessoaFisica
    {
    }

    [MetadataType(typeof(PessoaJuridicaMetadata))]
    public partial class PessoaJuridica
    {
    }

    [MetadataType(typeof(PessoaDependentesMetadata))]
    public partial class PessoaDependentes
    {
    }

    [MetadataType(typeof(ProdutosMetadata))]
    public partial class Produtos
    {
    }

    [MetadataType(typeof(ServicosMetadata))]
    public partial class Servicos
    {
    }

    [MetadataType(typeof(OrdensServicoMetadata))]
    public partial class OrdensServico
    {
    }


}