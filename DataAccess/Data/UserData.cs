using DataAccess.DBAccess;
using DataAccess.Models;

namespace DataAccess.Data;

public class UserData : IUserData
{
    private readonly ISqlDataAccess _db;

    public UserData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<User_with_eID>> GetUsers() =>
        _db.LoadData<User_with_eID, dynamic>(storedProcedure: "dbo.UserWitheID_GetAll", new { });

    public async Task<User_with_eID?> GetUser(int id)
    {
        var result = await _db.LoadData<User_with_eID, dynamic>(
            storedProcedure: "dbo.UserWitheID_Get",
            new { id = id });

        return result.FirstOrDefault();
    }

    public Task InsertUser(User_with_eID user) =>
        _db.SaveData(storedProcedure: "dbo.UserWitheID_Insert",
            new
            {
                user.EmiratesIDNum,
                user.DOB,
                user.EmiratesIDExpiry,
                user.first_name,
                user.last_name,                
                user.PhoneNumber,
                user.Email,
                user.AlternateEmail,
                user.CountryOfResidence,
                user.password
            });

    public Task UpdateUser(User_with_eID user) =>
        _db.SaveData(storedProcedure: "dbo.UserWitheID_Update", user);

    public async Task<User_with_eID?> Login(string email, string password)
    {
        var result = await _db.LoadData<User_with_eID, dynamic>(
            storedProcedure: "dbo.Login",
            new { email = email, password = password });

        return result.FirstOrDefault();
    }
}
