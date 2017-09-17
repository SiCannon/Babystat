using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Babystat.Data.Entity
{
    public class Settings
    {
        public int SettingsId { get; set; }
        public int? ActiveBabyId { get; set; }
        public virtual Baby ActiveBaby { get; set; }
    }
}
