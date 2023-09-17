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

    public Task SetAttendeeStatus(string Attendee_email, int event_id, string status) =>
        _db.SaveData(storedProcedure: "dbo.SetAttendeeStatus", new { Attendee_email, event_id, status });
}
