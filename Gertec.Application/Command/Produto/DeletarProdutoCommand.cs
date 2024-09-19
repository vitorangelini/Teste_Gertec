using Gertec.Application.Interfaces.Services;
using Gertec.Application.ViewModels.Requests.Produto;
using Gertec.Application.ViewModels.Responses.Produto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gertec.Application.Command.Cliente
{
    public class DeletarProdutoCommand : IRequestHandler<DeletarProdutoRequest, DeletarProdutoResponse>
    {
        #region Properties 
        private readonly IProdutoService _produtoService;
        #endregion

        #region Constructor
        public DeletarProdutoCommand(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }
        #endregion

        #region IRequestHandler Implementation
        public async Task<DeletarProdutoResponse> Handle(DeletarProdutoRequest request, CancellationToken cancellationToken)
        {
            var response = new DeletarProdutoResponse();
            var result  = await _produtoService.DeletarProduto(request.IdProduto);

            response.Status = result;
            return await Task.FromResult(response);
        }

        #endregion
    }
}
