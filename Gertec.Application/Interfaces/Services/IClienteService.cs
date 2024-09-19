using Gertec.Application.ViewModels.Requests.Cliente;
using Gertec.Application.ViewModels.Responses.Cliente;
using Gertec.Domain.Entites.Cliente;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gertec.Application.Interfaces.Services
{
    public interface IClienteService
    {
        /// <summary>
        /// Responsável por retornar os dados do cliente.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ClienteResponse> ObterCliente(string cpf);

        /// <summary>
        /// Responsável por salvar os dados do cliente.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ClienteResponse> SalvarCliente(ClienteEntity request);

        /// <summary>
        /// Responsável por editar os dados do cliente.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ClienteResponse> EditarCliente(ClienteEntity request);

        /// <summary>
        /// Método responsável por deletar os dados do cliente.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> DeletarCliente(long idCliente);
    }
}
