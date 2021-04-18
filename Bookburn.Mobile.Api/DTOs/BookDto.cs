using System;

namespace Bookburn.Mobile.Api.DTOs
{
    public class BookDto
    {
        public long Id { get; set; }
        public string Isbn { get; set; }
        public string Name { get; set; }
        public int PageCount { get; set; }
        public string CoverPath { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Description { get; set; }
        public bool HaveHardCover { get; set; }

        public AuthorDto[] Authors { get; set; }
        public GenreDto[] Genres { get; set; }
    }
}