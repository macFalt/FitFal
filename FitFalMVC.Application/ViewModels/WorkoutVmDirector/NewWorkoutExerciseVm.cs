using AutoMapper;
using FitFalMVC.Application.Mapping;
using FitFalMVC.Application.ViewModels.ExerciseVmDirector;
using FitFalMVC.Domain.Model;

namespace FitFalMVC.Application.ViewModels.WorkoutVmDirector;

public class NewWorkoutExerciseVm : IMapFrom<WorkoutExercise>
{
    public int Id { get; set; }

   public int ExerciseId { get; set; }
   
   public int WorkoutId { get; set; }
    
    public int Sets { get; set; }

    public int Reps { get; set; }

    public float Weight { get; set; }
    
    public string ApplicationUser { get; set; }
    public string UserId { get; set; }
    
    public List<ExerciseVmDirector.ExerciseForListVm> Exercises { get; set; } 

    
    public void ConfigureMapping(Profile profile)
    {

         profile.CreateMap<WorkoutExercise, NewWorkoutExerciseVm>();
         profile.CreateMap<NewWorkoutExerciseVm, WorkoutExercise>()
             .ForMember(dest => dest.Sets, opt => opt.MapFrom(src => src.Sets))
             .ForMember(dest => dest.Reps, opt => opt.MapFrom(src => src.Reps))
             .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.Weight))
          .ForMember(dest => dest.WorkoutId, opt => opt.MapFrom(src => src.WorkoutId))
             .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
    }

}