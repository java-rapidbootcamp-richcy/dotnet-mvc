using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers
{
	public class ProductController : Controller
	{
		private static List<ProductViewModel> _productViewModels = new List<ProductViewModel>()
		{
			new ProductViewModel(1, "Pop Ice Cokelat", "Minuman", 3000),
			new ProductViewModel(2, "Pop Ice Stroberi", "Minuman", 3500),
			new ProductViewModel(3, "Mie Kuah Soto", "Makanan", 4000),
			new ProductViewModel(4, "Mie Kuah Ayam Bawang", "Makanan", 3500)
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
		public IActionResult Save([Bind("Id,Name,Category,Price")]ProductViewModel product)
		{
			_productViewModels.Add(product);
			return Redirect("List");
		}
		public IActionResult List()
		{
			return View(_productViewModels);
		}
		public IActionResult Edit(int? id)
		{
			ProductViewModel product = _productViewModels.Find(x =>x.Id.Equals(id));
			return View(product);
		}
		[HttpPost]
		public IActionResult Update(int id, [Bind("Id,Name,Category,Price")]ProductViewModel product)
		{
			ProductViewModel productOld = _productViewModels.Find(x => x.Id.Equals(id));
			_productViewModels.Remove(productOld);

			_productViewModels.Add(product);
			return Redirect("List");
		}

		public IActionResult Details(int id)
		{
			ProductViewModel product = (from p in _productViewModels where p.Id.Equals(id) select p).SingleOrDefault(new ProductViewModel());
			return View(product);
		}
        [HttpDelete]
        public IActionResult Delete(int? id)
		{
            ProductViewModel product = _productViewModels.Find(x => x.Id.Equals(id));
            _productViewModels.Remove(product);

            return Redirect("List");

        }
    }
}
