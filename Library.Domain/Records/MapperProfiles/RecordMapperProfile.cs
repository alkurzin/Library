using AutoMapper;

namespace Library.Domain.Records.MapperProfiles
{
    public class RecordMapperProfile : Profile
    {
        public RecordMapperProfile()
        {
            CreateMap<Record, RecordDto>();
        }
    }
}
