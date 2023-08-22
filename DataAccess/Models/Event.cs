namespace DataAccess.Models;
public class Event
{
    public int Event_id { get; set; }
    public string Event_name { get; set; } = string.Empty;
    public string Event_description { get; set; } = string.Empty;
    public DateTime Event_date { get; set; }
    public string Event_image { get; set; } = string.Empty;
}
