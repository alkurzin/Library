using AutoMapper;

namespace Library.Domain.Books.MapperProfiles
{
    public class BookMapperProfile : Profile
    {
        public BookMapperProfile()
        {
            CreateMap<Book, BookDto>();
        }
    }
}
