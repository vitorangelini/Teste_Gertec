using Gertec.Application.Interfaces.Services;
using Gertec.Application.ViewModels.Requests.Cliente;
using Gertec.Application.ViewModels.Requests.Venda;
using Gertec.Application.ViewModels.Responses.Cliente;
using Gertec.Application.ViewModels.Responses.Venda;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gertec.Application.Query.Venda
{
  
    public class ObterVendaQuery : IRequestHandler<ObterVendaRequest, VendaResponse>
    {
        #region Properties 
        private readonly IVendaService _vendaService;
        #endregion

        #region Constructor
        public ObterVendaQuery(IVendaService vendaService)
        {
            _vendaService = vendaService;
        }
        #endregion

        #region IRequestHandler Implementation

        public async Task<VendaResponse> Handle(ObterVendaRequest request, CancellationToken cancellationToken)
        {
            var obterVendaResponse = new VendaResponse();

            var response = await _vendaService.ObterVenda(request.IdVenda);

            obterVendaResponse = response;

            return await Task.FromResult(obterVendaResponse);
        }

        #endregion
    }
}
