namespace DataAccess.DBAccess;

public interface ISqlDataAccess
{
    Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectedId = "DefaultConnection");
    Task SaveData<T>(string storedProcedure, T parameters, string connectionId = "DefaultConnection");
}