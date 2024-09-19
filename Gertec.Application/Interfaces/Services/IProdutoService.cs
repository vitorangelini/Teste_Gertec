using Gertec.Application.ViewModels.Requests.Produto;
using Gertec.Application.ViewModels.Responses.Produto;
using Gertec.Domain.Entites.Produto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gertec.Application.Interfaces.Services
{
    public interface IProdutoService
    {
        /// <summary>
        /// Responsável por retornar os dados do produto.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ProdutoResponse> ObterProduto(string partNumber);

        /// <summary>
        /// Responsável por salvar os dados do produto.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ProdutoResponse> SalvarProduto(SalvarProdutoEntity request);

        /// <summary>
        /// Responsável por editar os dados do produto.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ProdutoResponse> EditarProduto(EditarProdutoEntity request);

        /// <summary>
        /// Responsável por deletar os dados do produto.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> DeletarProduto(long idProduto);
    }
}
