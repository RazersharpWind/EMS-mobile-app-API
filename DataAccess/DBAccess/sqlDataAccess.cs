using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.Common;

//Here Dapper is talking/communicating with SQL database.
namespace DataAccess.DBAccess;
public class SqlDataAccess : ISqlDataAccess
{
    private readonly IConfiguration _config;

    public SqlDataAccess(IConfiguration config)
    {
        _config = config;
    }

    //get all users or only one user
    public async Task<IEnumerable<T>> LoadData<T, U>(
        string storedProcedure,
        U parameters,
        string connectedId = "DefaultConnection")
    {
        using DbConnection connection = new SqlConnection(_config.GetConnectionString(connectedId));

        return await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }

    //insert or update user
    public async Task SaveData<T>(
        string storedProcedure,
        T parameters,
        string connectionId = "DefaultConnection")
    {
        using DbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

        await connection.ExecuteAsync(storedProcedure, parameters,
            commandType: CommandType.StoredProcedure);
    }
}
