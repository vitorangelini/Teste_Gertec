using Gertec.Application.ViewModels.Responses.Produto;
using Gertec.Domain.Entites.Produto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gertec.Application.Interfaces.Repositories
{
    public interface IProdutoRepository
    {
        /// <summary>
        /// Responsável por retornar os dados do produto através do partNumber.
        /// </summary>
        /// <param name="partNumber"></param>
        /// <param name="cancellationToken">
        Task<ProdutoEntity> ObterProduto(string partNumber);

        /// <summary>
        /// Responsável por retornar os dados do produto através do id.
        /// </summary>
        /// <param name="idProduto"></param>
        /// <param name="cancellationToken">
        Task<ProdutoEntity> ObterProdutoId(long idProduto);

        /// <summary>
        /// Responsável por salvar os dados do produto.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ProdutoEntity> SalvarProduto(SalvarProdutoEntity request);

        /// <summary>
        /// Responsável por editar os dados do produto.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ProdutoEntity> EditarProduto(EditarProdutoEntity request);

        /// <summary>
        /// Responsável por deletar os dados do produto.
        /// </summary>
        /// <param name="idProduto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> DeletarProduto(long idProduto);

        /// <summary>
        /// Método responsável por alterar a quantidade do produto quando efetuada a venda.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<bool> UpdateQuantidade(long idProduto, int quantidade);
    }
}
