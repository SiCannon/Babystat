using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Babystat.Models;
using Babystat.Data;
using Babystat.Models.HomeViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Babystat.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        ApplicationDbContext context;

        public HomeController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var vm = new IndexViewModel
            {
                Usernames = context.Users.Select(x => x.UserName).ToList()
            };

            return View(vm);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
