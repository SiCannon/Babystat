using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Babystat.Models.BabyViewModels
{
    public class BabyIndexVm
    {
        public List<BabyIndexItemVm> Babies { get; set; }
    }

    public class BabyIndexItemVm
    {
        public int BabyId { get; set; }
        public string Name { get; set; }
    }
}
