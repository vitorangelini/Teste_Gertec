using Gertec.Application.ViewModels.Requests.Cliente;
using Gertec.Application.ViewModels.Responses.Cliente;
using Gertec.Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MySqlX.XDevAPI.Common;
using System.Net;

namespace Gertec.Api.Controllers
{
    [ApiController]
    [Route("api/v1/cliente/")]
    public class ClienteController : ControllerBase
    {
        #region Fields
        private readonly IMediator Mediator;
        #endregion

        #region Constructor
        public ClienteController(IMediator mediator)
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
        /// Responsável por retornar os dados do cliente.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ClienteResponse), (int)HttpStatusCode.OK)]
        [Produces(TiposConteudos.Json)]
        public async Task<ActionResult> ObterCliente(string cpf, CancellationToken cancellationToken)
        {
            var request = new ObterClienteRequest();
            request.Cpf = cpf;

            var response = await Mediator.Send(request, cancellationToken);

            if (response is null || response.Cpf is null)
                return NotFound();

            return Ok(response);
        }

        /// <summary>
        /// Responsável por salvar os dados do cliente.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ClienteResponse), (int)HttpStatusCode.OK)]
        [Produces(TiposConteudos.Json)]
        public async Task<ActionResult> SalvarCliente(SalvarClienteRequest request, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(request, cancellationToken);

            if (response is null)
                return NotFound();

            return Ok(response);
        }

        /// <summary>
        /// Responsável por editar os dados do cliente.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ClienteResponse), (int)HttpStatusCode.OK)]
        [Produces(TiposConteudos.Json)]
        public async Task<ActionResult> EditarCliente(EditarClienteRequest request, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(request, cancellationToken);

            if (response is null)
                return NotFound();

            return Ok(response);
        }

        /// <summary>
        /// Método responsável por deletar os dados do cliente.
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
        public async Task<ActionResult> DeletarCliente(long idCliente, CancellationToken cancellationToken)
        {
            var request = new DeletarClienteRequest();
            request.IdCliente = idCliente;

            var response = await Mediator.Send(request, cancellationToken);

            if (!response.Status)
                return NotFound(); 

            return NoContent(); 
        }

        #endregion
    }
}
