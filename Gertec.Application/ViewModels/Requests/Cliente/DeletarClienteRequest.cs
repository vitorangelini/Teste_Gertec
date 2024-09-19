using Gertec.Application.ViewModels.Responses.Cliente;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gertec.Application.ViewModels.Requests.Cliente
{
    public class DeletarClienteRequest : IRequest<DeleteClienteResponse>
    {
        /// <summary>
        /// Id do Cliente
        /// </summary>
        public long IdCliente { get; set; }
    }
}
