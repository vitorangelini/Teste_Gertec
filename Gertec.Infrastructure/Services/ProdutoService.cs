using AutoMapper;
using Gertec.Application.Exceptions;
using Gertec.Application.Interfaces.Repositories;
using Gertec.Application.Interfaces.Services;
using Gertec.Application.ViewModels.Requests.Produto;
using Gertec.Application.ViewModels.Responses.Produto;
using Gertec.Domain.Entites.Produto;
using Gertec.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gertec.Infrastructure.Services
{
    public class ProdutoService : IProdutoService
    {
        #region Properties
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }
        #endregion

        #region Actions

        /// <summary>
        /// Responsável por retornar os dados do produto.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken">
        public async Task<ProdutoResponse> ObterProduto(string partNumber)
        {
           var retorno = await _produtoRepository.ObterProduto(partNumber);

            if (retorno is null || retorno.IdProduto is null)
                throw new BusinessException("Produto Indisponivel!");

            return _mapper.Map<ProdutoEntity, ProdutoResponse?>(retorno);
        }

        /// <summary>
        /// Responsável por salvar os dados do produto.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ProdutoResponse> SalvarProduto(SalvarProdutoEntity request)
        {
            var retorno = await _produtoRepository.SalvarProduto(request);

            return _mapper.Map<ProdutoEntity, ProdutoResponse?>(retorno);

        }

        /// <summary>
        /// Responsável por editar os dados do produto.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ProdutoResponse> EditarProduto(EditarProdutoEntity request)
        {
            if (request == null)
                throw new BusinessException("Os dados do Produto não podem ser nulos.");

            if (request.IdProduto == null)
                throw new BusinessException("O Id do Produto é obrigatório.");

            var retorno = await _produtoRepository.EditarProduto(request);

            return _mapper.Map<ProdutoEntity, ProdutoResponse?>(retorno);
        }

        /// <summary>
        /// Responsável por deletar os dados do produto.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> DeletarProduto(long idProduto)
        {
            if (idProduto <= 0)
                throw new BusinessException("Id do produto inválido.");

            return await _produtoRepository.DeletarProduto(idProduto);
        }
        #endregion
    }
}
