using Gertec.Application.ViewModels.Requests.Venda;
using Gertec.Application.ViewModels.Responses.Venda;
using Gertec.Domain.Entites.Venda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gertec.Application.Interfaces.Repositories
{
    public interface IVendaRepository
    {
        /// <summary>
        /// Responsável por retornar os dados da venda.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<VendaEntity> ObterVenda(long idVenda);

        /// <summary>
        /// Responsável por retornar os dados da venda.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<List<VendaEntity>> ResumoVenda(ResumoVendaRequest request);

        /// <summary>
        /// Responsavel por salvar os dados da venda.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<VendaEntity> SalvarVenda(VendaEntity request);
    }
}
