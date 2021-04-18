using System;

namespace Bookburn.Core.Models
{
    public class UserBookAction
    {
        public enum ActionType
        {
            Like,
            Burn,
            Give,
            Take
        }

        public string Id { get; set; }
        public virtual User User { get; set; }
        public virtual Book Book { get; set; }
        public DateTime Time { get; set; }
        public ActionType Type { get; set; }
    }
}