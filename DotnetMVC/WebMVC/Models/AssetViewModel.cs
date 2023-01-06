using System.Xml.Linq;

namespace WebMVC.Models;

public class AssetViewModel
{

    public int Id { get; set; }
    public string AssetName { get; set; }
    public string Specification { get; set; }
    public string SerialNumber { get; set; }
    public string PurchaseYear { get; set; }
    public int IdPic { get; set; }
    public AssetViewModel(int id, string assetName, string specification, string serialNumber, string purchaseYear, int idPic)
    {
        Id = id;
        AssetName = assetName;
        Specification = specification;
        SerialNumber = serialNumber;
        PurchaseYear = purchaseYear;
        IdPic = idPic;
    }

    public AssetViewModel()
    {
    }
}
