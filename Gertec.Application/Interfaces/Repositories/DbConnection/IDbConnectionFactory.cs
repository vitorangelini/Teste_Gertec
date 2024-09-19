
using System.Data;


namespace Gertec.Application.Interfaces.Repositories.DbConnection
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
