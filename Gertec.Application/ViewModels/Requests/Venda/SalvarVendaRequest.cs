using Gertec.Application.ViewModels.Responses.Cliente;
using Gertec.Application.ViewModels.Responses.Venda;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gertec.Application.ViewModels.Requests.Venda
{
    public class SalvarVendaRequest : IRequest<VendaResponse>
    {
        /// <summary>
        /// Vendedor responsável pela venda.
        /// </summary>
        public string Vendedor { get; set; }

        /// <summary>
        /// Id do Produto.
        /// </summary>
        public long IdProduto { get; set; }

        /// <summary>
        /// Id do Cliente.
        /// </summary>
        public long IdCliente { get; set; }

        public int Quantidade { get; set; }

        public decimal PrecoMedio { get; set; }

    }
}
