using AsocitaitaPentruUnViitorSustenabil.Domain;
using AsocitaitaPentruUnViitorSustenabil.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AsocitaitaPentruUnViitorSustenabil.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ManageMembers()
        {
            var membruService = new MembruService();
            var membri = membruService.GetMembers();
            return View(membri);
        }

        public IActionResult ManageProjects()
        {
            var proiectService = new ProiectService();
            var proiecte = proiectService.GetProjects();
            return View(proiecte);
        }

        public IActionResult ManageEvents()
        {
            var evenimentService = new EvenimentService();
            var evenimente = evenimentService.GetEvents();
            return View(evenimente);
        }

        public IActionResult FindEvent(string nume)
        {
            var evenimentService = new EvenimentService();
            var eveniment = evenimentService.FindEvent(nume);
            // print eveniment if found
            return View();
        }

        public IActionResult AddEvent(int id, string nume)
        {
            var evenimentService = new EvenimentService();
            var eveniment = new Eveniment
            {
                Id = id,
                Nume = nume
            };
            evenimentService.AddEvent(eveniment);
            return View();
        }

        public IActionResult EditEvent(int id, string nume)
        {
            var evenimentService = new EvenimentService();
            var eveniment = new Eveniment
            {
                Id = id,
                Nume = nume
            };
            evenimentService.EditEvent(eveniment);
            return View();
        }

        public IActionResult DeleteEvent(int id)
        {
            var evenimentService = new EvenimentService();
            evenimentService.DeleteEvent(id);
            return View();
        }

        public IActionResult AddMember(int id, string nume, string email)
        {
            var membruService = new MembruService();
            var membru = new Membru
            {
                Id = id,
                Nume = nume,
                Email = email
            };
            membruService.AddMember(membru);
            return View();
        }

        public IActionResult FindMember(string nume)
        {
            var membruService = new MembruService();
            var membru = membruService.FindMember(nume);
            return View(membru);
        }

        public IActionResult EditMember(int id, string nume, string email)
        {
            var membruService = new MembruService();
            var membru = new Membru
            {
                Id = id,
                Nume = nume,
                Email = email
            };
            membruService.EditMember(membru);
            return View();
        }

        public IActionResult DeleteMember(int id)
        {
            var membruService = new MembruService();
            membruService.DeleteMember(id);
            return View();
        }

        public IActionResult AddProject(int id, string nume)
        {
            var proiectService = new ProiectService();
            var proiect = new Proiect
            {
                Id = id,
                Nume = nume
            };
            proiectService.AddProject(proiect);
            return View();
        }

        public IActionResult FindProject(string nume)
        {
            var proiectService = new ProiectService();
            var proiect = proiectService.FindProject(nume);
            return View(proiect);
        }

        public IActionResult EditProject(int id, string nume)
        {
            var proiectService = new ProiectService();
            var proiect = new Proiect
            {
                Id = id,
                Nume = nume
            };
            proiectService.EditProject(proiect);
            return View();
        }

        public IActionResult DeleteProject(int id)
        {
            var proiectService = new ProiectService();
            proiectService.DeleteProject(id);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
