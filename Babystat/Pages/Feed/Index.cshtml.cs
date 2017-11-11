using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Babystat.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Babystat.Pages.Feed
{
    public class IndexModel : PageModel
    {
        ApplicationDbContext db;

        public IndexModel(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<IGrouping<DateTime, IndexViewModelItem>> Feeds { get; set; }

        public class IndexViewModelItem
        {
            public int FeedId { get; set; }
            public DateTime When { get; set; }
            public int Amount { get; set; }
        }

        public void OnGet()
        {
            Feeds = db.Feeds.Select(f => new IndexViewModelItem
            {
                FeedId = f.FeedId,
                When = f.When,
                Amount = f.Amount
            }).GroupBy(x => x.When.Date);
        }
    }
}