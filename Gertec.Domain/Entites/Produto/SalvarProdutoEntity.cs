using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gertec.Domain.Entites.Produto
{
    public class SalvarProdutoEntity
    {
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
    }
}
