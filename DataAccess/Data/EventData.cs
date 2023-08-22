using DataAccess.DBAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data;
public class EventData : IEventData
{
    private readonly ISqlDataAccess _db;

    public EventData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<Event>> GetEvents() =>
        _db.LoadData<Event, dynamic>(storedProcedure: "dbo.GetAllEvents", new { });

    public async Task<Event?> GetEvent(int id)
    {
        var result = await _db.LoadData<Event, dynamic>(
            storedProcedure: "dbo.GetEvent",
            new { id = id });

        return result.FirstOrDefault();
    }

    public Task<IEnumerable<Event>> GetLastThreeEvents() =>
        _db.LoadData<Event, dynamic>(storedProcedure: "dbo.GetLastThreeEvents", new { });

    public Task CreateEvent(Event singleEvent) =>
        _db.SaveData(storedProcedure: "dbo.CreateEvent",
            new
            {
                singleEvent.Event_name,
                singleEvent.Event_description,
                singleEvent.Event_date,
                singleEvent.Event_image
            });

    public Task UpdateEvent(Event user) =>
        _db.SaveData(storedProcedure: "dbo.UpdateEvent", user);
}
