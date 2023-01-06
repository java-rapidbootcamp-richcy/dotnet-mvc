using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class AssetController : Controller
    {
        private static List<AssetViewModel> _assetViewModels = new List<AssetViewModel>()
        {
            new AssetViewModel(1, "Laptop HP", "i3","1234","2022",1),
            new AssetViewModel(2, "Laptop Asus", "i7","1234","2022",2),
            new AssetViewModel(3, "Laptop Samsung", "i5","1234","2022",3),
            new AssetViewModel(4, "Laptop Macbook", "i9","1234","2022",4),
            new AssetViewModel(5, "Laptop Linux", "i5","1234","2022",5),

        };

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Save([Bind("Id,AssetName,Specification,SerialNumber,PurchaseYear,IdPic")] AssetViewModel asset)
        {
            _assetViewModels.Add(asset);
            return Redirect("List");
        }
        public IActionResult List()
        {
            return View(_assetViewModels);
        }
        public IActionResult Edit(int? id)
        {
            AssetViewModel asset = _assetViewModels.Find(x => x.Id.Equals(id));
            return View(asset);
        }
        [HttpPost]
        public IActionResult Update(int id, [Bind("Id,AssetName,Specification,SerialNumber,PurchaseYear,IdPic")] AssetViewModel asset)
        {
            AssetViewModel assetOld = _assetViewModels.Find(x => x.Id.Equals(id));
            _assetViewModels.Remove(assetOld);

            _assetViewModels.Add(asset);
            return Redirect("List");
        }

        public IActionResult Details(int id)
        {
            AssetViewModel asset = (from p in _assetViewModels where p.Id.Equals(id) select p).SingleOrDefault(new AssetViewModel());
            return View(asset);
        }
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            AssetViewModel asset = _assetViewModels.Find(x => x.Id.Equals(id));
            _assetViewModels.Remove(asset);

            return Redirect("List");

        }
    }
}
