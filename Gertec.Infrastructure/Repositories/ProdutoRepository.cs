using Dapper;
using Gertec.Application.Exceptions;
using Gertec.Application.Interfaces.Repositories;
using Gertec.Application.Interfaces.Repositories.DbConnection;
using Gertec.Application.ViewModels.Responses.Produto;
using Gertec.Domain.Entites.Produto;
using Gertec.Domain.Entites.Venda;
using Gertec.Infrastructure.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gertec.Infrastructure.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        #region Properties
        private readonly IDbConnectionFactory _connectioon;
        #endregion

        #region Constructor
        public ProdutoRepository(IDbConnectionFactory connectioon)
        {
            _connectioon = connectioon;
        }
        #endregion

        #region Actions
   
        /// <summary>
        /// Responsável por retornar os dados do produto.
        /// </summary>
        /// <param name="request"></param>
        public async Task<ProdutoEntity> ObterProduto(string partNumber)
        {
            using (var conn = _connectioon.CreateConnection())
            {
                return (await conn.QueryAsync<ProdutoEntity?>(QueryProduto.SELECT_OBTER_PRD, new
                {
                    partNumber
                })).FirstOrDefault();
            }
        }

        /// <summary>
        /// Responsável por retornar os dados do produto através do id.
        /// </summary>
        /// <param name="idProduto"></param>
        /// <param name="cancellationToken">
        public async Task<ProdutoEntity> ObterProdutoId(long idProduto)
        {
            using (var conn = _connectioon.CreateConnection())
            {
                return  (await conn.QueryAsync<ProdutoEntity?>(QueryProduto.SELECT_OBTER_PRD_ID, new
                {
                    idProduto
                })).FirstOrDefault();
            }
        }

        /// <summary>
        /// Responsável por deletar os dados do produto.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ProdutoEntity> SalvarProduto(SalvarProdutoEntity request)
        {
            using (var conn = _connectioon.CreateConnection())
            {
                var idProduto = await conn.QuerySingleAsync<int>(QueryProduto.INSERIR_PRODUTO, new 
                {
                    request.Descricao,
                    request.Valor,
                    request.PartNumber,
                    request.Quantidade,
                });

                return new ProdutoEntity
                {
                    IdProduto       = idProduto,
                    Descricao       = request.Descricao,
                    Valor           = request.Valor,
                    PartNumber      = request.PartNumber,
                    Quantidade      = request.Quantidade,
                    Ativo           = true,
                };
            }
        }

        /// <summary>
        /// Responsável por editar os dados do produto.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ProdutoEntity> EditarProduto(EditarProdutoEntity request)
        {
            using (var conn = _connectioon.CreateConnection())
            {
                conn.Open();

                var rowsAffected = await conn.ExecuteAsync(QueryProduto.ATUALIZAR_PRODUTO, new
                {
                    request.Descricao,
                    request.Valor,
                    request.PartNumber,
                    request.Quantidade,
                    request.Ativo,
                    request.IdProduto
                });

                if (rowsAffected == 0)
                    throw new BusinessException("Produto não encontrado ou não foi possível atualizar.");

                return new ProdutoEntity
                {
                    IdProduto = request.IdProduto.Value,
                    Descricao = request.Descricao,
                    Valor = request.Valor,
                    PartNumber = request.PartNumber,
                    DataCriacao = request.DataCriacao,
                    Quantidade = request.Quantidade,
                    DataAtualizacao = DateTime.Now, 
                    Ativo = request.Ativo
                };
            }
        }

        /// <summary>
        /// Responsável por deletar os dados do produto.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async  Task<bool> DeletarProduto(long idProduto)
        {
            using (var conn = _connectioon.CreateConnection())
            {
                conn.Open();
                var rowsAffected  = await conn.ExecuteAsync(QueryProduto.DELETAR_PRODUTO, new { IdProduto = idProduto });

                return rowsAffected > 0;
            }
        }

        /// <summary>
        /// Método responsável por alterar a quantidade do produto quando efetuada a venda.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<bool> UpdateQuantidade(long idProduto, int quantidade)
        {
            using (var conn = _connectioon.CreateConnection())
            {
                conn.Open();

                var resultado = await conn.ExecuteAsync(QueryProduto.UPDATE_QUANTIDADE,
                    new { Quantidade = quantidade, IdProduto = idProduto }
                );

                return resultado > 0;
            }
        }

        #endregion
    }
}
