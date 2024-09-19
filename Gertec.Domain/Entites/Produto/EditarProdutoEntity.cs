using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gertec.Domain.Entites.Produto
{
    public class EditarProdutoEntity
    {
        /// <summary>
        /// Id do Produto.
        /// </summary>
        public long? IdProduto { get; set; }

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
        /// Data de Criação do Produto.
        /// </summary>
        public DateTime DataCriacao { get; set; }

        /// <summary>
        /// Quantidade do Produto.
        /// </summary>
        public int Quantidade { get; set; }

        /// <summary>
        /// Data de Atualização do Produto.
        /// </summary>
        public DateTime DataAtualizacao { get; set; }

        /// <summary>
        /// Ativo/Inativo
        /// </summary>
        public bool Ativo { get; set; }
    }
}
