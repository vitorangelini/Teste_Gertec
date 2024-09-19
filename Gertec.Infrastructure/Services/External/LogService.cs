using AutoMapper;
using Gertec.Application.Interfaces.External;
using Gertec.Application.Interfaces.Repositories;
using Gertec.Application.Interfaces.Repositories.External;
using Gertec.Application.ViewModels.Responses.Venda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gertec.Infrastructure.Services.External
{
    public class LogService : ILogService
    {
        #region Properties
        private readonly ILogRepository _logRepository;
        #endregion

        #region Constructor
        public LogService(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }
        #endregion

        #region Actions
        /// <summary>
        /// Responsavel por incluir o log
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<bool> IncluirLog(Exception ex)
        {
            return _logRepository.IncluirLog(ex);
        }
        #endregion
    }
}
