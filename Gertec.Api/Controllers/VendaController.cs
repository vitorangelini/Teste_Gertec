using Gertec.Application.ViewModels.Requests.Venda;
using Gertec.Application.ViewModels.Responses.Venda;
using Gertec.Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Gertec.Api.Controllers
{
    [ApiController]
    [Route("api/v1/venda/")]
    public class VendaController : ControllerBase
    {
        #region Fields
        private readonly IMediator Mediator;
        #endregion

        #region Constructor
        public VendaController(IMediator mediator)
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
        /// Responsável por retornar os dados da venda.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(VendaResponse), (int)HttpStatusCode.OK)]
        [Produces(TiposConteudos.Json)]
        public async Task<ActionResult> ObterVenda(long idVenda , CancellationToken cancellationToken)
        {
            var request = new ObterVendaRequest();
                request.IdVenda = idVenda;

            var response = await Mediator.Send(request, cancellationToken);

            if (response is null)
                return NotFound();

            return Ok(response);
        }

        /// <summary>
        /// Responsavel por salvar os dados da venda.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(VendaResponse), (int)HttpStatusCode.OK)]
        [Produces(TiposConteudos.Json)]
        public async Task<ActionResult> SalvarVenda(SalvarVendaRequest request, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(request, cancellationToken);

            if (response is null)
                return NotFound();

            return Ok(response);
        }

        /// <summary>
        /// Responsável por listar os dados da venda do dia.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("resumo-venda")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(VendaResponse), (int)HttpStatusCode.OK)]
        [Produces(TiposConteudos.Json)]
        public async Task<ActionResult> ResumoVenda(DateTime data, CancellationToken cancellationToken)
        {
            var request = new ResumoVendaRequest();
            request.Data = data;

            var response = await Mediator.Send(request, cancellationToken);

            if (response is null || response.Count() == 0)
                return NotFound();

            return Ok(response);
        }

        #endregion
    }
}
