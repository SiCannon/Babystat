using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Babystat.Data.Entity
{
    public class Baby
    {
        public int BabyId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Settings> Settings { get; set; }
    }
}
