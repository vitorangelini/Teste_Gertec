using AutoMapper;
using Gertec.Application.Interfaces.Services;
using Gertec.Application.ViewModels.Requests.Produto;
using Gertec.Application.ViewModels.Responses.Produto;
using Gertec.Domain.Entites.Produto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gertec.Application.Command.Cliente
{
    public class SalvarProdutoCommand : IRequestHandler<SalvarProdutoRequest, ProdutoResponse>
    {
        #region Properties 
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public SalvarProdutoCommand(IProdutoService produtoService, IMapper mapper)
        {
            _produtoService = produtoService;
            _mapper = mapper;
        }
        #endregion

        #region IRequestHandler Implementation
        public async Task<ProdutoResponse> Handle(SalvarProdutoRequest request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<SalvarProdutoRequest, SalvarProdutoEntity>(request);

            var response = await _produtoService.SalvarProduto(entity);

            return await Task.FromResult(response);
        }

        #endregion
    }
}
