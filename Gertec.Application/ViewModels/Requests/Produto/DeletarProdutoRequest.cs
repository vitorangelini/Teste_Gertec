using Gertec.Application.ViewModels.Responses.Produto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gertec.Application.ViewModels.Requests.Produto
{
    public class DeletarProdutoRequest : IRequest<DeletarProdutoResponse>
    {
        /// <summary>
        /// Id do Produto.
        /// </summary>
        public long IdProduto { get; set; }
    }
}
