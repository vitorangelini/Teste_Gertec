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
    public class SalvarClienteCommand : IRequestHandler<SalvarClienteRequest, ClienteResponse>
    {
        #region Properties 
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public SalvarClienteCommand(IClienteService clienteService, IMapper mapper)
        {
            _clienteService = clienteService;
            _mapper = mapper;
        }
        #endregion

        #region IRequestHandler Implementation
        public async Task<ClienteResponse> Handle(SalvarClienteRequest request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<SalvarClienteRequest,ClienteEntity>(request);

            var response = await _clienteService.SalvarCliente(entity);

            return await Task.FromResult(response);
        }
        
        #endregion
    }
}
