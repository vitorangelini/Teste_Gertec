using Gertec.Application.ViewModels.Responses.Venda;
using Gertec.Domain.Entites.Venda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gertec.Application.Interfaces.External
{
    public interface ILogService
    {
        /// <summary>
        /// Responsavel por incluir o log
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> IncluirLog(Exception ex);
    }
}
