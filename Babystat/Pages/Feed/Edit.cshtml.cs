using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Babystat.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Babystat.Pages.Feed
{
    public class EditModel : PageModel
    {
        ApplicationDbContext db;

        public EditModel(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void OnGet(int id)
        {
            var feed = db.Feeds.Single(x => x.FeedId == id);
            Model = new EditViewModel
            {
                FeedId = feed.FeedId,
                When = feed.When,
                Amount = feed.Amount
            };
        }

        [BindProperty]
        public EditViewModel Model { get; set; }

        public class EditViewModel
        {
            public int FeedId { get; set; }
            public DateTime When { get; set; }
            public int Amount { get; set; }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var feed = db.Feeds.Single(x => x.FeedId == Model.FeedId);
            feed.When = Model.When;
            feed.Amount = Model.Amount;
            await db.SaveChangesAsync();
            return RedirectToPage("/Feed/Index");
        }
    }
}