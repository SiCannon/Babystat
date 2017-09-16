using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Babystat.Data;
using Babystat.Data.Entity;
using Babystat.Models.BabyViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Babystat.Controllers
{
    public class BabyController : Controller
    {
        ApplicationDbContext context;
        IMapper mapper;

        public BabyController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var babies = context.Babies.ToList();
            var vm = new BabyIndexVm
            {
                Babies = mapper.Map<List<BabyIndexItemVm>>(babies)
            };
            return View(vm);
        }

        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult New(NewBabyEm model)
        {
            if (ModelState.IsValid)
            {
                if (context.Babies.Any(x => x.Name == model.Name))
                {
                    ModelState.AddModelError("Name", "That name is already being used");
                    return View();
                }
                context.Babies.Add(new Baby { Name = model.Name });
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }
    }
}
