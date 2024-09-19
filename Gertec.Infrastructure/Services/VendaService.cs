using AutoMapper;
using Gertec.Application.Exceptions;
using Gertec.Application.Interfaces.Repositories;
using Gertec.Application.Interfaces.Services;
using Gertec.Application.ViewModels.Requests.Venda;
using Gertec.Application.ViewModels.Responses.Venda;
using Gertec.Domain.Entites.Venda;
using Gertec.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gertec.Infrastructure.Services
{
    public class VendaService : IVendaService
    {
        #region Properties
        private readonly IVendaRepository _vendaRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public VendaService(
                            IVendaRepository vendaRepository, 
                            IMapper mapper,
                            IProdutoRepository produtoRepository
                            )
        {
            _vendaRepository = vendaRepository;
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }
        #endregion

        #region Actions

        /// <summary>
        /// Responsável por retornar os dados da venda.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<VendaResponse> ObterVenda(long idVenda)
        {
            var retorno = await _vendaRepository.ObterVenda(idVenda);

            return _mapper.Map<VendaEntity, VendaResponse?>(retorno);
        }

        /// <summary>
        /// Responsável por retornar os dados da venda.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<VendaResponse>> ResumoVenda(ResumoVendaRequest request)
        {
            var retorno = await _vendaRepository.ResumoVenda(request);

            return _mapper.Map<List<VendaEntity>, List<VendaResponse?>>(retorno);
        }

        /// <summary>
        /// Responsavel por salvar os dados da venda.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<VendaResponse> SalvarVenda(VendaEntity request)
        {
            if (request == null)
                throw new BusinessException("Os dados da venda não podem ser nulos.");

            var dadosProduto = await _produtoRepository.ObterProdutoId(request.IdProduto.Value);

            if (dadosProduto is null)
                throw new BusinessException("Produto Indisponível");

            if (dadosProduto is not null)
                if (dadosProduto.Quantidade <=  request.Quantidade)
                    throw new BusinessException("Não possuimos essa quantidade de produto no estoque, Quantidade restante:" + dadosProduto.Quantidade);

            var retorno = await _vendaRepository.SalvarVenda(request);

            if (retorno.IdProduto.Value <= 0)
                throw new ArgumentException("ID do produto inválido.");

            var retornoUpdate = await _produtoRepository.UpdateQuantidade(retorno.IdProduto.Value, retorno.Quantidade.Value);

            return _mapper.Map<VendaEntity,VendaResponse>(retorno);
        }
        #endregion
    }
}
