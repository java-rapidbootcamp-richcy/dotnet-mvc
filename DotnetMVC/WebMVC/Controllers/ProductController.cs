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
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Add()
		{
			return View();
		}
		public IActionResult List()
		{
			List<ProductViewModel> productList = new List<ProductViewModel>()
			{
				new ProductViewModel(1, "Mie Kuah Kari Ayam", "Makanan", 2500),
				new ProductViewModel(2, "Mie Kuah Soto", "Makanan", 2600),
				new ProductViewModel(3, "Mie Kuah Ayam Bawang", "Makanan", 2300),
				new ProductViewModel(4, "Jus Jeruk", "Minumam", 5000),

			};
			return View(productList);
		}

		public IActionResult Details()
		{
			ProductViewModel product = new ProductViewModel(4, "Jus Jeruk", "Minuman", 5000);
			return View(product);
		}
	}
}
