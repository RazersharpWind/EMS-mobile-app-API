using DataAccess.Models;

namespace DataAccess.Data;
public interface IAttendeeData
{
    Task<IEnumerable<Attendee>> GetAttendees();
    Task SetAttendeeStatus(string Attendee_email, int event_id, string status);
}