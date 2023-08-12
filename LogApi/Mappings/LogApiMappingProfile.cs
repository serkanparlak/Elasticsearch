using AutoMapper;
using Core.Models;

namespace LogApi.Mappings;
public class LogApiMappingProfile : Profile
{
    LogApiMappingProfile()
    {
        CreateMap<Log, LogInput>();
    }
}