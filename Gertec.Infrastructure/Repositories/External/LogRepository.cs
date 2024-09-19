using Dapper;
using Gertec.Application.Interfaces.Repositories.DbConnection;
using Gertec.Application.Interfaces.Repositories.External;
using Gertec.Infrastructure.Queries;
using System.Diagnostics;

namespace Gertec.Infrastructure.Repositories.External
{
    public class LogRepository : ILogRepository
    {
        #region Properties
        private readonly IDbConnectionFactory _connection;
        #endregion

        #region Constructor
        public LogRepository(IDbConnectionFactory connection)
        {
            _connection = connection;
        }
        #endregion

        #region Actions

        /// <summary>
        /// Responsavel por incluir o log
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> IncluirLog(Exception ex)
        {
            string stackTrace = ex.StackTrace;

            using (var conn = _connection.CreateConnection())
            {
                conn.Open();

                if (stackTrace != null && stackTrace.Length > 1000)
                    stackTrace = stackTrace.Substring(0, 1000);

                var rowsAffected = await conn.ExecuteAsync(QueryExternal.INSERT_LOG, new
                {
                    Message = ex.Message,
                    StackTrace = stackTrace
                });

                return rowsAffected > 0; 
            }
        }
        #endregion
    }
}
