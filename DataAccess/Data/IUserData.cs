using DataAccess.Models;

namespace DataAccess.Data;
public interface IUserData
{
    Task<User_with_eID?> GetUser(int id);
    Task<IEnumerable<User_with_eID>> GetUsers();
    Task InsertUser(User_with_eID user);
    Task UpdateUser(User_with_eID user);
}