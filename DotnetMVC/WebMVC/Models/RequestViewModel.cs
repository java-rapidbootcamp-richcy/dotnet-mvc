using System.Xml.Linq;

namespace WebMVC.Models;

public class RequestViewModel
{

    public int Id { get; set; }
    public int IdAsset{ get; set; }
    public int IdPic { get; set; }
    public string Approval { get; set; }
    
    public RequestViewModel(int id, int idAsset, int idPic, string approval)
    {
        Id = id;
        IdAsset = idAsset;
        IdPic = idPic;
        Approval = approval;
    }
    

    public RequestViewModel()
    {
    }
}
