using DataAccess.Models;

namespace DataAccess.Data;
public interface IEventData
{
    Task CreateEvent(Event singleEvent);
    Task<Event?> GetEvent(int id);
    Task<IEnumerable<Event>> GetEvents();
    Task<IEnumerable<Event>> GetLastThreeEvents();
    Task UpdateEvent(Event user);
}