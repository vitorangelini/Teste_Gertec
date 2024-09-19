using Dapper;
using Gertec.Application.Exceptions;
using Gertec.Application.Interfaces.Repositories;
using Gertec.Application.Interfaces.Repositories.DbConnection;
using Gertec.Application.ViewModels.Requests.Venda;
using Gertec.Application.ViewModels.Responses.Venda;
using Gertec.Domain.Entites.Venda;
using Gertec.Infrastructure.Queries;
using System.Net.Http.Headers;

namespace Gertec.Infrastructure.Repositories
{
    public class VendaRepository : IVendaRepository
    {
        #region Properties
        private readonly IDbConnectionFactory _connectioon;
        #endregion

        #region Constructor
        public VendaRepository(IDbConnectionFactory connectioon)
        {
            _connectioon = connectioon;
        }
        #endregion

        #region Actions

        /// <summary>
        /// Responsável por retornar os dados da venda.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<VendaEntity> ObterVenda(long idVenda)
        {
            using (var conn = _connectioon.CreateConnection())
            {
                return (await conn.QueryAsync<VendaEntity?>(QueryVenda.SELECT_OBTER_VENDA, new
                {
                    idVenda
                })).FirstOrDefault();
            }
        }

        /// <summary>
        /// Responsável por retornar os dados da venda.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<VendaEntity>> ResumoVenda(ResumoVendaRequest request)
        {
            var dataCompra = new DateTime(request.Data.Year, request.Data.Month, request.Data.Day);

            using (var conn = _connectioon.CreateConnection())
            {
                return (await conn.QueryAsync<VendaEntity?>(QueryVenda.SELECT_LISTAR_VENDA, new
                {
                    dataCompra
                })).ToList();
            }
        }

        /// <summary>
        /// Responsavel por salvar os dados da venda.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<VendaEntity> SalvarVenda(VendaEntity request)
        {
            var PrecoTotal = (request.Quantidade * request.PrecoMedio);

            using (var conn = _connectioon.CreateConnection())
            {
                conn.Open();

                var idVenda = await conn.ExecuteScalarAsync<long>(QueryVenda.INSERIR_VENDA, new
                {
                    request.Vendedor,
                    request.IdProduto,
                    request.IdCliente,
                    request.Quantidade,
                    request.PrecoMedio,
                    PrecoTotal
                });

                return new VendaEntity
                {
                    Id = idVenda,
                    Vendedor = request.Vendedor,
                    DataCompra = DateTime.Now,
                    IdProduto = request.IdProduto,
                    IdCliente = request.IdCliente,
                    Quantidade = request.Quantidade,
                    PrecoMedio = request.PrecoMedio,
                    PrecoTotal = PrecoTotal
                };
            }
        }

        #endregion
    }
}
