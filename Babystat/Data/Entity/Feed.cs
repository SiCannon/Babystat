using System;

namespace Babystat.Data.Entity
{
    public class Feed
    {
        public int FeedId { get; set; }
        public DateTime When { get; set; }
        public int Amount { get; set; }
    }
}
