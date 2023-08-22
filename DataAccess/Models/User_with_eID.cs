namespace DataAccess.Models;
public class User_with_eID
{
    public int UID { get; set; }
    public long EmiratesIDNum { get; set; }
    public DateTime DOB { get; set; }
    public DateTime EmiratesIDExpiry { get; set; }
    public string FullName { get; set; } = string.Empty;
    public int PhoneNumber { get; set; }
    public string Email { get; set; } = string.Empty;
    public string AlternateEmail { get; set; } = string.Empty;
    public string CountryOfResidence { get; set; } = string.Empty;
}
