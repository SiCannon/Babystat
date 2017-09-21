using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Babystat.Data;
using Babystat.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Babystat.Pages.Feed
{
    public class IndexModel : PageModel
    {
        ApplicationDbContext context;

        public IndexModel(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<string> Dummy { get; set; } = new List<string> { "One", "Two" };

        public List<Baby> Babies { get; set; }

        public void OnGet()
        {
        }
    }
}