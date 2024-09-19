using AutoMapper;
using Gertec.Application.Exceptions;
using Gertec.Application.Interfaces.Repositories;
using Gertec.Application.Interfaces.Services;
using Gertec.Application.ViewModels.Requests.Cliente;
using Gertec.Application.ViewModels.Responses.Cliente;
using Gertec.Application.ViewModels.Responses.Venda;
using Gertec.Domain.Entites.Cliente;
using Gertec.Domain.Entites.Venda;
using Gertec.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gertec.Infrastructure.Services
{
    public class ClienteService : IClienteService
    {
        #region Properties
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public ClienteService(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }
        #endregion

        #region Actions

        /// <summary>
        /// Responsável por retornar os dados do cliente.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        public async Task<ClienteResponse> ObterCliente(string cpf)
        {
            var retorno = await _clienteRepository.ObterCliente(cpf);

            return _mapper.Map<ClienteEntity,ClienteResponse?>(retorno);
        }

        /// <summary>
        /// Responsável por salvar os dados do cliente.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ClienteResponse> SalvarCliente(ClienteEntity request)
        {
            if (request == null)
                throw new BusinessException("Os dados do Cliente não pode ser nulo.");

            if (request.Endereco == null)
                throw new BusinessException("O dados do Endereco não pode ser nulo.");

            var retorno = await _clienteRepository.SalvarCliente(request);
            
            return _mapper.Map<ClienteEntity, ClienteResponse?>(retorno);
        }

        /// <summary>
        /// Responsável por editar os dados do cliente.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ClienteResponse> EditarCliente(ClienteEntity request)
        {
            if (request == null)
                throw new BusinessException("Os dados do Cliente não podem ser nulos.");

            if (request.Endereco == null)
                throw new BusinessException("Os dados do Endereco não podem ser nulos.");

            var retorno = await _clienteRepository.EditarCliente(request);

            return _mapper.Map<ClienteEntity, ClienteResponse?>(retorno);
        }

        /// <summary>
        /// Método responsável por deletar os dados do cliente.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> DeletarCliente(long idCliente)
        {
            if (idCliente <= 0)
                throw new BusinessException("Id do cliente inválido.");

            return await _clienteRepository.DeletarCliente(idCliente);
        }

        #endregion
    }
}
