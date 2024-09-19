using Gertec.Application.Interfaces.Services;
using Gertec.Application.ViewModels.Requests.Cliente;
using Gertec.Application.ViewModels.Responses.Cliente;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gertec.Application.Query.Cliente
{
    public class ObterClienteQuery : IRequestHandler<ObterClienteRequest, ClienteResponse>
    {
        #region Properties 
        private readonly IClienteService _clienteService;
        #endregion

        #region Constructor
        public ObterClienteQuery(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }
        #endregion

        #region IRequestHandler Implementation

        public async Task<ClienteResponse> Handle(ObterClienteRequest request, CancellationToken cancellationToken)
        {
            var obterClienteResponse = new ClienteResponse();

            var response = await _clienteService.ObterCliente(request.Cpf);

            obterClienteResponse = response;

            return await Task.FromResult(obterClienteResponse);
        }

        #endregion
    }
}
