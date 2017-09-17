using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Babystat.Data;
using Babystat.Data.Entity;
using Babystat.Models.SettingsViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Babystat.Controllers
{
    public class SettingsController : Controller
    {
        ApplicationDbContext context;

        public SettingsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Edit()
        {
            var settings = context.Settings.ToList();
            var babies = context.Babies.ToList();

            var vm = new SettingsEditVm
            {
                ActiveBabyId = settings.FirstOrDefault()?.ActiveBabyId,
                Babies = new SelectList(babies, "BabyId", "Name")
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(SettingsEditVm model)
        {
            if (!context.Settings.Any())
            {
                context.Settings.Add(new Settings { ActiveBabyId = model.ActiveBabyId });
                context.SaveChanges();
            }
            else
            {
                while (context.Settings.Count() > 1)
                {
                    context.Settings.Remove(context.Settings.Last());
                }
                context.Settings.First().ActiveBabyId = model.ActiveBabyId;
                context.SaveChanges();
            }

            return RedirectToAction(nameof(Edit));
        }
    }
}