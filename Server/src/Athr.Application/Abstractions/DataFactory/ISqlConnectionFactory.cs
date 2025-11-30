using System.Data;

namespace Athr.Application.Abstractions.DataFactory;

public interface ISqlConnectionFactory
{
    IDbConnection CreateConnection();
}
