using DataAccess.DBAccess;
using DataAccess.Models;

namespace DataAccess.Data;
public class AttendeeData : IAttendeeData
{
    private readonly ISqlDataAccess _db;

    public AttendeeData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<Attendee>> GetAttendees() =>
        _db.LoadData<Attendee, dynamic>(storedProcedure: "dbo.GetAttendees", new { });
}
