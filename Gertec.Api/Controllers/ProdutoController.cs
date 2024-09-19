using Gertec.Application.ViewModels.Requests.Produto;
using Gertec.Application.ViewModels.Responses.Produto;
using Gertec.Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Gertec.Api.Controllers
{
    [ApiController]
    [Route("api/v1/produto/")]
    public class ProdutoController : ControllerBase
    {
        #region Fields
        private readonly IMediator Mediator;
        #endregion

        #region Constructor
        public ProdutoController(IMediator mediator)
        {
            Mediator = mediator;
        }
        #endregion

        #region Actions

        /*
        <summary>
        Verifica se a api está respondendo
        </summary>
        <returns>true or false</returns>
        */
        [HttpGet]
        [AllowAnonymous]
        [Route("is-alive")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
        public bool IsAlive()
        {
            return true;
        }

        /// <summary>
        /// Responsável por retornar os dados do produto.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProdutoResponse), (int)HttpStatusCode.OK)]
        [Produces(TiposConteudos.Json)]
        public async Task<ActionResult> ObterProduto(string partNumber , CancellationToken cancellationToken)
        {
            var request = new ObterProdutoRequest();
            request.PartNumber = partNumber;

            var response = await Mediator.Send(request, cancellationToken);

            if (response is null || response.PartNumber is null)
                return NotFound();

            return Ok(response);
        }

        /// <summary>
        /// Responsável por salvar os dados do produto.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProdutoResponse), (int)HttpStatusCode.OK)]
        [Produces(TiposConteudos.Json)]
        public async Task<ActionResult> SalvarProduto(SalvarProdutoRequest request, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(request, cancellationToken);

            if (response is null)
                return NotFound();

            return Ok(response);
        }

        /// <summary>
        /// Responsável por editar os dados do produto.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProdutoResponse), (int)HttpStatusCode.OK)]
        [Produces(TiposConteudos.Json)]
        public async Task<ActionResult> EditarProduto(EditarProdutoRequest request, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(request, cancellationToken);

            if(response is null)
                return NotFound();

            return Ok(response);
        }

        /// <summary>
        /// Responsável por deletar os dados do produto.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [Produces(TiposConteudos.Json)]
        public async Task<ActionResult> DeletarProduto(long idProduto, CancellationToken cancellationToken)
        {
            var request = new DeletarProdutoRequest();
            request.IdProduto = idProduto;

            var response = await Mediator.Send(request, cancellationToken);

            if (!response.Status)
                return NotFound();

            return NoContent();
        }

        #endregion
    }
}
