using System.Xml.Linq;

namespace WebMVC.Models;

public class AuditViewModel
{

    public int Id { get; set; }
    public int IdAsset{ get; set; }
    public string ConditionAsset { get; set; }
    public string AntiVirus { get; set; }
    public string WindowsLicense { get; set; }
    public string OfficeLicense { get; set; }
    public string Validation { get; set; }
    public AuditViewModel(int id, int idAsset, string conditionAsset, string antiVirus, string windowsLicense, string officelicense, string validation)
    {
        Id = id;
        IdAsset = idAsset;
        ConditionAsset= conditionAsset;
        AntiVirus= antiVirus;
        WindowsLicense = windowsLicense;
        OfficeLicense = officelicense;
        Validation = validation;
    }

    public AuditViewModel()
    {
    }
}
