using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Babystat.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Babystat.Pages.Feed
{
    public class DeleteModel : PageModel
    {
        ApplicationDbContext db;

        public DeleteModel(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void OnGet(int id)
        {
            var feed = db.Feeds.Single(x => x.FeedId == id);
            TheViewModel = new DeleteViewModel 
            {
                FeedId = feed.FeedId,
                When = feed.When,
                Amount = feed.Amount
            };
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var feed = db.Feeds.Single(x => x.FeedId == TheViewModel.FeedId);
            db.Feeds.Remove(feed);
            await db.SaveChangesAsync();
            return RedirectToPage("/Feed/Index");
        }

        [BindProperty]
        public DeleteViewModel TheViewModel { get; set; }

        public class DeleteViewModel
        {
            public int FeedId { get; set; }
            public DateTime When { get; set; }
            public int Amount { get; set; }
        }
    }
}