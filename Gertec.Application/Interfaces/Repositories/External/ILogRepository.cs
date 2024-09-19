using Gertec.Domain.Entites.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gertec.Application.Interfaces.Repositories.External
{
    public interface ILogRepository
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
