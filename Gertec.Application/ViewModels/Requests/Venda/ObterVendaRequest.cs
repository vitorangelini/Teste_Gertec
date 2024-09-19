using Gertec.Application.ViewModels.Responses.Venda;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gertec.Application.ViewModels.Requests.Venda
{
    public class ObterVendaRequest : IRequest<VendaResponse>
    {
        /// <summary>
        /// Id da Venda
        /// </summary>
        public long IdVenda { get; set; }
    }
}
