using Gertec.Application.ViewModels.Responses.Cliente;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Gertec.Application.ViewModels.Requests.Cliente
{
    public class SalvarClienteRequest : IRequest<ClienteResponse>
    {
        /// <summary>
        /// Nome do Cliente
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Cpf do Cliente
        /// </summary>
        public string Cpf { get; set; }

        /// <summary>
        /// Idade do Cliente
        /// </summary>
        public int? Idade { get; set; }

        /// <summary>
        /// Telefone do Cliente
        /// </summary>
        public string Telefone { get; set; }

        /// <summary>
        /// Endereço do Cliente
        /// </summary>
        public EnderecoRequest? Endereco { get; set; }
    }
}
