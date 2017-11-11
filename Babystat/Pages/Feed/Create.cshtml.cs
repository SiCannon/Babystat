using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Babystat.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Babystat.Pages.Feed
{
    public class CreateModel : PageModel
    {
        ApplicationDbContext db;

        public CreateModel(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void OnGet()
        {
        }

        [BindProperty]
        public CreditViewModel Model { get; set; } = GetDefaultViewModel();

        public class CreditViewModel
        {
            public DateTime When { get; set; }
            public int Amount { get; set; }
        }

        static CreditViewModel GetDefaultViewModel()
        {
            return new CreditViewModel
            {
                When = GetDefaultWhen(),
                Amount = GetDefaultAmount()
            };
        }

        static DateTime GetDefaultWhen()
        {
            var date = DateTime.Now;
            return new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, 0, date.Kind);
        }

        static int GetDefaultAmount()
        {
            return 200;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var feed = new Data.Entity.Feed
            {
                When = Model.When,
                Amount = Model.Amount
            };

            db.Feeds.Add(feed);
            await db.SaveChangesAsync();
            return RedirectToPage("/Feed/Index");
        }
    }
}