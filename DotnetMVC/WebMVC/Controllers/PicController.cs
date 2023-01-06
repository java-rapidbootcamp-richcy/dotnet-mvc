using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers
{
	public class PicController : Controller
	{
		private static List<PicViewModel> _picViewModels = new List<PicViewModel>()
		{
			new PicViewModel(1, "Farra"),
            new PicViewModel(2, "Kezia"),
            new PicViewModel(3, "Nurul"),

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
		public IActionResult Save([Bind("Id,PicName")] PicViewModel pic)
		{
            _picViewModels.Add(pic);
			return Redirect("List");
		}
		public IActionResult List()
		{
			return View(_picViewModels);
		}
		public IActionResult Edit(int? id)
		{
			PicViewModel pic = _picViewModels.Find(x =>x.Id.Equals(id));
			return View(pic);
		}
		[HttpPost]
		public IActionResult Update(int id, [Bind("Id,Name,Category,Price")]PicViewModel pic)
		{
            PicViewModel picOld = _picViewModels.Find(x => x.Id.Equals(id));
            _picViewModels.Remove(picOld);

            _picViewModels.Add(pic);
			return Redirect("List");
		}

		public IActionResult Details(int id)
		{
			PicViewModel pic = (from p in _picViewModels where p.Id.Equals(id) select p).SingleOrDefault(new PicViewModel());
			return View(pic);
		}
        [HttpDelete]
        public IActionResult Delete(int? id)
		{
            PicViewModel pic = _picViewModels.Find(x => x.Id.Equals(id));
            _picViewModels.Remove(pic);

            return Redirect("List");

        }
    }
}
