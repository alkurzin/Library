using AutoMapper;

namespace Library.Domain.Readers.MapperProfiles
{
    public class ReaderMapperProfile : Profile
    {
        public ReaderMapperProfile()
        {
            CreateMap<Reader, ReaderDto>();
        }
    }
}
