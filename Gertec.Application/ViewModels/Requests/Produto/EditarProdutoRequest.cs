using Gertec.Application.ViewModels.Responses.Produto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gertec.Application.ViewModels.Requests.Produto
{
    public class EditarProdutoRequest : IRequest<ProdutoResponse>
    {
        /// <summary>
        /// Id do Produto.
        /// </summary>
        public long IdProduto { get; set; }

        /// <summary>
        /// Descrição do Produto.
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// Valor do Produto.
        /// </summary>
        public decimal Valor { get; set; }

        /// <summary>
        /// PartNumber do Produto.
        /// </summary>
        public string PartNumber { get; set; }

        /// <summary>
        /// Quantidade do Produto.
        /// </summary>
        public int Quantidade { get; set; }

        /// <summary>
        /// Ativo/Inativo
        /// </summary>
        public bool Ativo { get; set; }
    }
}
