using System;
using System.Collections.Generic;

namespace Bookburn.Core.Models
{
    public class Book
    {
        public long Id { get; set; }
        public string Isbn { get; set; }
        public string Name { get; set; }
        public int PageCount { get; set; }
        public string CoverPath { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Description { get; set; }
        public bool HaveHardCover { get; set; }

        public virtual ICollection<Author> Authors { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
        
        public virtual ICollection<UserBookAction> Actions { get; set; }
    }
}