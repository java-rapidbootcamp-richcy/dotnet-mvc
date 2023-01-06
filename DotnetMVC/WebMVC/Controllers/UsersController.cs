using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers
{
	public class UsersController : Controller
	{
		private static List<UsersViewModel> _usersViewModels = new List<UsersViewModel>()
		{
			new UsersViewModel(1, DateTime.Now, 1,1),
            new UsersViewModel(2, DateTime.Now, 2,2),
            new UsersViewModel(3, DateTime.Now, 3,3),
            new UsersViewModel(4, DateTime.Now, 4,4),
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
		public IActionResult Save([Bind("Id,SendDate,IdHistory,IdAudit")] UsersViewModel users)
		{
            _usersViewModels.Add(users);
			return Redirect("List");
		}
		public IActionResult List()
		{
			return View(_usersViewModels);
		}
		public IActionResult Edit(int? id)
		{
            UsersViewModel users = _usersViewModels.Find(x =>x.Id.Equals(id));
			return View(users);
		}
		[HttpPost]
		public IActionResult Update(int id, [Bind("Id,SendDate,IdHistory,IdAudit")] UsersViewModel users)
		{
            UsersViewModel usersOld = _usersViewModels.Find(x => x.Id.Equals(id));
            _usersViewModels.Remove(usersOld);

            _usersViewModels.Add(users);
			return Redirect("List");
		}

		public IActionResult Details(int id)
		{
            UsersViewModel users = (from p in _usersViewModels where p.Id.Equals(id) select p).SingleOrDefault(new UsersViewModel());
			return View(users);
		}
        [HttpDelete]
        public IActionResult Delete(int? id)
		{
            UsersViewModel users = _usersViewModels.Find(x => x.Id.Equals(id));
            _usersViewModels.Remove(users);

            return Redirect("List");

        }
    }
}
