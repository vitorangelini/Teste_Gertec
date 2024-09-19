using Gertec.Application.ViewModels.Responses.Cliente;
using Gertec.Application.ViewModels.Responses.Produto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gertec.Application.ViewModels.Requests.Produto
{
    public class SalvarProdutoRequest : IRequest<ProdutoResponse>
    {
        /// <summary>
        /// Descrição do Produto.
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// Valor do Produto.
        /// </summary>
        public decimal Valor { get; set; }

        /// <summary>
        /// PartNumber do Produto.
        /// </summary>
        public string PartNumber { get; set; }

        /// <summary>
        /// Quantidade do Produto.
        /// </summary>
        public int Quantidade { get; set; }
    }
}
