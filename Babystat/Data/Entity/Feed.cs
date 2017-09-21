using System;

namespace Babystat.Data.Entity
{
    public class Feed
    {
        public int FeedId { get; set; }
        public int BabyId { get; set; }
        public int Amount { get; set; }
        public DateTime When { get; set; }

        public virtual Baby Baby { get; set; }
    }
}
