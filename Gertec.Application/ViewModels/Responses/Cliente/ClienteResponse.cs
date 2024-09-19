using Gertec.Application.ViewModels.Requests.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gertec.Application.ViewModels.Responses.Cliente
{
    public class ClienteResponse
    {
        /// <summary>
        /// Id do Cliente
        /// </summary>
        public long? IdCliente { get; set; }
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
        public EnderecoResponse? Endereco { get; set; }

        /// <summary>
        /// Ativo/Inativo
        /// </summary>
        public bool? Ativo { get; set; }
    }
}
