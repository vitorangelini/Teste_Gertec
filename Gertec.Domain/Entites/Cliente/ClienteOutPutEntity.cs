using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gertec.Domain.Entites.Cliente
{
    public class ClienteOutPutEntity
    {
        /// <summary>
        /// Id do Cliente
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Nome do Cliente
        /// </summary>
        public string? Nome { get; set; }

        /// <summary>
        /// Cpf do Cliente
        /// </summary>
        public string? Cpf { get; set; }

        /// <summary>
        /// Idade do Cliente
        /// </summary>
        public int? Idade { get; set; }

        /// <summary>
        /// Telefone do Cliente
        /// </summary>
        public string? Telefone { get; set; }

        /// <summary>
        /// País
        /// </summary>
        public string? Pais { get; set; }

        /// <summary>
        /// Estado
        /// </summary>
        public string Estado { get; set; }

        /// <summary>
        /// Cidade
        /// </summary>
        public string? Cidade { get; set; }

        /// <summary>
        /// Bairro
        /// </summary>
        public string? Bairro { get; set; }

        /// <summary>
        /// Rua
        /// </summary>
        public string? Rua { get; set; }

        /// <summary>
        /// Numero
        /// </summary>
        public string? Numero { get; set; }

        /// <summary>
        /// Complemento
        /// </summary>
        public string? Complemento { get; set; }

        /// <summary>
        /// Ativo/Inativo
        /// </summary>
        public bool? Ativo { get; set; }
    }
}
