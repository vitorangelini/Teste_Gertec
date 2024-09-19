using MySql.Data.MySqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;
using Gertec.Application.Interfaces.Repositories.DbConnection;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace Gertec.Infrastructure.Repositories.MySql
{
    public class DbConnection : IDbConnectionFactory
    {
        #region Fields
        private readonly IConfiguration _config;
        #endregion

        #region Constructor
        public DbConnection(IConfiguration config)
        {
            _config = config;
        }
        #endregion

        #region IDbConnection Implementation
        public IDbConnection CreateConnection()
        {
            return new MySqlConnection(_config.GetSection("ConnectionStrings").Value);
        }
        #endregion
    }
}
