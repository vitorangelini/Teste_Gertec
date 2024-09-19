using Gertec.Application.ViewModels.Requests.Venda;
using Gertec.Application.ViewModels.Responses.Venda;
using Gertec.Domain.Entites.Venda;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gertec.Application.Interfaces.Services
{
    public interface IVendaService
    {

        /// <summary>
        /// Responsável por retornar os dados da venda.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<VendaResponse> ObterVenda(long idVenda);

        /// <summary>
        /// Responsável por retornar os dados da venda.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<List<VendaResponse>> ResumoVenda(ResumoVendaRequest request);

        /// <summary>
        /// Responsavel por salvar os dados da venda.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<VendaResponse> SalvarVenda(VendaEntity request);
    }
}
