using DataAccess.Models;

namespace DataAccess.Data;
public interface IAttendeeData
{
    Task<IEnumerable<Attendee>> GetAttendees();
}