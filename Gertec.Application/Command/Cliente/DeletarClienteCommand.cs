using AutoMapper;
using Gertec.Application.Interfaces.Services;
using Gertec.Application.ViewModels.Requests.Cliente;
using Gertec.Application.ViewModels.Responses.Cliente;
using Gertec.Domain.Entites.Cliente;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gertec.Application.Command.Cliente
{
    public class DeletarClienteCommand : IRequestHandler<DeletarClienteRequest, DeleteClienteResponse>
    {
        #region Properties 
        private readonly IClienteService _clienteService;
        #endregion

        #region Constructor
        public DeletarClienteCommand(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }
        #endregion

        #region IRequestHandler Implementation
        public async Task<DeleteClienteResponse> Handle(DeletarClienteRequest request, CancellationToken cancellationToken)
        {
            var result = new DeleteClienteResponse();

            var response = await _clienteService.DeletarCliente(request.IdCliente);

            result.Status = response;

            return await Task.FromResult(result);
        }

        #endregion
    }
}
