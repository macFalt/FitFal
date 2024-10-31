using AutoMapper;

namespace FitFalMVC.Application.Mapping;

public interface IMapFrom<T>
{
    void ConfigureMapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    


}