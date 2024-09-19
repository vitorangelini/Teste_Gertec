using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gertec.Application.ViewModels.Responses.Venda
{
    public class VendaResponse
    {
        /// <summary>
        /// Id da Venda
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Vendedor responsável pela venda.
        /// </summary>
        public string Vendedor { get; set; }

        /// <summary>
        /// Data em que a compra foi efetuada.
        /// </summary>
        public DateTime DataCompra { get; set; }

        /// <summary>
        /// Id do Produto.
        /// </summary>
        public long IdProduto { get; set; }

        /// <summary>
        /// Id do Cliente.
        /// </summary>
        public long IdCliente { get; set; }

        /// <summary>
        /// Quantidade de produtos.
        /// </summary>
        public int Quantidade { get; set; }

        /// <summary>
        /// Preço do produto.
        /// </summary>
        public decimal PrecoTotal { get; set; }
        
        /// <summary>
        /// Preço médio da venda.
        /// </summary>
        public decimal PrecoMedio { get; set; }
    }
}
