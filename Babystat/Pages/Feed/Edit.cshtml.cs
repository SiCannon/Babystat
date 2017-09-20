using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Babystat.Pages.Feed
{
    public class EditModel : PageModel
    {
        public void OnGet()
        {
        }

        [BindProperty]
        public EditViewModel Model { get; set; }

        public class EditViewModel
        {
            
        }
    }
}