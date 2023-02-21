using AutoMapper;

namespace FutureComputer.Application.Configs;

public class MappingProfileConfig<T, TResult> : Profile
{
    public MappingProfileConfig()
    {
        // convert from T - TResult
        CreateMap<T, TResult>();

        // convert from TResult - T
        CreateMap<TResult, T>();
    }
}