using System.Xml.Linq;

namespace WebMVC.Models;

public class UsersViewModel
{
    public int Id { get; set; }
    public DateTime SendDate { get; set; }
    public int IdHistory { get; set; }
    public int IdAudit { get; set; }
    public UsersViewModel(int id, DateTime sendDate, int idHistory, int idAudit)
    {
        Id = id;
        SendDate = sendDate;
        IdHistory = idHistory;
        IdAudit = idAudit;
    }
    public UsersViewModel() { }
}
