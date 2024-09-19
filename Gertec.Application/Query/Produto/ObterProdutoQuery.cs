using Gertec.Application.Interfaces.Services;
using Gertec.Application.ViewModels.Requests.Cliente;
using Gertec.Application.ViewModels.Requests.Produto;
using Gertec.Application.ViewModels.Responses.Cliente;
using Gertec.Application.ViewModels.Responses.Produto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gertec.Application.Query.Produto
{
    public class ObterProdutoQuery : IRequestHandler<ObterProdutoRequest, ProdutoResponse>
    {
        #region Properties 
        private readonly IProdutoService _produtoService;
        #endregion

        #region Constructor
        public ObterProdutoQuery(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }
        #endregion

        #region IRequestHandler Implementation

        public async Task<ProdutoResponse> Handle(ObterProdutoRequest request, CancellationToken cancellationToken)
        {
            var obterProdutoResponse = new ProdutoResponse();

            var response = await _produtoService.ObterProduto(request.PartNumber);

            obterProdutoResponse = response;

            return await Task.FromResult(obterProdutoResponse);
        }

        #endregion
    }
}
