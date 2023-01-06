using System.Xml.Linq;

namespace WebMVC.Models;

public class PicViewModel
{

    public int Id { get; set; }
    public string PicName { get; set; }
 
    public PicViewModel(int id, string picName)
    {
        Id = id;
        PicName = picName;
    }

    public PicViewModel()
    {
    }
}
