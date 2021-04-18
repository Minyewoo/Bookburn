namespace Bookburn.Mobile.Api.DTOs
{
    public class BookListDto
    {
        public BookListItemDto[] Items { get; set; } = new BookListItemDto[0];
        public class BookListItemDto
        {
            public long Id { get; set; }
            public string Name { get; set; }
            public string CoverPath { get; set; }
            public AuthorDto[] Authors { get; set; }
        }
    }
}