using Dapper;
using Gertec.Application.Exceptions;
using Gertec.Application.Interfaces.Repositories;
using Gertec.Application.Interfaces.Repositories.DbConnection;
using Gertec.Application.ViewModels.Responses.Cliente;
using Gertec.Domain.Entites.Cliente;
using Gertec.Domain.Entites.Venda;
using Gertec.Infrastructure.Queries;
using MySqlX.XDevAPI.Common;
using Org.BouncyCastle.Crypto.Operators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gertec.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        #region Properties
        private readonly IDbConnectionFactory _connectioon;
        #endregion

        #region Constructor
        public ClienteRepository(IDbConnectionFactory connectioon)
        {
            _connectioon = connectioon;
        }
        #endregion

        #region Actions

        /// <summary>
        /// Responsável por retornar os dados do cliente.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        public async Task<ClienteEntity> ObterCliente(string cpf)
        {
            var retorno = new ClienteEntity();
            var result = new ClienteOutPutEntity();

            using (var conn = _connectioon.CreateConnection())
            {
                result = (await conn.QueryAsync<ClienteOutPutEntity?>(QueryCliente.SELECT_OBTER_CLIENTE, new
                {
                    cpf
                })).FirstOrDefault();
            }

            if (result != null)
            {
                retorno.IdCliente = result.Id;
                retorno.Ativo = result.Ativo.Value;
                retorno.Cpf = result.Cpf;
                retorno.Telefone = result.Telefone;
                retorno.Nome = result.Nome; 
                retorno.Idade = result.Idade;
                retorno.Endereco = new EnderecoEntity
                {
                    Bairro = result.Bairro,
                    Estado = result.Estado,
                    Cidade = result.Cidade,
                    Complemento = result.Complemento,
                    Numero = result.Numero,
                    Pais = result.Pais,
                    Rua = result.Rua
                };
            }

            return retorno;
        }

        /// <summary>
        /// Responsável por salvar os dados do cliente.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ClienteEntity> SalvarCliente(ClienteEntity request)
        {
            using (var conn = _connectioon.CreateConnection())
            {
                conn.Open();
                var idEndereco = await conn.QuerySingleAsync<int>(QueryCliente.INSERIR_ENDERECO, new
                {
                    request.Endereco.Pais,
                    request.Endereco.Estado, 
                    request.Endereco.Cidade,
                    request.Endereco.Bairro,
                    request.Endereco.Rua,
                    request.Endereco.Numero,
                    request.Endereco.Complemento
                });

                var idCliente = await conn.QuerySingleAsync<int>(QueryCliente.INSERIR_CLIENTE, new
                {
                    request.Nome,
                    request.Cpf,
                    request.Idade,
                    request.Telefone,
                    idEndereco
                });
                conn.Close();

                return new ClienteEntity
                {
                    Nome = request.Nome,
                    Cpf = request.Cpf,
                    Idade = request.Idade,
                    Telefone = request.Telefone,
                    IdCliente = idCliente,
                    Endereco = new EnderecoEntity
                    {
                        Pais = request.Endereco.Pais,
                        Estado = request.Endereco.Estado,
                        Cidade = request.Endereco.Cidade,
                        Bairro = request.Endereco.Bairro,
                        Rua = request.Endereco.Rua,
                        Numero = request.Endereco.Numero,
                        Complemento = request.Endereco.Complemento
                    },
                    Ativo = true
                };
            }
        }

        /// <summary>
        /// Responsável por editar os dados do cliente.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ClienteEntity> EditarCliente(ClienteEntity request)
        {
            using (var conn = _connectioon.CreateConnection())
            {
                conn.Open();

                var idEndereco = await conn.QuerySingleOrDefaultAsync<int>(QueryCliente.SELECT_ID_ENDERECO, new 
                { 
                    request.Cpf
                });

                await conn.ExecuteAsync(QueryCliente.ATUALIZAR_ENDERECO, new
                {
                    request.Endereco.Pais,
                    request.Endereco.Estado,
                    request.Endereco.Cidade,
                    request.Endereco.Bairro,
                    request.Endereco.Rua,
                    request.Endereco.Numero,
                    request.Endereco.Complemento,
                    idEndereco
                });

                await conn.ExecuteAsync(QueryCliente.ATUALIZAR_CLIENTE, new
                {
                    request.Nome,
                    request.Cpf,
                    request.Idade,
                    request.Telefone,
                    request.Ativo,
                    request.IdCliente 
                });

                return request; 
            }
        }

        /// <summary>
        /// Método responsável por deletar os dados do cliente.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellatio
        public async Task<bool> DeletarCliente(long idCliente)
        {
            using (var conn = _connectioon.CreateConnection())
            {
                conn.Open();

                var rowsAffectedCliente = await conn.ExecuteAsync(QueryCliente.DELETAR_CLIENTE, new { IdCliente = idCliente });

                return rowsAffectedCliente > 0 ;
            }
        }

        #endregion
    }
}
