using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gertec.Domain.Entites.Cliente
{
    public class EnderecoEntity
    {
        /// <summary>
        /// País
        /// </summary>
        public string? Pais { get; set; }

        /// <summary>
        /// Estado
        /// </summary>
        public string? Estado { get; set; }

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
    }
}
