using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class AuditController : Controller
    {
        private static List<AuditViewModel> _auditViewModels = new List<AuditViewModel>()
        {
            new AuditViewModel(1,1,"Baik","12bd","1234","abcd","asdf"),
            new AuditViewModel(2,2,"Baik","12bd","1234","abcd","asdf"),
            new AuditViewModel(3,3,"Baik","12bd","1234","abcd","asdf"),
            new AuditViewModel(4,4,"Baik","12bd","1234","abcd","asdf"),
            new AuditViewModel(5,5,"Baik","12bd","1234","abcd","asdf"),
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
        public IActionResult Save([Bind("Id,IdAsset,ConditionAsset,AntiVirus,WindowsLicense,OfficeLicense,Validation")] AuditViewModel audit)
        {
            _auditViewModels.Add(audit);
            return Redirect("List");
        }
        public IActionResult List()
        {
            return View(_auditViewModels);
        }
        public IActionResult Edit(int? id)
        {
            AuditViewModel audit = _auditViewModels.Find(x => x.Id.Equals(id));
            return View(audit);
        }
        [HttpPost]
        public IActionResult Update(int id, [Bind("Id,IdAsset,ConditionAsset,AntiVirus,WindowsLicense,OfficeLicense,Validation")] AuditViewModel audit)
        {
            AuditViewModel auditOld = _auditViewModels.Find(x => x.Id.Equals(id));
            _auditViewModels.Remove(auditOld);

            _auditViewModels.Add(audit);
            return Redirect("List");
        }

        public IActionResult Details(int id)
        {
            AuditViewModel audit = (from p in _auditViewModels where p.Id.Equals(id) select p).SingleOrDefault(new AuditViewModel());
            return View(audit);
        }
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            AuditViewModel audit = _auditViewModels.Find(x => x.Id.Equals(id));
            _auditViewModels.Remove(audit);

            return Redirect("List");

        }
    }
}
