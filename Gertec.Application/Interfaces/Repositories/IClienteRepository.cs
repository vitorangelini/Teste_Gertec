using Gertec.Application.ViewModels.Responses.Cliente;
using Gertec.Domain.Entites.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gertec.Application.Interfaces.Repositories
{
    public interface IClienteRepository
    {
        /// <summary>
        /// Responsável por retornar os dados do cliente.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        Task<ClienteEntity> ObterCliente(string cpf);

        /// <summary>
        /// Responsável por salvar os dados do cliente.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ClienteEntity> SalvarCliente(ClienteEntity request);

        /// <summary>
        /// Responsável por editar os dados do cliente.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ClienteEntity> EditarCliente(ClienteEntity request);

        /// <summary>
        /// Método responsável por deletar os dados do cliente.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellatio
        Task<bool> DeletarCliente(long idCliente);
    }
}
