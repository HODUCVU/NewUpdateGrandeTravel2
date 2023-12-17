using GrandeTravel.Data;
using GrandeTravel.Models;
using GrandeTravel.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace GrandeTravel.Controllers
{
    public class HomeController : Controller
    {
        private IEmailSender _emailService;
        private IRepository<TravelPackage> _TravelPackageRepo;

        public HomeController(IEmailSender emailService, IRepository<TravelPackage> TravelPackageRepo)
        {
            _TravelPackageRepo = TravelPackageRepo;
            _emailService = emailService;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<string> names = new List<string>();
            var list = _TravelPackageRepo.Query(p => !p.Discontinued);
            foreach (var item in list)
            {
                names.Add(item.PackageName);
            }
            var json = JsonConvert.SerializeObject(names);
            SearchIndexViewModel vm = new SearchIndexViewModel
            {
                list = json
            };
            
            return View(vm);
        }
        public IActionResult About()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Contact(ContactViewModel vm)
        {
            if (ModelState.IsValid)
            {

                _emailService.SendEmail(vm.FromAddress, "hoducvu1234@gmail.com", vm.Subject, vm.Body);

                return RedirectToAction("index");
            }
            return View(vm);
        }
    }
}
