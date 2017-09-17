using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Babystat.Models.SettingsViewModels
{
    public class SettingsEditVm
    {
        public int? ActiveBabyId { get; set; }
        public SelectList Babies { get; set; }
    }
}
