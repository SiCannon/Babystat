using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Babystat.Pages.Feed
{
    public class IndexModel : PageModel
    {
        public List<string> Dummy { get; set; } = new List<string> { "One", "Two" };

        public void OnGet()
        {
        }
    }
}