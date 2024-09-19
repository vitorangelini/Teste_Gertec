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
    public class ListarVendaQuery :  IRequestHandler<ResumoVendaRequest, List<VendaResponse>>
    {
        #region Properties 
        private readonly IVendaService _vendaService;
        #endregion

        #region Constructor
        public ListarVendaQuery(IVendaService vendaService)
        {
            _vendaService = vendaService;
        }
        #endregion

        #region IRequestHandler Implementation

        public async Task<List<VendaResponse>> Handle(ResumoVendaRequest request, CancellationToken cancellationToken)
        {
            var listarVendaResponse = new List<VendaResponse>();

            var response = await _vendaService.ResumoVenda(request);

            listarVendaResponse = response;

            return await Task.FromResult(listarVendaResponse);
        }

        #endregion
    }
}
