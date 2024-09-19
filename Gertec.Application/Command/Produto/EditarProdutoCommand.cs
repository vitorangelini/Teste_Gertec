using AutoMapper;
using Gertec.Application.Interfaces.Services;
using Gertec.Application.ViewModels.Requests.Cliente;
using Gertec.Application.ViewModels.Requests.Produto;
using Gertec.Application.ViewModels.Responses.Cliente;
using Gertec.Application.ViewModels.Responses.Produto;
using Gertec.Domain.Entites.Cliente;
using Gertec.Domain.Entites.Produto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gertec.Application.Command.Cliente
{
    public class EditarProdutoCommand : IRequestHandler<EditarProdutoRequest, ProdutoResponse>
    {
        #region Properties 
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public EditarProdutoCommand(IProdutoService produtoService, IMapper mapper)
        {
            _produtoService = produtoService;
            _mapper = mapper;
        }
        #endregion

        #region IRequestHandler Implementation
        public async Task<ProdutoResponse> Handle(EditarProdutoRequest request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<EditarProdutoRequest, EditarProdutoEntity>(request);

            var response = await _produtoService.EditarProduto(entity);

            return await Task.FromResult(response);
        }

        #endregion
    }
}
