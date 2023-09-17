namespace DataAccess.Models;
public class Attendee
{
    public int Attendee_Id { get; set; }
    public int Event_id { get; set; }
    public string Full_name { get; set; } = string.Empty;
    public string Attendee_email { get; set; } = string.Empty;
    public string Job_title { get; set; } = string.Empty;
    public string Organization { get; set; } = string.Empty;
    public string Industry_affiliation { get; set; } = string.Empty;
    public string QR_code { get; set; } = string.Empty;
    public string Status {  get; set; } = string.Empty;
}
