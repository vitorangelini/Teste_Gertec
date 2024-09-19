using Gertec.Application.ViewModels.Responses.Cliente;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gertec.Application.ViewModels.Requests.Cliente
{
    public class ObterClienteRequest : IRequest<ClienteResponse>
    {
        /// <summary>
        /// Cpf do Cliente
        /// </summary>
        public string Cpf { get; set; }
    }
}
