using System.Collections.Generic;

namespace Bookburn.Core.Models
{
    public class Genre
    {
        public long Id { get; set; }
        public string Name { get; set; }
        
        public virtual ICollection<Author> Authors { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}