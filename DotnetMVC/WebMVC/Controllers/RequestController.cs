using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class RequestController : Controller
    {
        private static List<RequestViewModel> _requestViewModels = new List<RequestViewModel>()
        {
            new RequestViewModel(1,1,1,"Setuju"),
            new RequestViewModel(2,2,2,"Ditolak"),
            new RequestViewModel(3,3,3,"Pending"),

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
        public IActionResult Save([Bind("Id,IdAsset,IdPic,Validation")] RequestViewModel request)
        {
            _requestViewModels.Add(request);
            return Redirect("List");
        }
        public IActionResult List()
        {
            return View(_requestViewModels);
        }
        public IActionResult Edit(int? id)
        {
            RequestViewModel request = _requestViewModels.Find(x => x.Id.Equals(id));
            return View(request);
        }
        [HttpPost]
        public IActionResult Update(int id, [Bind("Id,IdAsset,IdPic,Validation")] RequestViewModel request)
        {
            RequestViewModel requestOld = _requestViewModels.Find(x => x.Id.Equals(id));
            _requestViewModels.Remove(requestOld);

            _requestViewModels.Add(request);
            return Redirect("List");
        }

        public IActionResult Details(int id)
        {
            RequestViewModel request = (from p in _requestViewModels where p.Id.Equals(id) select p).SingleOrDefault(new RequestViewModel());
            return View(request);
        }
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            RequestViewModel request = _requestViewModels.Find(x => x.Id.Equals(id));
            _requestViewModels.Remove(request);

            return Redirect("List");

        }
    }
}
