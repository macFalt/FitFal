using AutoMapper;
using FitFalMVC.Application.Mapping;
using FitFalMVC.Domain.Model;

namespace FitFalMVC.Application.ViewModels.WorkoutVmDirector;

public class ExerciseForListVm : IMapFrom<Exercise>
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int Sets { get; set; }

    public int Reps { get; set; }

    public float Weight { get; set; }

    public void ConfigureMapping(Profile profile)
    {
        profile.CreateMap<Exercise, ExerciseForListVm>();
        profile.CreateMap<WorkoutExercise, ExerciseForListVm>()
            .ForMember(dest => dest.Sets, opt => opt.MapFrom(src => src.Sets))
            .ForMember(dest => dest.Reps, opt => opt.MapFrom(src => src.Reps))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Exercise.Name))
            .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.Weight));


    }
}

