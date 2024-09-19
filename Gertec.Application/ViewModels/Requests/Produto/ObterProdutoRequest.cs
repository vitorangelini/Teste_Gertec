using Gertec.Application.ViewModels.Responses.Produto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gertec.Application.ViewModels.Requests.Produto
{
    public class ObterProdutoRequest : IRequest<ProdutoResponse>
    {
        /// <summary>
        /// PartNumber do Produto.
        /// </summary>
        public string PartNumber { get; set; }
    }
}
