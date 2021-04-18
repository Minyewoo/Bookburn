using System.Collections.Generic;

namespace Bookburn.Core.Models
{
    public class Author
    {
        public long Id { get; set; }
        public string Name { get; set; }
        
        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}