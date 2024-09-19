using AutoMapper;
using Gertec.Application.Interfaces.Services;
using Gertec.Application.ViewModels.Requests.Cliente;
using Gertec.Application.ViewModels.Requests.Venda;
using Gertec.Application.ViewModels.Responses.Cliente;
using Gertec.Application.ViewModels.Responses.Venda;
using Gertec.Domain.Entites.Cliente;
using Gertec.Domain.Entites.Venda;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gertec.Application.Command.Venda
{
    public class SalvarVendaCommand : IRequestHandler<SalvarVendaRequest, VendaResponse>
    {
        #region Properties 
        private readonly IVendaService _vendaService;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public SalvarVendaCommand(IVendaService vendaService, IMapper mapper)
        {
            _vendaService = vendaService;
            _mapper = mapper;
        }
        #endregion

        #region IRequestHandler Implementation
        public async Task<VendaResponse> Handle(SalvarVendaRequest request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<SalvarVendaRequest, VendaEntity>(request);

            var response = await _vendaService.SalvarVenda(entity);

            return await Task.FromResult(response);
        }

        #endregion
    }
}
